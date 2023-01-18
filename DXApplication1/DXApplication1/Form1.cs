using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FreeSql;
using System.Data.SqlClient;
using FreeSql.DataAnnotations;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraExport.Xls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.TableLayout;
using static DXApplication1.Form1;
using DevExpress.Utils.Extensions;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        //新建学生类
        [Table(Name = "Student")]
        public class Student
        {
            [Column(IsIdentity = true, IsPrimary = true)]
            public string Student_Id { get; set; }
            
            public string Name { get; set; }

            public string Major_Class { get; set; }

            public string City { get; set; }
            public List<Student> Students { get; set; }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*IFreeSql freeSql = new FreeSqlBuilder()
               .UseConnectionString(FreeSql.DataType.PostgreSQL, @"Host=;o;Port=5432;Username=sde;Password=weiyouhou; Database=sde;Pooling=true;Minimum Pool Size=1")
               .UseAutoSyncStructure(true)
               .Build();*/

            // MessageBox.Show("数据库链接成功");
            DataBinding();
           // List<Student> Students = freeSql.Queryable<Student>().ToList()；

        }

        //实现数据库链接、添加初始数据
        private void AddData_Click(object sender, EventArgs e)
        {

            IFreeSql freeSql = new FreeSqlBuilder()
               .UseConnectionString(FreeSql.DataType.PostgreSQL, @"Host=localhost;Port=5432;Username=sde;Password=weiyouhou; Database=Test;Pooling=true;Minimum Pool Size=1")
               .UseAutoSyncStructure(true)
               .Build();

            var row  = freeSql.Insert(new Student { Student_Id = Guid.NewGuid().ToString(), Name = "王安石",  Major_Class = "变法",  City = "开封"}).ExecuteAffrows();
            var row1 = freeSql.Insert(new Student { Student_Id = Guid.NewGuid().ToString(), Name = "孙子", Major_Class = "兵法", City = "齐国" }).ExecuteAffrows();
            var row2 = freeSql.Insert(new Student { Student_Id = Guid.NewGuid().ToString(), Name = "牛顿", Major_Class = "物理", City = "伦敦" }).ExecuteAffrows();
            var row3 = freeSql.Insert(new Student { Student_Id = Guid.NewGuid().ToString(), Name = "泰勒", Major_Class = "数学", City = "卢尔" }).ExecuteAffrows();
            var row4 = freeSql.Insert(new Student { Student_Id = Guid.NewGuid().ToString(), Name = "科比", Major_Class = "篮球", City = "费城" }).ExecuteAffrows();

            DataBinding();

        }

        // 数据绑定
        private void DataBinding()
        {
            IFreeSql freeSql = new FreeSqlBuilder()
               .UseConnectionString(FreeSql.DataType.PostgreSQL, @"Host=localhost;Port=5432;Username=sde;Password=weiyouhou; Database=Test;Pooling=true;Minimum Pool Size=1")
               .UseAutoSyncStructure(true)
               .Build();

            List<Student> Students = freeSql.Queryable<Student>().ToList();
            gridControl1.DataSource = Students;

        }

        //删除数据
        private void ChooseDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("确定删除所选数据" ,"删除提示",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                IFreeSql freeSql = new FreeSqlBuilder()
               .UseConnectionString(FreeSql.DataType.PostgreSQL, @"Host=localhost;Port=5432;Username=sde;Password=weiyouhou; Database=Test;Pooling=true;Minimum Pool Size=1")
               .UseAutoSyncStructure(true)
               .Build();
                int[] a = gridView1.GetSelectedRows();
                string b= Convert.ToString(gridView1.GetRowCellValue(a[0], "Student_Id"));  //

                var row = freeSql.Delete<Student>(new { Student_Id = b }).ExecuteAffrows();
                List<Student> Students = freeSql.Queryable<Student>().ToList();
                
                gridControl1.DataSource = Students;
                
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

           /* IFreeSql freeSql = new FreeSqlBuilder()
               .UseConnectionString(FreeSql.DataType.PostgreSQL, @"Host=localhost;Port=5432;Username=sde;Password=weiyouhou; Database=Test;Pooling=true;Minimum Pool Size=1")
               .UseAutoSyncStructure(true)
               .Build();
                var dr = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);//这个就是获取这一行数据

            string sql = string.Empty;
                List<SqlParameter> param = new List<SqlParameter>();
                string id = dr.ItemArray[0].ToString();
                string supplier_name = dr.ItemArray[1].ToString();//要修改的数据
                if (id != "0")//这个判断是因为如果不是0就是修改，0是新增我要用别的方法来写
                {

                    var row = freeSql.Update<Student>().SetDto(new { supplier_name }).Where(a => a.Student_Id == id).ExecuteAffrows();
               
                 
                }*/
                
                }

        //新增空白行
        private void Add_Click(object sender, EventArgs e)
        {
            List<Student> Students = gridControl1.DataSource as List<Student>;
            Students.Add(new Student { Student_Id = Guid.NewGuid().ToString(),Name = "Null" ,Major_Class = "Null", City = "Null" });
            gridControl1.DataSource = Students;
            gridView1.RefreshData();
        }

        //判断数据编辑后执行Update or Insert 操作
        private void Check ()
        {
            IFreeSql freeSql = new FreeSqlBuilder()
               .UseConnectionString(FreeSql.DataType.PostgreSQL, @"Host=localhost;Port=5432;Username=sde;Password=weiyouhou; Database=Test;Pooling=true;Minimum Pool Size=1")
               .UseAutoSyncStructure(true)
               .Build();
            //新建自己的Freesql接口，链接数据库

            List<Student> Students1 = gridControl1.DataSource as List<Student>;
            //Students1 链表 获取datasource 数据

           // List<Student> sql = freeSql.Select<Student>().ToList(it => it.Student_Id);
            List<Student> sql = freeSql.Select<Student>().ToList();
            //sql 链表获取postgreSQl数据库 Student 表中的Student_Id 字段数据


            var exp1 = Students1.Where(it => sql.Exists(t => it.Student_Id.Contains(t.Student_Id))).ToList();


            var exp2 = Students1.Where(it=> !sql.Exists(t => it.Student_Id.Contains(t.Student_Id))).ToList();
            // 查找datasource 中存在而数据库中不存在的Student_Id 字段 

            freeSql.Update<Student>().SetSource(exp1).IgnoreColumns(it => it.Student_Id).ExecuteAffrows();
            // 更新相同项

            freeSql.Insert<Student>(exp2).ExecuteAffrows();
            // 添加不同数据到数据库

            
        }

        private void Save_Update_Click(object sender, EventArgs e)
        {
            Check();
            gridView1.RefreshData();
        }

    }
}
