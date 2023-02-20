namespace DXApplication1
{
    partial class FormUpload
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpload));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.txtLocalData = new DevExpress.XtraEditors.ButtonEdit();
            this.btnUP = new DevExpress.XtraEditors.SimpleButton();
            this.btnStop = new DevExpress.XtraEditors.SimpleButton();
            this.btnCtn = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this.showUploadCatalog1 = new DXApplication1.ShowUploadCatalog();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLocalData
            // 
            this.txtLocalData.Location = new System.Drawing.Point(135, 172);
            this.txtLocalData.Margin = new System.Windows.Forms.Padding(5);
            this.txtLocalData.Name = "txtLocalData";
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.txtLocalData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtLocalData.Size = new System.Drawing.Size(564, 26);
            this.txtLocalData.TabIndex = 16;
            this.txtLocalData.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtLocalData_ButtonClick);
            this.txtLocalData.EditValueChanged += new System.EventHandler(this.txtLocalData_EditValueChanged);
            // 
            // btnUP
            // 
            this.btnUP.Location = new System.Drawing.Point(154, 116);
            this.btnUP.Margin = new System.Windows.Forms.Padding(4);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(94, 29);
            this.btnUP.TabIndex = 17;
            this.btnUP.Text = "上传";
            this.btnUP.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(292, 116);
            this.btnStop.Margin = new System.Windows.Forms.Padding(5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(118, 36);
            this.btnStop.TabIndex = 18;
            this.btnStop.Text = "暂停";
            // 
            // btnCtn
            // 
            this.btnCtn.Location = new System.Drawing.Point(479, 116);
            this.btnCtn.Margin = new System.Windows.Forms.Padding(6);
            this.btnCtn.Name = "btnCtn";
            this.btnCtn.Size = new System.Drawing.Size(148, 45);
            this.btnCtn.TabIndex = 19;
            this.btnCtn.Text = "继续";
            this.btnCtn.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // progressBarControl
            // 
            this.progressBarControl.Location = new System.Drawing.Point(79, 510);
            this.progressBarControl.Margin = new System.Windows.Forms.Padding(4);
            this.progressBarControl.Name = "progressBarControl";
            this.progressBarControl.Size = new System.Drawing.Size(656, 22);
            this.progressBarControl.TabIndex = 20;
            // 
            // showUploadCatalog1
            // 
            this.showUploadCatalog1.AutoSize = true;
            this.showUploadCatalog1.Location = new System.Drawing.Point(831, 68);
            this.showUploadCatalog1.Name = "showUploadCatalog1";
            this.showUploadCatalog1.Size = new System.Drawing.Size(715, 570);
            this.showUploadCatalog1.TabIndex = 21;
            // 
            // FormUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1638, 760);
            this.Controls.Add(this.showUploadCatalog1);
            this.Controls.Add(this.progressBarControl);
            this.Controls.Add(this.btnCtn);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnUP);
            this.Controls.Add(this.txtLocalData);
            this.Name = "FormUpload";
            this.Text = "FormUpload";
            this.Load += new System.EventHandler(this.FormUpload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit txtLocalData;
        private DevExpress.XtraEditors.SimpleButton btnUP;
        private DevExpress.XtraEditors.SimpleButton btnStop;
        private DevExpress.XtraEditors.SimpleButton btnCtn;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl;
        private ShowUploadCatalog showUploadCatalog1;
    }
}