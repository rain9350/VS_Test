using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using FreeSql;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DXApplication1
{
    public partial class XtraForm2 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm2()
        {
            InitializeComponent();
            InitialzeTreeComponent();
        }
        
        //定义IFreeSql接口 链接数据库
       public IFreeSql freeSql = new FreeSqlBuilder()
              .UseConnectionString(FreeSql.DataType.PostgreSQL, @"Host=localhost;Port=5432;Username=sde;Password=weiyouhou; Database=Test;Pooling=true;Minimum Pool Size=1")
              .UseAutoSyncStructure(true)
              .Build();
        BarManager barManager = new BarManager();
        PopupMenu menu = new PopupMenu();
        //新建Zoom类
        [Table(Name = "Zoom")]
        public class Zoom
        {
            [Column(IsIdentity = true ,IsPrimary = true)]
            public int Zoom_Id { get; set; }
            public int ParentId { get; set; }
            public string Zoom_Name { get; set; }
        }

        //初始化treelist
        private void InitialzeTreeComponent()
        {
            List<Zoom> list = new List<Zoom>();
            string firstLevel = Guid.NewGuid().ToString();
            string secondLevel = Guid.NewGuid().ToString();
            string thirdLevel = Guid.NewGuid().ToString();

            list.Add(new Zoom { Zoom_Id = 1, ParentId = 1, Zoom_Name = "一级保护动物" });
            list.Add(new Zoom { Zoom_Id = 2, ParentId = 1, Zoom_Name = "熊猫" });
            list.Add(new Zoom { Zoom_Id = 3, ParentId = 1, Zoom_Name = "狮子" });
            list.Add(new Zoom { Zoom_Id = 4, ParentId = 1, Zoom_Name = "玻璃章鱼" });

            list.Add(new Zoom { Zoom_Id = 5, ParentId = 5, Zoom_Name = "一级保护植物" });
            list.Add(new Zoom { Zoom_Id =6, ParentId = 5, Zoom_Name = "鹅掌楸" });
            list.Add(new Zoom { Zoom_Id = 7, ParentId = 5, Zoom_Name = "金花茶" });
            list.Add(new Zoom { Zoom_Id = 8, ParentId = 5, Zoom_Name = "望天树" });

            list.Add(new Zoom { Zoom_Id = 9, ParentId = 9, Zoom_Name = "二级保护动物" });
            list.Add(new Zoom { Zoom_Id =10, ParentId = 9, Zoom_Name = "金丝猴" });
            list.Add(new Zoom { Zoom_Id = 11, ParentId = 9, Zoom_Name = "白琵鹭" });
            list.Add(new Zoom { Zoom_Id = 12, ParentId = 9, Zoom_Name = "团花锦蛇" });

            if (freeSql.Select<Zoom>().ToList().Count == 0)
            {
                freeSql.Insert<Zoom>(list).ExecuteAffrows();

            }
                

            treeList1.DataSource = freeSql.Queryable<Zoom>().ToList();
           // treeList1.DataSource = list;
            

            treeList1.KeyFieldName = "Zoom_Id";
            treeList1.ParentFieldName = "ParentId";
            treeList1.Columns[0].Caption = "动植物保护园";
            treeList1.OptionsBehavior.Editable = false;//不可编辑
            this.treeList1.OptionsView.ShowCheckBoxes = true;//是否显示复选框
            treeList1.RowHeight = 30;
            treeList1.ExpandAll();
            treeList1.RefreshDataSource();//刷新treeList1

          //  treeListLookUpEdit1.Properties.TextEditStyle = TextEditStyles.Standard;
            treeListLookUpEdit1.Properties.AutoComplete = false;
            treeListLookUpEdit1.Properties.DataSource = list;
            treeListLookUpEdit1TreeList.DataSource = list;
            treeListLookUpEdit1TreeList.KeyFieldName = "Zoom_Id";
            treeListLookUpEdit1TreeList.ParentFieldName = "ParentId";
            treeListLookUpEdit1TreeList.Columns[0].Caption = "动植物保护园";
            treeListLookUpEdit1.Properties.DisplayMember = "Zoom_Name";

        }
        
        //右键出现菜单项
        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
                    treeList1.ContextMenu = null;
                    TreeListHitInfo hInfo =treeList1.CalcHitInfo(new Point(e.X, e.Y));
                    TreeListNode node = hInfo.Node;
                    treeList1.FocusedNode = node;
                    if (node != null)
                    {
                        treeList1.ContextMenuStrip = contextMenuStrip1;
                    }
            }
        }

        //增加节点
        private void Add_Menultem_Click(object sender, EventArgs e)
        {

            TreeListNode node = this.treeList1.FocusedNode;
            Zoom zomm = this.treeList1.GetDataRecordByNode(node) as Zoom;

            if (node.HasChildren == true)
            {
                string a = textEdit1.EditValue.ToString();
                int b = freeSql.Queryable<Zoom>().ToList().Count()+2;

                freeSql.Insert<Zoom>(new Zoom {Zoom_Id= b, Zoom_Name = a, ParentId = b }).ExecuteAffrows();

                treeList1.DataSource = freeSql.Queryable<Zoom>().ToList();
                treeList1.RefreshDataSource();//刷新treeList1
            }
            else
            {
                string a = textEdit1.EditValue?.ToString();
                freeSql.Insert<Zoom>(new Zoom { Zoom_Name = a, ParentId = zomm.Zoom_Id }).ExecuteAffrows();

                treeList1.DataSource = freeSql.Queryable<Zoom>().ToList();
                treeList1.RefreshDataSource();//刷新treeList1
            }
          

        }

        //删除节点
        private void Del_Menultem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确定删除所选数据", "删除提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
               
                //this.treeList1.DeleteSelectedNodes();


                TreeListNode node = this.treeList1.FocusedNode;
                Zoom zomm = this.treeList1.GetDataRecordByNode(node) as Zoom;

                freeSql.Delete<Zoom>(zomm).ExecuteAffrows();

                treeList1.DataSource = freeSql.Queryable<Zoom>().ToList();
                treeList1.RefreshDataSource();//刷新treeList1

            } 
        }


        private void pictureEdit1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage2;
        }


        private void pictureEdit2_DoubleClick(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage1;
        }

        private void treeListLookUpEdit1_MouseDown(object sender, MouseEventArgs e)
        {
      
        }

        private void treeListLookUpEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
              //  this.treeListLookUpEdit1.Properties.TreeList.FocusedNode = null;
                treeListLookUpEdit1.EditValue = null;
                this.treeListLookUpEdit1.Reset();
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            //ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            //contextMenuStrip.Items.Clear();
            //ToolStripMenuItem addItem = new ToolStripMenuItem();
            //addItem.Name = "添加数据";
            //contextMenuStrip.Items.Add(addItem);
          
        }

        private void BarManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch(e.Item.Caption)
            {
                case "Copy":
                    XtraMessageBox.Show("开始复制");
                    break;
                case "Paste":
                    XtraMessageBox.Show("开始粘贴");
                    break;
                case "Refresh":
                    XtraMessageBox.Show("开始刷新");
                    break;
                default:
                    XtraMessageBox.Show("没有选择");
                    break;
            }
           // XtraMessageBox.Show(e.Item.Caption + " item clicked");
        }

        private void XtraForm2_Load(object sender, EventArgs e)
        {
            menu.Manager = barManager;
            barManager.Form = this;
            BarButtonItem itemCopy = new BarButtonItem(barManager, "Copy", 0);
            BarButtonItem itemPaste = new BarButtonItem(barManager, "Paste", 1);
            BarButtonItem itemRefresh = new BarButtonItem(barManager, "Refresh", 2);
            menu.AddItems(new BarItem[] { itemCopy, itemPaste, itemRefresh });
            // Create a separator before the Refresh item.
            itemRefresh.Links[0].BeginGroup = true;
            // Process item clicks.
            barManager.ItemClick += BarManager_ItemClick;
            // Associate the popup menu with the form.
            barManager.SetPopupContextMenu(this, menu);
        }
        private void XtraForm2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                menu.ShowPopup(MousePosition);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int a = 100;
            int b =Add( a,c:6);
            bool w = true;
            string c = string.Format("和={0}", (a + b).ToString());

            IGetDataType methodHelper = new MethodHelper();
            var ddd =  methodHelper.GetType(a);
            var fff = methodHelper.GetArea(a, b);
            var ww = methodHelper.GetType(w);
            MessageBox.Show($"{a}, {b}, {c}, a的类型为:{ddd}, W的数据类型为:{ww} , 面积的值为:{fff}");
        }

        private int Add (int a,int b = 10,int c = 10)
        {
            a += b*c;
            return a;
        }

        private void BtnExpandAll_Click(object sender, EventArgs e) => this.treeList1.ExpandAll();

        private void BtnCollapse_Click(object sender, EventArgs e) => this.treeList1.CollapseAll();

        private void btnTest_Click(object sender, EventArgs e)
        {
            string FtpIp = "192.168.99.248";
            string Port = "30";
            string UserName = "demo";
            string Password = "demo";
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + FtpIp + ":" + Port);

            request.Credentials = new NetworkCredential(UserName, Password);
            request.Method = Ftp.ListDirectory;
            request.Timeout = 3000;

            FtpWebResponse ftpResponse = (FtpWebResponse)request.GetResponse();
            ftpResponse.Close();
        }
    }
}