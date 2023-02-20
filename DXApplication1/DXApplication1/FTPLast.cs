using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace DXApplication1
{
    public class FTPLast
    {
        /// <summary>
        /// FTP的服务器地址，例如：ftp:192.168.1.120:21
        /// </summary>
        private string FTPCONSTR { get; set; }

        /// <summary>
        /// FTP服务器用户名
        /// </summary>
        private string FTPUserName { get; set; }

        /// <summary>
        /// FTP服务器密码
        /// </summary>
        private string FTPPassWord { get; set; }

        private Queue<FTPModel> FTPModels = new Queue<FTPModel>();

        /// <summary>
        /// 上传操作委托
        /// </summary>
        public Func<Queue<FTPModel>, Queue<FTPModel>> FTPModelFactory { get; set; }

        /// <summary>
        /// 设置FTP服务器信息
        /// </summary>
        /// <param name="ip">FTP服务器ip地址</param>
        /// <param name="username">服务器用户名</param>
        /// <param name="password">服务器密码</param>
        /// <param name="port">服务器端口，默认为21端口</param>
        public bool SetFTPImformation(string ip, string username, string password, string port = "21")
        {
            bool result = ValidFTPInfo(ip, username, password, port);
            if (!result) return false;
            FTPCONSTR = string.Format("{0}://{1}:{2}", "ftp", ip, port);
            FTPUserName = username;
            FTPPassWord = password;
            return true;
        }

        /// <summary>
        /// 判断目标是文件夹还是目录(目录包括磁盘)
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <returns>返回true为一个文件夹，返回false为一个文件</returns>
        private bool IsDirectory(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            bool result = (fi.Attributes & FileAttributes.Directory) != 0;
            return result;
        }

        public void ShowUploadFile(string localPath, string targetPath)
        {
            GetALLModels(localPath, targetPath);
            if (FTPModels.Count < 1 || FTPModels == null)
                return ;
            else
                this.FTPModelFactory?.Invoke(FTPModels);
            //this.FTPModelFactory = AfterUpload;
            //  this.FTPModelFactory.Invoke(FTPModels);
        }

        private Queue<FTPModel> AfterUpload(Queue<FTPModel> fTPModels)
        {
            return fTPModels; 
        }

        /// <summary>
        /// 本地文件上传到FTP服务器带进度条
        /// </summary>
        /// <remarks> 
        /// 请先调用SetFTPImformation方法设置FTP服务器信息 
        /// </remarks>
        /// <param name="localPath"></param>
        /// <param name="targetPath"></param>
        /// <param name="pb">进度条</param>
        /// <returns></returns>
        public bool ExcuteUpload(string localPath, string targetPath)
        {
            GetALLModels(localPath, targetPath);
            if(FTPModels.Count < 1 || FTPModels == null) return false;
            foreach (FTPModel model in FTPModels)
            {
                bool result = UploadFile(model);
                if (!result) continue;
            }
            return true;
        }

        public bool UploadFile(FTPModel model)
        {
            string localPath = model.LocalPath;
            string targetPath = model.RFullName;
            FileInfo fileInfo = new FileInfo(localPath);
           // localPath = localPath.Replace("\\", "/");
            string path = FTPCONSTR + "/" + targetPath + "/" + fileInfo.Name;
            bool exist = CreateDircetores(targetPath);
            if (!exist) return false;

           bool match = HandelMatchFile(model);
            if(!match) return false;
            FtpWebRequest reqFtp = (FtpWebRequest)WebRequest.Create(new Uri(path));
            reqFtp.UseBinary = true;
            reqFtp.Credentials = new NetworkCredential(FTPUserName, FTPPassWord);
            reqFtp.KeepAlive = false;
            reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
            reqFtp.ContentLength = fileInfo.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fileStream = fileInfo.OpenRead();
            int allbye = (int)fileInfo.Length;
   
            int startbye = 0;
            try
            {
                model.State = gisqSceneImportState.Importing.ToString();
                if(model.FileAppend)
                {
                    reqFtp.Method = WebRequestMethods.Ftp.AppendFile;
                    reqFtp.ContentOffset = model.LSize;
                    //fs.Position = arg.SrcSize;
                    fileStream.Seek(model.LSize, 0);
                   // fs.Seek(arg.SrcSize, 0);
                }
                Stream strm = reqFtp.GetRequestStream();
                contentLen = fileStream.Read(buff, 0, buffLength);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    startbye = contentLen + startbye;
                    contentLen = fileStream.Read(buff, 0, buffLength);
                    if (stopwatch.ElapsedMilliseconds > 1000)
                    {
                        decimal percent = startbye / model.LSize;
                        model.Percent = percent.ToString("P2");
                        stopwatch.Restart();
                    }
                }
                strm.Close();
                fileStream.Close();
                stopwatch.Stop();
                model.State = gisqSceneImportState.Imported.ToString();
                return true;
            }
            catch
            {
                return false;
            };
        }

        /// <summary>
        /// 待上传文件进入队列
        /// </summary>
        /// <param name="fileInfo"></param>
        private void InsertQeue(FileInfo fileInfo, string targetPath)
        {
            FTPModel model = new FTPModel()
            {
                Name = fileInfo.Name,
                LocalPath = fileInfo.FullName,
                LSize = fileInfo.Length,
                FileAppend = false,
                RFullName = targetPath,
                State = gisqSceneImportState.NoImport.ToString(),
                Percent = string.Empty,
            };
            FTPModels.Enqueue(model);
        }

        private bool ValidFTPInfo(string ip, string username, string password, string port)
        {
            if (string.IsNullOrEmpty(ip))
            {
                //  LogHelper.Error("FTP服务器ip地址为空！");
                return false;
            }
            if (string.IsNullOrEmpty(port))
            {
                //  LogHelper.Error("FTP服务器端口为空！");
                return false;
            }
            if (string.IsNullOrEmpty(username))
            {
                //  LogHelper.Error("FTP服务器用户名为空！");
                return false;
            }
            if (string.IsNullOrEmpty(ip))
            {
                //  LogHelper.Error("FTP服务器密码为空！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检查FTP服务端所匹配的文件(服务器断网、客户端断网等多种因素造成)
        /// </summary>
        private bool HandelMatchFile(FTPModel model)
        {
            bool result = true;
            Tuple<int, long> tuple = CompareFileSize(model);
            switch (tuple.Item1)
            {
                case 1:
                    result = true;
                    break;
                case 2:
                    //尝试断点续传服务端文件
                    model.FileAppend = true;
                    model.LSize= tuple.Item2;
                    result = true;
                    break;
                case 3:
                    MessageBox.Show("文件已存在");
                    result = false;
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// 对比远程文件大小
        /// 1. 远程无此文件返回 --- 1
        /// 2. 远程文件比本地小 --- 2
        /// 3. 远程文件与本地大小一致 --- 3
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Tuple<int, long> CompareFileSize(FTPModel model)
        {
           model.RSize = GetFileSize(model.Name,model.RFullName);

            if (model.RSize == 0)
                return new Tuple<int, long>(1, 0);

            //匹配已上传文件的大小
            if(model.RSize < model.LSize)
                return new Tuple<int, long>(2, model.RSize);
            else
                return new Tuple<int, long>(3, model.RSize);
        }

        /// <summary>
        /// 获取已上传文件大小
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <param name="remotePath">服务器文件路径</param>
        /// <returns></returns>
        public long GetFileSize(string filename, string remotePath)
        {
            try
            {
                string path = FTPCONSTR + "/" + remotePath + "/" + filename;
                var reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(path));
                reqFTP.KeepAlive = false;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(FTPUserName, FTPPassWord);
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long filesize = response.ContentLength;
                return filesize;
            }
            catch
            {
                return 0;
            };
        }

        /// <summary>
        /// 创建多级目录
        /// </summary>
        /// <param name="dirName">目录名称</param>
        public bool CreateDircetores(string dirName)
        {
            string[] dirs = dirName.Split('/');
            string curDir = string.Empty;
            for (int i = 0; i < dirs.Length; i++)
            {
                string dir = dirs[i];
                //如果是以/开始的路径,第一个为空    
                if (dir != null && dir.Length > 0)
                {
                    curDir += dir + "/";
                    bool exist = RemoteFtpDirExists(curDir);
                    if (!exist) CreateDirectory(curDir);
                }
            }
            return true;
        }

        /// <summary>
        /// 在FTP服务器上创建文件目录
        /// </summary>
        public bool CreateDirectory(string directoryName)
        {
            string path = FTPCONSTR + "/" + directoryName;

            try
            {
                FtpWebRequest reqFtp = (FtpWebRequest)WebRequest.Create(new Uri(path));
                reqFtp.UseBinary = true;
                reqFtp.Credentials = new NetworkCredential(FTPUserName, FTPPassWord);
                reqFtp.KeepAlive = false;
                reqFtp.Method = WebRequestMethods.Ftp.MakeDirectory;

                FtpWebResponse response = (FtpWebResponse)reqFtp.GetResponse();
                response.Close();
                return true;
            }
            catch
            {
                return false;
            };
        }

        /// <summary>
        /// 判断ftp上的文件目录是否存在
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        public bool RemoteFtpDirExists(string directoryName)
        {
           string  path = FTPCONSTR + "/" + directoryName;
           try
            {
                FtpWebRequest reqFtp = (FtpWebRequest)WebRequest.Create(new Uri(path));
                reqFtp.UseBinary = true;
                reqFtp.Credentials = new NetworkCredential(FTPUserName, FTPPassWord);
                reqFtp.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse resFtp = null;

                resFtp = (FtpWebResponse)reqFtp.GetResponse();
                FtpStatusCode code = resFtp.StatusCode;//OpeningData
                resFtp.Close();
                return true;
            }
           catch
           {
                return false;
           };
        }

        public void GetALLModels(string localPath, string targetPath)
        {
            bool isDir = IsDirectory(localPath);
            FileInfo fileInfo = new FileInfo(localPath);
         
            if (isDir)
            {
                string[] strDirectores = Directory.GetDirectories(localPath);
                if(strDirectores != null && strDirectores.Count() > 0)
                {
                    foreach(string strDirectory in strDirectores)
                    {
                        FileInfo fileInfo1 = new FileInfo(strDirectory);
                        string  newTargetPath = targetPath +"/" + fileInfo1.Name;
                        GetALLModels(strDirectory, newTargetPath);
                    }
                }
                string[] strFiles = Directory.GetFiles(localPath);
                foreach (string strFile in strFiles)
                {
                    FileInfo fileInfo1 = new FileInfo(strFile);
                    string newTargetPath = targetPath + "/" + fileInfo.Name;
                    InsertQeue(fileInfo1, newTargetPath);
                }
            }
            else InsertQeue(fileInfo, targetPath);
        }

        /// <summary>
        /// 
        /// </summary>
        public void TimeFunction()
        {
            while(true)
            {
                this.FTPModelFactory?.Invoke(FTPModels);
                Thread.Sleep(2000);
            }
        }

    }
}
