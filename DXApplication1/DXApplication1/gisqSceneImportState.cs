using System.ComponentModel;

namespace DXApplication1
{
    /// <summary>
    /// 三维数据入库状态
    /// </summary>
    public enum gisqSceneImportState
    {
        /// <summary>
        /// 三维数据未入库
        /// </summary>
        [Description("三维数据未入库")]
        NoImport,

        /// <summary>
        /// 三维数据入库中
        /// </summary>
        [Description("三维数据入库中")]
        Importing,

        /// <summary>
        /// 三维数据已入库
        /// </summary>
        [Description("三维数据已入库")]
        Imported
    }
}
