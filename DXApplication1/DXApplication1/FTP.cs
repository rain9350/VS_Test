using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DXApplication1
{
    public class LoadFileEventArgs : CancelEventArgs
    {
        /// <summary>Ftp文件</summary>
        public String Src { get; set; }

        /// <summary>Ftp文件目录</summary>
        public String SrcDir { get; set; }

        /// <summary>源文件大小</summary>
        public Int64 SrcSize { get; set; }

        /// <summary>目标文件</summary>
        public String Des { get; set; }

        /// <summary>目标文件大小</summary>
        public Int64 DesSize { get; set; }

        /// <summary>断点续传</summary>
        public bool FileAppend { get; set; }

        /// <summary>该文件需要压缩</summary>
        public Boolean NeedZipFile { get; set; }

        /// <summary>该文件太大需要分段压缩</summary>
        public Boolean NeedSubZipFile { get; set; }
    }

    public class FtpHelper
    {
        public String ftpHostName;
        public String ftpUserId;
        public String ftpPassword;
        public String fileParam;  //  ../Datas/Robot-{参数}/

        public string localDir { get; set; }

        private static readonly object sys = new object();
        private static FtpHelper instance = null;
        private Queue<LoadFileEventArgs> pathQueue = new Queue<LoadFileEventArgs>();

        private String ftpURI
        {
            get { return String.Format("ftp://{0}", ftpHostName); }
        }

        private String remoteDir
        {
            get { return String.Format("Robot-{0}//", fileParam); }
        }

        public static FtpHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (sys)
                    {
                        if (instance == null)
                            instance = new FtpHelper();
                    }
                }

                return instance;
            }
        }
        private delegate bool AsyncDelegate(LoadFileEventArgs arg);
        private event EventHandler<LoadFileEventArgs> onUploadFileEvent;
        private event EventHandler<LoadFileEventArgs> onUploadFileFinishedEvent;
        public event EventHandler onMonitorUploadEvent;
        private bool IsWorking = false;//上传工作是否在进行；
        private FtpWebResponse webresp = null;


        private FtpHelper()
        {
            onUploadFileEvent += FtpHelper_onUploadFileEvent;
            onUploadFileFinishedEvent += FtpHelper_onUploadFileFinishedEvent;
            onMonitorUploadEvent += FtpHelper_onMonitorUploadEvent;
            this.onMonitorUploadEvent?.Invoke(null, null); //测试时注释
        }

        /// <summary>
        /// 测试接口，正式发布时将要注释
        /// </summary>
        public void FuncInit()
        {

            //UploadDirectory();
        }

        /// <summary>
        /// 上传目录下文件
        /// </summary>
        private void UploadDirectory()
        {
            if (!Directory.Exists(localDir)) return;
            String[] fileArray;
            String[] pathArray = Directory.GetDirectories(localDir);
            String strDir = String.Empty;
            foreach (String str in pathArray)
            {
                fileArray = Directory.GetFiles(str);
                foreach (String temp in fileArray)
                {
                    InsertQueue(temp, str);
                }
            }

            //准备上传文件
            PerUpload();

        }

        /// <summary>
        /// 插入队列
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="dirPath"></param>
        void InsertQueue(String filePath, String dirPath = "")
        {
            if (!System.IO.File.Exists(filePath)) return;
            if (String.IsNullOrEmpty(dirPath))
            {
                String[] pathArray = Directory.GetDirectories(localDir);
                foreach (String str in pathArray)
                {
                    if (filePath.Contains(str))
                    {
                        dirPath = str;
                        break;
                    }
                }
            }

            FileInfo fi = new FileInfo(filePath);
            String strDir = String.Format("{0}{1}//{2}//{3}//{4}", remoteDir, dirPath.Split('\\').Last(), fi.CreationTime.Date.Year, fi.CreationTime.Date.Month, fi.CreationTime.Date.Day);
            this.pathQueue.Enqueue(new LoadFileEventArgs
            {
                Des = filePath,
                SrcDir = String.Format("ftp://{0}/{1}", ftpHostName, strDir),
                Src = String.Format("ftp://{0}//{1}/{2}", ftpHostName, strDir, fi.Name),
                DesSize = fi.Length,
                SrcSize = 0,
                FileAppend = false
            });
        }

        private void PerUpload()
        {
            Task.Factory.StartNew(() => {
                if (FTPConnonect())
                {
                    try
                    {
                        IsWorking = true;
                        AsyncDelegate uploadDelegate;
                        while (this.pathQueue != null && this.pathQueue.Count > 0)
                        {
                            if (!FTPConnonect())
                                break;

                            System.Threading.Thread.Sleep(100);
                            LoadFileEventArgs args = this.pathQueue.Peek();
                            //检查上传文件所在的目录是否存在，不存在则创建所在的目录。
                            MakeDir(args.SrcDir);
                            //检查文件是否已存在并判断文件大小
                            Boolean res = HandelMatchFile(args);
                            if (!res)
                            {
                                //FTP服务器上文件已存在,删除准备出栈的队列。
                                this.pathQueue.Dequeue();
                                continue;
                            }

                            uploadDelegate = new AsyncDelegate(instance.Upload);
                            IAsyncResult iasync = uploadDelegate.BeginInvoke(args, new AsyncCallback(FuncCallBack), null);
                            bool result = uploadDelegate.EndInvoke(iasync);
                            if (result)
                            {
                                this.onUploadFileFinishedEvent?.Invoke(null, args);
                            }
                            else
                                this.pathQueue.Dequeue();
                        }
                    }
                    catch (System.Exception ex)
                    {
                       
                    }
                    finally
                    {
                        IsWorking = false;
                    }
                }
            });
        }

        private bool FTPConnonect()
        {
            DateTime currTime = DateTime.Now;
            int timed = 300; //约定定时时长300s=5分钟。

            while (true)
            {
                try
                {
                    //超过约定时长，退出循环
                    if (DateTime.Now.Subtract(currTime).Seconds > timed)
                        return false;

                    using (webresp = (FtpWebResponse)SetFtpWebRequest(ftpURI, WebRequestMethods.Ftp.ListDirectory).GetResponse())
                    {
                        webresp.Dispose();
                        webresp.Close();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    if (webresp != null)
                    {
                        webresp.Dispose();
                        webresp.Close();
                    }

                    System.Threading.Thread.Sleep(10000);
                }
            }
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool Upload(LoadFileEventArgs arg)
        {
            Stream reqStream = null;
            FileStream fs = null;
            FtpWebResponse uploadResponse = null;

            Uri uri = new Uri(arg.Src);
            FtpWebRequest reqFtp = (FtpWebRequest)WebRequest.Create(uri);
            reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
            reqFtp.KeepAlive = false;
            reqFtp.Credentials = new NetworkCredential(ftpUserId, ftpPassword);
            reqFtp.UsePassive = false;
            reqFtp.UseBinary = true;
            reqFtp.ContentLength = arg.DesSize;
            reqFtp.Timeout = 10000;
            fs = File.Open(arg.Des, FileMode.Open);
            byte[] buffer = new byte[2024];
            int bytesRead;

            try
            {
                if (arg.FileAppend)
                {
                    //断点续传
                    reqFtp.Method = WebRequestMethods.Ftp.AppendFile;
                    reqFtp.ContentOffset = arg.SrcSize;
                    //fs.Position = arg.SrcSize;
                    fs.Seek(arg.SrcSize, 0);
                }

                using (reqStream = reqFtp.GetRequestStream())
                {
                    while (true)
                    {
                        bytesRead = fs.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                            break;

                        reqStream.Write(buffer, 0, bytesRead);
                    }

                    reqStream.Dispose();
                    reqStream.Close();
                }

                uploadResponse = reqFtp.GetResponse() as FtpWebResponse;
                return true;
            }
            catch (Exception ex)
            {
                //SaveLog.WriteLog(new LogObj() { MessageText = String.Format("上传文件到ftp服务器出错：{0}", ex.ToString()), MessageType = LogType.Info });
                return false;
            }
            finally
            {
                if (reqStream != null)
                {
                    reqStream.Dispose();
                    reqStream.Close();
                }

                if (fs != null)
                {
                    fs.Dispose();
                    fs.Close();
                }

                if (uploadResponse != null)
                {
                    uploadResponse.Dispose();
                    uploadResponse.Close();
                }
            }
        }

        /// <summary>
        /// 回调函数，暂时保留
        /// </summary>
        /// <param name="res"></param>
        void FuncCallBack(IAsyncResult res)
        {
            if (res.IsCompleted)
            {
                //暂时保留
            }
        }

        /// <summary>
        /// FTP服务器端创建文件夹。
        /// </summary>
        /// <param name="strPath"></param>
        private void MakeDir(String strPath)
        {
            try
            {
                if (RemoteDirExist(strPath)) return;
                using (webresp = (FtpWebResponse)SetFtpWebRequest(strPath, WebRequestMethods.Ftp.MakeDirectory).GetResponse())
                {
                    using (Stream ftpStream = webresp.GetResponseStream())
                    {
                        ftpStream.Dispose();
                        ftpStream.Close();
                        webresp.Dispose();
                        webresp.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //SaveLog.WriteLog(new LogObj() { MessageText = String.Format("FTP服务器端创建文件夹异常：{0}", ex.ToString()), MessageType = LogType.Info });
            }
        }

        /// <summary>
        /// 检查FTP服务端所匹配的文件(服务器断网、客户端断网等多种因素造成)
        /// </summary>
        private Boolean HandelMatchFile(LoadFileEventArgs args)
        {
            Boolean res = true;
            Tuple<int, int> tuple = CompareFileSize(args);
            switch (tuple.Item1)
            {
                case 1:
                    break;
                case 2:
                    //尝试断点续传服务端文件
                    args.FileAppend = true;
                    args.SrcSize = tuple.Item2;
                    res = true;
                    break;
                case 3:
                    try
                    {
                        //删除本地文件
                        System.IO.File.Delete(args.Des);
                    }
                    catch (System.Exception ex)
                    {
                        //SaveLog.WriteLog(new LogObj() { MessageText = String.Format("###删除本地文件失败,异常原因：{0}", ex.Message), MessageType = LogType.Error });
                    }
                    res = false;
                    break;
                default:
                    res = false;
                    break;
            }

            return res;
        }

        /// <summary>
        /// 检查FTP服务端是否存在当前目录
        /// </summary>
        /// <param name="remoteDirName"></param>
        /// <returns></returns>
        private bool RemoteDirExist(String remoteDirName)
        {
            try
            {
                using (webresp = (FtpWebResponse)SetFtpWebRequest(remoteDirName, WebRequestMethods.Ftp.ListDirectoryDetails).GetResponse())
                {
                    webresp.Dispose();
                    webresp.Close();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                if (webresp != null)
                {
                    webresp.Dispose();
                    webresp.Close();
                }

                //SaveLog.WriteLog(new LogObj() { MessageText = String.Format("检查FTP服务器端目录文件造成异常：{0}", ex.ToString()), MessageType = LogType.Info });
                return false;
            }
        }

        /// <summary>
        /// 获取FTP服务端文件基本信息(文件名、大小)，文件不存在返回空
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private String GetRemoteFileDetails(String uri)
        {
            StreamReader sr = null;
            String content = String.Empty;
            try
            {
                using (webresp = (FtpWebResponse)SetFtpWebRequest(uri, WebRequestMethods.Ftp.ListDirectoryDetails).GetResponse())
                {
                    using (sr = new StreamReader(webresp.GetResponseStream(), Encoding.Default))
                    {
                        content = sr.ReadLine();

                        sr.Dispose();
                        sr.Close();
                        webresp.Dispose();
                        webresp.Close();

                        return content;
                    }
                }
            }
            catch (System.Exception ex)
            {
                if (sr != null)
                {
                    sr.Dispose();
                    sr.Close();
                }

                if (webresp != null)
                {
                    webresp.Dispose();
                    webresp.Close();
                }

                //SaveLog.WriteLog(new LogObj() { MessageText = String.Format("获取FTP服务器端文件信息时产生异常：{0}", ex.ToString()), MessageType = LogType.Info });
                return content;
            }
        }

        /// <summary>
        /// 删除FTP服务端文件
        /// </summary>
        /// <param name="uri"></param>
        private void DelRemoteFile(String uri)
        {
            StreamReader sr = null;
            String content = String.Empty;
            try
            {
                using (webresp = (FtpWebResponse)SetFtpWebRequest(uri, WebRequestMethods.Ftp.DeleteFile).GetResponse())
                {
                    using (sr = new StreamReader(webresp.GetResponseStream(), Encoding.Default))
                    {
                        content = sr.ReadToEnd();

                        sr.Dispose();
                        sr.Close();
                        webresp.Dispose();
                        webresp.Close();
                    }
                }
            }
            catch
            {
                if (sr != null)
                {
                    sr.Dispose();
                    sr.Close();
                }

                if (webresp != null)
                {
                    webresp.Dispose();
                    webresp.Close();
                }
            }
        }

        /// <summary>
        /// 设置FTP WebRequest参数
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="webRequestMethods"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        FtpWebRequest SetFtpWebRequest(String uri, String webRequestMethods, int timeOut = 3000)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri(uri));
            ftpRequest.Method = webRequestMethods;
            ftpRequest.UsePassive = false;
            ftpRequest.UseBinary = true;
            ftpRequest.KeepAlive = false;
            ftpRequest.Timeout = timeOut;
            ftpRequest.Credentials = new NetworkCredential(ftpUserId, ftpPassword);
            return ftpRequest;
        }

        /// <summary>
        /// 对比远程文件大小
        /// 1. 远程无此文件返回 --- 1
        /// 2. 远程文件比本地小 --- 2
        /// 3. 远程文件与本地大小一致 --- 3
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private Tuple<int, int> CompareFileSize(LoadFileEventArgs args)
        {
            String content = GetRemoteFileDetails(args.Src);
            if (String.IsNullOrEmpty(content))
                return new Tuple<int, int>(1, 0);

            //匹配已上传文件的大小
            Regex regex = new Regex(@"^-.+?\sftp.+?\s+(?<size>\d+)", RegexOptions.IgnoreCase);
            Match match = regex.Match(content);
            if (match.Success)
            {
                int fileSize = Convert.ToInt32(match.Groups["size"].Value);
                if (fileSize < args.DesSize)
                    return new Tuple<int, int>(2, fileSize);

                return new Tuple<int, int>(3, fileSize);
            }

            return new Tuple<int, int>(2, 0);
        }

        /// <summary>
        /// 获取FTP服务器端文件大小
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        long GetRemoteFileSize(String src)
        {
            long size;
            try
            {
                using (webresp = (FtpWebResponse)SetFtpWebRequest(src, WebRequestMethods.Ftp.GetFileSize).GetResponse())
                {
                    size = webresp.ContentLength;
                    webresp.Dispose();
                    webresp.Close();
                    return size;
                }
            }
            catch (System.Exception ex)
            {
                if (webresp != null)
                {
                    webresp.Dispose();
                    webresp.Close();
                }

                //SaveLog.WriteLog(new LogObj() { MessageText = String.Format("获取FTP服务器端文件大小时产生异常：{0}", ex.ToString()), MessageType = LogType.Info });
                return 0;
            }
        }

        /// <summary>
        /// 单个文件上传完毕，触发此事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FtpHelper_onUploadFileFinishedEvent(object sender, LoadFileEventArgs e)
        {
            //String content = GetRemoteFileDetails(e.Src);
            long size = GetRemoteFileSize(e.Src);
            if (size == 0)
            {
                //SaveLog.WriteLog(new LogObj() { MessageText = String.Format("###当前上传的文件可能出现异常或者远程无法连接上，文件源路径：{0}; 上传服务器路径：{1}", e.Des, e.Src), MessageType = LogType.Error });
            }
            else
            {
                if (size == e.DesSize)
                {
                    //SaveLog.WriteLog(new LogObj() { MessageText = String.Format("###文件上传成功文件大小为{0}, 服务器路径：{1}", e.DesSize, e.Src), MessageType = LogType.Error });
                    this.pathQueue.Dequeue();//删除准备出栈的队列

                    try
                    {
                        //删除本地文件
                        System.IO.File.Delete(e.Des);
                    }
                    catch (System.Exception ex)
                    {
                        //SaveLog.WriteLog(new LogObj() { MessageText = String.Format("###删除本地文件失败,异常原因：{0}", ex.Message), MessageType = LogType.Error });
                    }
                }
                else
                {
                    //    SaveLog.WriteLog(new LogObj() { MessageText = "###文件上传完毕，但本地与远程文件大小不一致，将删除远程文件再重新上传。", MessageType = LogType.Error });
                    DelRemoteFile(e.Src);
                }
            }
        }

        private void FtpHelper_onUploadFileEvent(object sender, LoadFileEventArgs e)
        {

        }

        private void FtpHelper_onMonitorUploadEvent(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => {
                while (true)
                {
                    if (FTPConnonect())
                    {
                        if (!IsWorking && this.pathQueue != null && this.pathQueue.Count > 0)
                        {
                            PerUpload();
                            System.Threading.Thread.Sleep(5000);
                        }
                        else if (!IsWorking && (this.pathQueue == null || this.pathQueue.Count == 0))
                        {
                            UploadDirectory();
                            System.Threading.Thread.Sleep(5000);
                        }
                        else if (IsWorking)
                        {
                            System.Threading.Thread.Sleep(5000);
                        }
                    }
                    else
                        System.Threading.Thread.Sleep(10000);
                }
            });
        }

        /// <summary>
        /// 上传文件到FTP服务端
        /// </summary>
        /// <param name="src">本地文件路径</param>
        public void Put(String src)
        {
            String path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, src);
            InsertQueue(path, String.Empty);
        }
    }
}
