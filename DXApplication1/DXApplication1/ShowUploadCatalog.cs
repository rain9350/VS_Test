using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class ShowUploadCatalog : UserControl
    {
        /// <summary>
        /// 文件上传参数
        /// </summary>
        public Queue<FTPModel> models;

        public FTPLast fTP = new FTPLast();

        public ShowUploadCatalog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="port"></param>
        /// <param name="localPath"></param>
        /// <param name="targetPath"></param>
        public void Initialize(string ip, string username, string password, string localPath, string targetPath, string port = "21")
        {
            bool result = fTP.SetFTPImformation(ip, username, password, port);
            if (result)
            {
                fTP.ShowUploadFile(localPath, targetPath);
            }
            fTP.FTPModelFactory += AfterUpload;
        }

        private Queue<FTPModel> AfterUpload(Queue<FTPModel> fTPModels)
        {
            this.models = fTPModels;
            return fTPModels;

            if(InvokeRequired)
            {
                INotifyPropertyChanged
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fTP.FTPModelFactory += ReFlashData;
            if (models.Count < 1 || models == null) return;
            foreach (FTPModel model in models)
            {
                bool result = fTP.UploadFile(model);
                if (!result) continue;
            }
            Thread testclassThread = new Thread(new ThreadStart(fTP.TimeFunction));
            testclassThread.Start();
        }

        private Queue<FTPModel> ReFlashData(Queue<FTPModel> fTPModels)
        {
            this.models = fTPModels;
            this.gridControl1.RefreshDataSource();
            this.gridControl1.Refresh();
            return fTPModels;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.Name == "Propgress")
            {
                double warningValue = 60;
                Brush beforeWaringValueColor = null;
                Brush afterWaringValueColor = null;
                DrawProgressBar(e, warningValue, beforeWaringValueColor, afterWaringValueColor);
                e.Handled = true;
                DrawEditor(e);
            }
        }
        /// <summary>
        /// 给指定列绘制进度条
        /// </summary>
        /// <param name="gridView">GridView控件</param>
        /// <param name="columnFieldName">需绘制进度条列的字段名称</param>
        /// <param name="warningValue">警告值（用于区分不同的颜色）</param>
        /// <param name="beforeWaringValueColor">警告值前的进度条颜色</param>
        /// <param name="afterWaringValueColor">警告值后的进度条颜色</param>
        public static void DrawProgressBarToColumn(DevExpress.XtraGrid.Views.Grid.GridView gridView, string columnFieldName,
            double warningValue = 60, Brush beforeWaringValueColor = null, Brush afterWaringValueColor = null)
        {
            var column = gridView.Columns[columnFieldName];
            if (column == null) return;
            column.AppearanceCell.Options.UseTextOptions = true;
            //设置该列显示文本内容的位置（这里默认居中）
            column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            //绘制事件方法(前提需要先注册才能够接收到参数使用)
            gridView.CustomDrawCell += (s, e) =>
            {
                if (e.Column.FieldName == columnFieldName)
                {
                    DrawProgressBar(e, warningValue, beforeWaringValueColor, afterWaringValueColor);
                    e.Handled = true;
                    DrawEditor(e);
                }
            };
        }

        /// <summary>
        /// 绘制进度条
        /// </summary>
        /// <param name="e">单元格绘制事件参数</param>
        /// <param name="warningValue">警告值（用于区分不同的颜色）</param>
        /// <param name="beforeWaringValueColor">警告值前的进度条颜色</param>
        /// <param name="afterWaringValueColor">警告值后的进度条颜色</param>
        public static void DrawProgressBar(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e, double warningValue = 60,
            Brush beforeWaringValueColor = null, Brush afterWaringValueColor = null)
        {
            string tmpValue = e.CellValue.ToString();
            float percent = 0;
            if (!string.IsNullOrEmpty(tmpValue))
            {
                float.TryParse(tmpValue, out percent);
            }
            int width = 0;
            if (percent > 2)
            {
                width = (int)(Math.Abs(percent / 100) * e.Bounds.Width);
            }
            else
            {
                width = (int)(Math.Abs(percent) * e.Bounds.Width);
            }

            Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, width, e.Bounds.Height);

            Brush b = Brushes.Green;
            if (afterWaringValueColor != null)
            {
                b = afterWaringValueColor;
            }
            if (percent < warningValue)
            {
                if (beforeWaringValueColor == null)
                {
                    b = Brushes.Red;
                }
                else
                {
                    b = beforeWaringValueColor;
                }
            }
            e.Graphics.FillRectangle(b, rect);
        }

        /// <summary>
        /// 绘制单元格
        /// </summary>
        /// <param name="e">单元格绘制事件参数</param>
        public static void DrawEditor(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo cell = e.Cell as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo;
            Point offset = cell.CellValueRect.Location;
            DevExpress.XtraEditors.Drawing.BaseEditPainter pb = cell.ViewInfo.Painter as DevExpress.XtraEditors.Drawing.BaseEditPainter;
            AppearanceObject style = cell.ViewInfo.PaintAppearance;
            if (!offset.IsEmpty)
                cell.ViewInfo.Offset(offset.X, offset.Y);
            try
            {
                pb.Draw(new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(cell.ViewInfo, e.Cache, cell.Bounds));
            }
            finally
            {
                if (!offset.IsEmpty)
                {
                    cell.ViewInfo.Offset(-offset.X, -offset.Y);
                }
            }
        }

        //private void ShowUploadCatalog_Load(object sender, EventArgs e)
        //{
        //    if (models.Count < 1 || models == null) return;
        //    this.gridControl1.DataSource = models;
        //}
    }
}
