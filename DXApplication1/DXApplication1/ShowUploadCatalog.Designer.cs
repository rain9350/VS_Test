namespace DXApplication1
{
    partial class ShowUploadCatalog
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Size = new DevExpress.XtraGrid.Columns.GridColumn();
            this.State = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Progress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(279, 570);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FileName,
            this.Size,
            this.State,
            this.Progress});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsHint.ShowColumnHeaderHints = false;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // FileName
            // 
            this.FileName.Caption = "文件名称";
            this.FileName.FieldName = "Name";
            this.FileName.MinWidth = 25;
            this.FileName.Name = "FileName";
            this.FileName.Visible = true;
            this.FileName.VisibleIndex = 0;
            this.FileName.Width = 94;
            // 
            // Size
            // 
            this.Size.Caption = "文件大小";
            this.Size.FieldName = "LSize";
            this.Size.MinWidth = 25;
            this.Size.Name = "Size";
            this.Size.Visible = true;
            this.Size.VisibleIndex = 1;
            this.Size.Width = 94;
            // 
            // State
            // 
            this.State.Caption = "状态";
            this.State.FieldName = "State";
            this.State.MinWidth = 25;
            this.State.Name = "State";
            this.State.Visible = true;
            this.State.VisibleIndex = 2;
            this.State.Width = 94;
            // 
            // Progress
            // 
            this.Progress.Caption = "上传进度条";
            this.Progress.FieldName = "Percent";
            this.Progress.MinWidth = 25;
            this.Progress.Name = "Progress";
            this.Progress.Visible = true;
            this.Progress.VisibleIndex = 3;
            this.Progress.Width = 94;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOK.Location = new System.Drawing.Point(79, 523);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(197, 44);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "上传";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowUploadCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gridControl1);
            this.Name = "ShowUploadCatalog";
           // this.Size = new System.Drawing.Size(279, 570);
            //this.Load += new System.EventHandler(this.ShowUploadCatalog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnOK;
        private DevExpress.XtraGrid.Columns.GridColumn FileName;
        private DevExpress.XtraGrid.Columns.GridColumn Size;
        private DevExpress.XtraGrid.Columns.GridColumn State;
        private DevExpress.XtraGrid.Columns.GridColumn Progress;
    }
}
