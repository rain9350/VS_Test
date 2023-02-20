using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    /// <summary>
    /// FTP上传模模板信息
    /// </summary>
    public class FTPModel
    {
        /// <summary>
        /// 待上传文件文件名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 待上传文件本地全路径
        /// </summary>
        public string LocalPath { get; set; }

        /// <summary>
        /// 待上传文件FTP服务器下相对路径
        /// </summary>
        public string RFullName { get; set; }

        /// <summary>   
        /// 待上传文件大小
        /// </summary>
        public long LSize { get; set; }

        /// <summary>
        /// 待上传文件FTP服务器下文件大小
        /// </summary>
        public long RSize { get; set; }

        /// <summary>文件是否需要断点续传</summary>
        public bool FileAppend { get; set; }

        /// <summary>该文件需要压缩</summary>
        public bool NeedZipFile { get; set; }

        /// <summary>该文件太大需要分段压缩</summary>
        public bool NeedSubZipFile { get; set; }

        /// <summary>
        /// 文件上传状态
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 文件上传百分比
        /// </summary>
        public string Percent { get; set; }
    }
}
