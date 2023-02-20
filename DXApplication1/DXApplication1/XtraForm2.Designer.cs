namespace DXApplication1
{
    partial class XtraForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraForm2));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Add_Menultem = new System.Windows.Forms.ToolStripMenuItem();
            this.Del_Menultem = new System.Windows.Forms.ToolStripMenuItem();
            this.Refresh_Menultem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCollapse = new System.Windows.Forms.ToolStripMenuItem();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.treeListLookUpEdit1 = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.navigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.navigationPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeList1.Font = new System.Drawing.Font("华文楷体", 7.799999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeList1.Location = new System.Drawing.Point(33, 12);
            this.treeList1.LookAndFeel.SkinMaskColor = System.Drawing.Color.Yellow;
            this.treeList1.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.DarkOrange;
            this.treeList1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsMenu.ShowExpandCollapseItems = false;
            this.treeList1.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.Default;
            this.treeList1.Size = new System.Drawing.Size(300, 449);
            this.treeList1.TabIndex = 0;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AllowDrop = true;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Add_Menultem,
            this.Del_Menultem,
            this.Refresh_Menultem,
            this.BtnExpandAll,
            this.BtnCollapse});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 124);
            // 
            // Add_Menultem
            // 
            this.Add_Menultem.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Add_Menultem.Name = "Add_Menultem";
            this.Add_Menultem.Size = new System.Drawing.Size(104, 24);
            this.Add_Menultem.Text = "新增";
            this.Add_Menultem.Click += new System.EventHandler(this.Add_Menultem_Click);
            // 
            // Del_Menultem
            // 
            this.Del_Menultem.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Del_Menultem.Name = "Del_Menultem";
            this.Del_Menultem.Size = new System.Drawing.Size(104, 24);
            this.Del_Menultem.Text = "删除";
            this.Del_Menultem.Click += new System.EventHandler(this.Del_Menultem_Click);
            // 
            // Refresh_Menultem
            // 
            this.Refresh_Menultem.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Refresh_Menultem.Name = "Refresh_Menultem";
            this.Refresh_Menultem.Size = new System.Drawing.Size(104, 24);
            this.Refresh_Menultem.Text = "刷新";
            // 
            // BtnExpandAll
            // 
            this.BtnExpandAll.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExpandAll.Name = "BtnExpandAll";
            this.BtnExpandAll.Size = new System.Drawing.Size(104, 24);
            this.BtnExpandAll.Text = "展开";
            this.BtnExpandAll.Click += new System.EventHandler(this.BtnExpandAll_Click);
            // 
            // BtnCollapse
            // 
            this.BtnCollapse.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCollapse.Name = "BtnCollapse";
            this.BtnCollapse.Size = new System.Drawing.Size(104, 24);
            this.BtnCollapse.Text = "收缩";
            this.BtnCollapse.Click += new System.EventHandler(this.BtnCollapse_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(670, 63);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(125, 24);
            this.textEdit1.TabIndex = 1;
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPage1);
            this.navigationFrame1.Controls.Add(this.navigationPage2);
            this.navigationFrame1.Location = new System.Drawing.Point(339, 132);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage1,
            this.navigationPage2});
            this.navigationFrame1.SelectedPage = this.navigationPage1;
            this.navigationFrame1.Size = new System.Drawing.Size(283, 160);
            this.navigationFrame1.TabIndex = 2;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPage1
            // 
            this.navigationPage1.AllowTouchScroll = true;
            this.navigationPage1.Appearance.Options.UseImage = true;
            this.navigationPage1.Caption = "navigationPage1";
            this.navigationPage1.Controls.Add(this.pictureEdit1);
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(283, 160);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(39, 28);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(203, 96);
            this.pictureEdit1.TabIndex = 0;
            // 
            // navigationPage2
            // 
            this.navigationPage2.Caption = "navigationPage2";
            this.navigationPage2.Controls.Add(this.pictureEdit2);
            this.navigationPage2.Name = "navigationPage2";
            this.navigationPage2.Size = new System.Drawing.Size(283, 160);
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = ((object)(resources.GetObject("pictureEdit2.EditValue")));
            this.pictureEdit2.Location = new System.Drawing.Point(43, 16);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit2.Size = new System.Drawing.Size(188, 126);
            this.pictureEdit2.TabIndex = 0;
            // 
            // treeListLookUpEdit1
            // 
            this.treeListLookUpEdit1.Location = new System.Drawing.Point(378, 317);
            this.treeListLookUpEdit1.Name = "treeListLookUpEdit1";
            this.treeListLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.treeListLookUpEdit1.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.treeListLookUpEdit1.Size = new System.Drawing.Size(226, 24);
            this.treeListLookUpEdit1.TabIndex = 3;
            this.treeListLookUpEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.treeListLookUpEdit1_ButtonClick);
            this.treeListLookUpEdit1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeListLookUpEdit1_MouseDown);
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(682, 259);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Columns = 2;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "打开大门", true, null, "开门"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "关闭大门", true, null, "关门")});
            this.radioGroup1.Size = new System.Drawing.Size(213, 96);
            this.radioGroup1.TabIndex = 4;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(733, 152);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(94, 29);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(722, 391);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // XtraForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 473);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.treeListLookUpEdit1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.navigationFrame1);
            this.Name = "XtraForm2";
            this.Text = "XtraForm2";
            this.Load += new System.EventHandler(this.XtraForm2_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XtraForm2_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.navigationPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.navigationPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Add_Menultem;
        private System.Windows.Forms.ToolStripMenuItem Del_Menultem;
        private System.Windows.Forms.ToolStripMenuItem Refresh_Menultem;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.TreeListLookUpEdit treeListLookUpEdit1;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ToolStripMenuItem BtnExpandAll;
        private System.Windows.Forms.ToolStripMenuItem BtnCollapse;
        private System.Windows.Forms.Button btnTest;
    }
}