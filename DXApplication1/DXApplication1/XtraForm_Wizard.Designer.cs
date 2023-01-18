namespace DXApplication1
{
    partial class XtraForm_Wizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraForm_Wizard));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit3 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.welcomeWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.AllowPagePadding = false;
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage2);
            this.wizardControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.HeaderImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("wizardControl1.HeaderImageOptions.Image")));
            this.wizardControl1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("wizardControl1.ImageOptions.Image")));
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.wizardPage2,
            this.completionWizardPage1});
            this.wizardControl1.Size = new System.Drawing.Size(689, 497);
            this.wizardControl1.Text = "111";
            this.wizardControl1.SelectedPageChanging += new DevExpress.XtraWizard.WizardPageChangingEventHandler(this.wizardControl1_SelectedPageChanging);
            this.wizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_NextClick);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Controls.Add(this.textEdit2);
            this.welcomeWizardPage1.Controls.Add(this.labelControl2);
            this.welcomeWizardPage1.Controls.Add(this.textEdit1);
            this.welcomeWizardPage1.Controls.Add(this.labelControl1);
            this.welcomeWizardPage1.IntroductionText = "请输入邮箱（或者电话）、和你想要设置的密码";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "继续下一步，请单击“Next”";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(504, 352);
            this.welcomeWizardPage1.Text = "账号注册";
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(182, 195);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(162, 24);
            this.textEdit2.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(95, 198);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "密码：";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new System.Drawing.Point(182, 107);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(162, 24);
            this.textEdit1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(53, 107);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(110, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "邮箱/电话 ：";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.labelControl3);
            this.wizardPage1.Controls.Add(this.textEdit3);
            this.wizardPage1.DescriptionText = "将根据不同用户类别添加设置不同的权限和功能";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(689, 359);
            this.wizardPage1.Text = "选择创建用户类别";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Snow;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("黑体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(65, 127);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(125, 23);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "用户类别：";
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(208, 129);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.True;
            this.textEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEdit3.Properties.Items.AddRange(new object[] {
            "个人科研人员",
            "企业团队",
            "研发处理",
            "黑白用户"});
            this.textEdit3.Size = new System.Drawing.Size(125, 24);
            this.textEdit3.TabIndex = 1;
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(504, 353);
            // 
            // wizardPage2
            // 
            this.wizardPage2.DescriptionText = "请输入你对应功能的个人ID";
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(689, 359);
            this.wizardPage2.Text = "功能密钥";
            // 
            // XtraForm_Wizard
            // 
            this.ActiveGlowColor = System.Drawing.Color.PeachPuff;
            this.Appearance.BackColor = System.Drawing.Color.OldLace;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 497);
            this.Controls.Add(this.wizardControl1);
            this.HtmlText = "www";
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("XtraForm_Wizard.IconOptions.Image")));
            this.InactiveGlowColor = System.Drawing.Color.Bisque;
            this.Name = "XtraForm_Wizard";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.welcomeWizardPage1.ResumeLayout(false);
            this.welcomeWizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        protected DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit textEdit3;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
    }
}