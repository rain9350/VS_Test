using DevExpress.XtraEditors;
using DevExpress.XtraWizard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class XtraForm_Wizard : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm_Wizard()
        {
            InitializeComponent();
        }

        //界面跳转
        private void wizardControl1_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            string a = textEdit3.Text;

            if (e.Page == wizardPage1 && e.Direction == Direction.Forward)
            {
            }
            if(e.Page == wizardPage2 && e.Direction == Direction.Forward)
            {
                if (a == "个人科研人员" || a == "企业团队")
                    e.Page = completionWizardPage1;
                else if (a == "研发处理" || a == "黑白用户")
                   { }
                    else
                        {
                       MessageBox.Show("请输入正确的用户类别");
                       e.Page = wizardPage1;
                }

            }
            
            if (e.Page == wizardPage2 && e.Direction == Direction.Backward && a == "个人科研人员")
                e.Page = wizardPage1;
            if (e.Page == wizardPage2 && e.Direction == Direction.Backward && a == "企业团队")
                e.Page = wizardPage1;
        }

        //Next事件
        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (this.textEdit1.Text.Length == 0 || this.textEdit2.Text.Length == 0)
            {
                MessageBox.Show("请输入邮箱/电话，并设置密码");
                e.Handled = true;
               // return; 
            }

            int currentindex = this.wizardControl1.SelectedPageIndex;

            
        }

        
    }
}