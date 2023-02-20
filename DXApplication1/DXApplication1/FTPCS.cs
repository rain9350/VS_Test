using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DXApplication1
{
    /// <summary>
    /// FTP断点续传操作类
    /// </summary>
    public class FTPCS
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

        private Queue<FTPModel> FTPModels { get; set; }

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
        public bool ExcuteUpload(string localPath, string targetPath, ProgressBarControl pb)
        {
            bool isDir = IsDirectory(localPath);
            FileInfo fileInfo = new FileInfo(localPath);
            if (isDir)
            {
                string[] strFiles = Directory.GetFiles(localPath);
                foreach (string strFile in strFiles)
                {
                    FileInfo fileInfo1 = new FileInfo(strFile);
                    targetPath = targetPath + "/" + fileInfo1.Name;
                    InsertQeue(fileInfo1,targetPath);
                }
            }
            else InsertQeue(fileInfo, targetPath);

            while((FTPModels.Count > 0 && FTPModels != null))
            {
               bool result =  ABC(FTPModels);
             
            }
        


            return true;
        }

        /// <summary>
        /// 待上传文件进入队列
        /// </summary>
        /// <param name="fileInfo"></param>
        private void InsertQeue(FileInfo fileInfo,string targetPath)
        {
            FTPModel model = new FTPModel()
            {
                Name = fileInfo.Name,
                LocalPath = fileInfo.FullName,
                LSize = fileInfo.Length,
                FileAppend = false,
                RFullName = targetPath,
                State = gisqSceneImportState.NoImport.ToString(),
            };
            FTPModels.Enqueue(model);
        }

        private bool ABC (Queue<FTPModel> fTPModels)
        {
            var model = FTPModels.Peek();
            float percent = 0;
            string localPath = model.LocalPath;
            string targetPath = model.RFullName;
            FileInfo fileInfo = new FileInfo(localPath);
            localPath = localPath.Replace("\\", "/");

            string path = FTPCONSTR + "/" + targetPath + "/" + fileInfo.Name;
            //1是否有这个目录
          //  bool exist = RemoteFtpDirExists(targetPath);
         //   if (!exist) CreateDirectory(targetPath);

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
              //  LogHelper.Info($"三维数据【{fileInfo.Name}】上传中，请等待....");
                Stream strm = reqFtp.GetRequestStream();
                contentLen = fileStream.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    startbye = contentLen + startbye;

                    contentLen = fileStream.Read(buff, 0, buffLength);
                    percent = (float)startbye / (float)allbye * 100;
                }
                strm.Close();
                fileStream.Close();

                return true;
            }
            catch
            {
                return false;
            };
        }

        private bool UploadFile(string localPath, string targetPath, ProgressBarControl pb)
        {
            return true;
            //float percent = 0;
            //FileInfo fileInfo = new FileInfo(localPath);
            //localPath = localPath.Replace("\\", "/");

            //string path = FTPCONSTR + "/" + targetPath + "/" + fileInfo.Name;
            ////1是否有这个目录
            //bool exist = RemoteFtpDirExists(targetPath);
            //if (!exist) CreateDirectory(targetPath);

            //LogHelper.Info($"开始执行三维数据【{fileInfo.Name}】上传...");
            //FtpWebRequest reqFtp = (FtpWebRequest)WebRequest.Create(new Uri(path));
            //reqFtp.UseBinary = true;
            //reqFtp.Credentials = new NetworkCredential(FTPUserName, FTPPassWord);
            //reqFtp.KeepAlive = false;
            //reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
            //reqFtp.ContentLength = fileInfo.Length;
            //int buffLength = 2048;
            //byte[] buff = new byte[buffLength];
            //int contentLen;
            //FileStream fileStream = fileInfo.OpenRead();
            //int allbye = (int)fileInfo.Length;
            //if (pb != null)
            //{
            //    pb.Properties.Maximum = allbye;

            //}
            //int startbye = 0;
            //return ActionHelper.Invoke(() =>
            //{
            //    LogHelper.Info($"三维数据【{fileInfo.Name}】上传中，请等待....");
            //    Stream strm = reqFtp.GetRequestStream();
            //    contentLen = fileStream.Read(buff, 0, buffLength);
            //    while (contentLen != 0)
            //    {
            //        strm.Write(buff, 0, contentLen);
            //        startbye = contentLen + startbye;
            //        if (pb != null)
            //        {
            //            pb.Position = (int)startbye;
            //        }
            //        contentLen = fileStream.Read(buff, 0, buffLength);
            //        percent = (float)startbye / (float)allbye * 100;
            //    }
            //    strm.Close();
            //    fileStream.Close();
            //    LogHelper.Info($"三维数据【{fileInfo.Name}】上传成功！");
            //    return true;
            //},
            //(ex) =>
            //{
            //    LogHelper.Error(ex, "三维数据上传到FTP服务器失败！");
            //    return false;
            //});
        }










        /// <summary>
        /// 根据文件名获取是否是续传和续传的下次开始节点
        /// </summary>
        /// <param name="md5str"></param>
        /// <param name="fileextname"></param>
        /// <returns></returns>
        private int isResume(string localPath, string targetPath,string md5str, string fileextname)
        {
            FileInfo fileInfo = new FileInfo(localPath);
            localPath = localPath.Replace("\\", "/");
            string path = FTPCONSTR + "/" + targetPath + "?md5str=" + md5str + fileInfo.Name;
            FtpWebRequest reqFtp = (FtpWebRequest)WebRequest.Create(new Uri(path));
            reqFtp.UseBinary = true;
            reqFtp.Credentials = new NetworkCredential(FTPUserName, FTPPassWord);
            reqFtp.KeepAlive = false;
            reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
            reqFtp.ContentLength = fileInfo.Length;
            WebClient WebClientObj = new WebClient();
            var url = "http://localhost:13174/api/file/GetResumFile?md5str=" + md5str + fileextname;
            byte[] byRemoteInfo = WebClientObj.DownloadData(url);
            string result = Encoding.UTF8.GetString(byRemoteInfo);
            if (string.IsNullOrEmpty(result))
            {
                return 0;
            }
            return Convert.ToInt32(result);
        }

        public string UpLoadFile(string localPath, string targetPath)
        {
            return "";
            ////string tmpURL = hostURL;
            ////byteCount = byteCount * 1024;

            //FileInfo fileInfo = new FileInfo(localPath);

            //FileStream fStream = new FileStream(localPath, FileMode.Open, FileAccess.Read);
            //var mdfstr = GetStreamMd5(fStream);
            //fStream.Close();
            //var startpoint = isResume(localPath,targetPath,mdfstr, Path.GetExtension(localPath));

            //System.Net.WebClient WebClientObj = new System.Net.WebClient();
            //FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);


            //BinaryReader bReader = new BinaryReader(fStream);
            //long length = fStream.Length;
            //string sMsg = "上传成功";
            //string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);
            //try
            //{

            //    #region 续传处理
            //    byte[] data;
            //    if (cruuent > 0)
            //    {
            //        fStream.Seek(cruuent, SeekOrigin.Current);
            //    }
            //    #endregion

            //    #region 分割文件上传
            //    for (; cruuent <= length; cruuent = cruuent + byteCount)
            //    {
            //        if (cruuent + byteCount > length)
            //        {
            //            data = new byte[Convert.ToInt64((length - cruuent))];
            //            bReader.Read(data, 0, Convert.ToInt32((length - cruuent)));
            //        }
            //        else
            //        {
            //            data = new byte[byteCount];
            //            bReader.Read(data, 0, byteCount);
            //        }

            //        try
            //        {


            //            //***                        bytes 21010-47021/47022
            //            WebClientObj.Headers.Remove(HttpRequestHeader.ContentRange);
            //            WebClientObj.Headers.Add(HttpRequestHeader.ContentRange, "bytes " + cruuent + "-" + (cruuent + byteCount) + "/" + fStream.Length);

            //            hostURL = tmpURL + "?filename=" + mdfstr + Path.GetExtension(fileName);
            //            byte[] byRemoteInfo = WebClientObj.UploadData(hostURL, "POST", data);
            //            string sRemoteInfo = System.Text.Encoding.Default.GetString(byRemoteInfo);

            //            //  获取返回信息
            //            if (sRemoteInfo.Trim() != "")
            //            {
            //                sMsg = sRemoteInfo;
            //                break;

            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            sMsg = ex.ToString();
            //            break;
            //        }
            //        #endregion

            //    }
            //}
            //catch (Exception ex)
            //{
            //    sMsg = sMsg + ex.ToString();
            //}
            //try
            //{
            //    bReader.Close();
            //    fStream.Close();
            //}
            //catch (Exception exMsg)
            //{
            //    sMsg = exMsg.ToString();
            //}

            //GC.Collect();
            //return sMsg;
        }
        public static string GetStreamMd5(Stream stream)
        {
            var oMd5Hasher = new MD5CryptoServiceProvider();
            byte[] arrbytHashValue = oMd5Hasher.ComputeHash(stream);
            //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”
            string strHashData = BitConverter.ToString(arrbytHashValue);
            //替换-
            strHashData = strHashData.Replace("-", "");
            string strResult = strHashData;
            return strResult;
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
            else
            {
              //  bool isLegal = RegularHelper.ValidatePort(port);
              //  if (!isLegal)
               // {
                   // MsgHelper.ShowAlterMessage("不合理的端口号！", "温馨提示");
                    return false;
               // }
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
        private bool HandelMatchFile(LoadFileEventArgs args)
        {
           bool res = true;
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

        private Tuple<int, int> CompareFileSize(LoadFileEventArgs args)
        {
            //String content = GetFileSize(args.Src);
            //if (String.IsNullOrEmpty(content))
            //    return new Tuple<int, int>(1, 0);

            ////匹配已上传文件的大小
            //Regex regex = new Regex(@"^-.+?\sftp.+?\s+(?<size>\d+)", RegexOptions.IgnoreCase);
            //Match match = regex.Match(content);
            //if (match.Success)
            //{
            //    int fileSize = Convert.ToInt32(match.Groups["size"].Value);
            //    if (fileSize < args.DesSize)
            //        return new Tuple<int, int>(2, fileSize);

            //    return new Tuple<int, int>(3, fileSize);
            //}

            return new Tuple<int, int>(2, 0);
        }

        /// <summary>
        /// 获取已上传文件大小
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <param name="remotePath">服务器文件路径</param>
        /// <returns></returns>
        public long GetFileSize(string filename, string remotePath)
        {
            long filesize = 0;
            try
            {
                string path = FTPCONSTR + "/" + remotePath + "/" + filename;
                var reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(path));
                reqFTP.KeepAlive = false;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(FTPUserName, FTPPassWord);
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                filesize = response.ContentLength;
                return filesize;
            }
           catch
            {
               return 0;
            };
        }
    }
}
