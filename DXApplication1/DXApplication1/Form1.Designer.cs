namespace DXApplication1
{
    partial class Form1
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Student_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Major_Class = new DevExpress.XtraGrid.Columns.GridColumn();
            this.City = new DevExpress.XtraGrid.Columns.GridColumn();
            this.删除 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChooseDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.AddData = new DevExpress.XtraEditors.SimpleButton();
            this.Add = new DevExpress.XtraEditors.SimpleButton();
            this.Save_Update = new DevExpress.XtraEditors.SimpleButton();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChooseDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            gridLevelNode1.LevelTemplate = this.cardView1;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(79, 100);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ChooseDelete});
            this.gridControl1.Size = new System.Drawing.Size(892, 357);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.cardView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Student_Id,
            this.Name,
            this.Major_Class,
            this.City,
            this.删除});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // Student_Id
            // 
            this.Student_Id.Caption = "学生ID";
            this.Student_Id.FieldName = "Student_ID";
            this.Student_Id.MinWidth = 25;
            this.Student_Id.Name = "Student_Id";
            this.Student_Id.Visible = true;
            this.Student_Id.VisibleIndex = 0;
            this.Student_Id.Width = 94;
            // 
            // Name
            // 
            this.Name.Caption = "姓名";
            this.Name.FieldName = "Name";
            this.Name.MinWidth = 25;
            this.Name.Name = "Name";
            this.Name.Visible = true;
            this.Name.VisibleIndex = 1;
            this.Name.Width = 94;
            // 
            // Major_Class
            // 
            this.Major_Class.Caption = "主修科目";
            this.Major_Class.FieldName = "Major_Class";
            this.Major_Class.MinWidth = 25;
            this.Major_Class.Name = "Major_Class";
            this.Major_Class.Visible = true;
            this.Major_Class.VisibleIndex = 2;
            this.Major_Class.Width = 94;
            // 
            // City
            // 
            this.City.Caption = "城市";
            this.City.FieldName = "City";
            this.City.MinWidth = 25;
            this.City.Name = "City";
            this.City.Visible = true;
            this.City.VisibleIndex = 3;
            this.City.Width = 94;
            // 
            // 删除
            // 
            this.删除.Caption = "Delete";
            this.删除.ColumnEdit = this.ChooseDelete;
            this.删除.FieldName = "Delete";
            this.删除.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("删除.ImageOptions.Image")));
            this.删除.MinWidth = 25;
            this.删除.Name = "删除";
            this.删除.Visible = true;
            this.删除.VisibleIndex = 4;
            this.删除.Width = 94;
            // 
            // ChooseDelete
            // 
            this.ChooseDelete.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ChooseDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.ChooseDelete.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ChooseDelete.ContextImageOptions.Image")));
            this.ChooseDelete.Name = "ChooseDelete";
            this.ChooseDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.ChooseDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ChooseDelete_ButtonClick);
            // 
            // AddData
            // 
            this.AddData.Location = new System.Drawing.Point(79, 56);
            this.AddData.Name = "AddData";
            this.AddData.Size = new System.Drawing.Size(94, 29);
            this.AddData.TabIndex = 6;
            this.AddData.Text = "添加数据";
            this.AddData.Click += new System.EventHandler(this.AddData_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(197, 56);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(94, 29);
            this.Add.TabIndex = 8;
            this.Add.Text = "新增空白行";
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Save_Update
            // 
            this.Save_Update.Location = new System.Drawing.Point(326, 55);
            this.Save_Update.Name = "Save_Update";
            this.Save_Update.Size = new System.Drawing.Size(116, 29);
            this.Save_Update.TabIndex = 10;
            this.Save_Update.Text = "保存更新数据库";
            this.Save_Update.Click += new System.EventHandler(this.Save_Update_Click);
            // 
            // cardView1
            // 
            this.cardView1.GridControl = this.gridControl1;
            this.cardView1.Name = "cardView1";
            // 
            // Form1
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 482);
            this.Controls.Add(this.Save_Update);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.AddData);
            this.Controls.Add(this.gridControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
      //      this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChooseDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Student_Id;
        private DevExpress.XtraGrid.Columns.GridColumn Name;
        private DevExpress.XtraGrid.Columns.GridColumn Major_Class;
        private DevExpress.XtraGrid.Columns.GridColumn City;
        private DevExpress.XtraEditors.SimpleButton AddData;
        private DevExpress.XtraGrid.Columns.GridColumn 删除;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ChooseDelete;
        private DevExpress.XtraEditors.SimpleButton Add;
        private DevExpress.XtraEditors.SimpleButton Save_Update;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
    }
}

