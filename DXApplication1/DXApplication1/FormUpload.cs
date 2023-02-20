using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace DXApplication1
{
    public partial class FormUpload : Form
    {
        public FormUpload()
        {
            InitializeComponent();
        }

        private void FormUpload_Load(object sender, EventArgs e)
        {
            this.progressBarControl.Properties.ShowTitle = true;
            this.progressBarControl.Properties.PercentView = true;
            this.progressBarControl.Properties.Minimum = 0;
        }

        private void txtLocalData_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtLocalData_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                this.txtLocalData.EditValue = null;
                this.txtLocalData.Text = null;
            }
            else if (e.Button.Index == 1)
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                if (folderBrowser.ShowDialog() != DialogResult.OK) return;
                this.txtLocalData.EditValue = folderBrowser.SelectedPath;
                //XtraFolderBrowserDialog dialog = new XtraFolderBrowserDialog
                //{
                //    Title = $"请选择【】数据目录",
                //    DialogStyle = DevExpress.Utils.CommonDialogs.FolderBrowserDialogStyle.Wide,
                //};
                //if (dialog.ShowDialog() != DialogResult.OK) return;
                //this.txtLocalData.EditValue = dialog.SelectedPath;
                //OpenFileDialog dialog = new OpenFileDialog
                //{
                //    Title = "请选择数据",
                //    Filter = "激光点云(*.las)|*.las|人工模型(*.fbx)|*.fbx"

                //};
                //if (dialog.ShowDialog() != DialogResult.OK) return;
                //this.txtLocalData.EditValue = dialog.FileName;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            if (txtLocalData.EditValue.ToString() == null) return;

            string ip = "192.168.99.248";
            string port = "30";
            string username = "demo";
            string pasword = "demo";
            string targetPath = "kidnap";

            this.showUploadCatalog1.Initialize(ip, username, pasword, txtLocalData.EditValue.ToString(), targetPath, port);
        }

    }
}
