using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Npgsql;
using FreeSql;
using System.Data.SqlClient;
using FreeSql.DataAnnotations;
using System.Reflection;
using Npgsql.Internal.TypeHandlers.NetworkHandlers;
using System.Security.Cryptography;
using System.Collections.Immutable;
using FreeSql.Internal;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        //pg��ʽ�������ݿ�sde������ʾ���ݱ�
        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = "Host= localhost ; Port = 5432 ; User ID = sde ; Password = weiyouhou ; Database = sde ";
            NpgsqlConnection conn = new NpgsqlConnection(connstr);
            conn.Open();
            string sql = "select * from student";
            DataTable dt = new DataTable();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var list = FreeSqlContext.FreeSqlConnect.Queryable<student>().ToList();
            //var row = FreeSqlContext.FreeSqlConnect.Delete<student>(new[] { list[0] }).ExecuteAffrows();
        }
        //�����Լ���Freesql����
        public class FreeSqlContext
        {
            public static IFreeSql FreeSqlConnect { get; } = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.Sqlite, @"Data Source = sde.db")
                .UseAutoSyncStructure(true).Build();
        }

        //�½�ѧ����
        [Table(Name = "Student")]
        public class Student
        {
            [Column(IsIdentity = true, IsPrimary = true)]
            public string Id { get; set; }
          //  [Navigate(nameof(Id))]

            public string Sname { get; set; }

            public int Age { get; set; }
          
            [Column(IsNullable = true)]
            public string Cid { get; set; }
            //[Navigate(nameof(Cid))]
            public Level Level { get; set; }

        }

        // �½�����Level
        [Table(Name = "Level")]
        public class Level
        {
            [Column(IsIdentity = true, IsPrimary = true)]
            public string Id { get; set; }
           // [Navigate(nameof(Student.Cid))]
            public string Cname { get; set; }

           [Navigate(nameof(Student.Cid))]
            public List<Student> Students { get; set; }

        }

        //��������
        private void button3_Click(object sender, EventArgs e)
        {
            var row = FreeSqlContext.FreeSqlConnect.Insert(new Student { Id = Guid.NewGuid().ToString(), Sname = "����", Age = 459, Cid = "0849b24c-f3d2-46ac-8505-95588de57a39" }).ExecuteAffrows();
            var row1 = FreeSqlContext.FreeSqlConnect.Insert(new Level { Id = Guid.NewGuid().ToString(), Cname = "����" }).ExecuteAffrows();

            var row3 = FreeSqlContext.FreeSqlConnect.Insert(new Student { Id = Guid.NewGuid().ToString(), Sname = "���", Age = 560, Cid = "5678d21f-d980-4dca-a837-0626901134f6" }).ExecuteAffrows();
            var row13 = FreeSqlContext.FreeSqlConnect.Insert(new Level { Id = Guid.NewGuid().ToString(), Cname = "һ��" }).ExecuteAffrows();

            var row4 = FreeSqlContext.FreeSqlConnect.Insert(new Student { Id = Guid.NewGuid().ToString(), Sname = "����", Age = 444, Cid = "74a2cc72-f333-41e3-bc68-7c8c5374c9fc" }).ExecuteAffrows();
            var row14 = FreeSqlContext.FreeSqlConnect.Insert(new Level { Id = Guid.NewGuid().ToString(), Cname = "����" }).ExecuteAffrows();

            var row5 = FreeSqlContext.FreeSqlConnect.Insert(new Student { Id = Guid.NewGuid().ToString(), Sname = "�Ի�", Age = 445, Cid = "20000" }).ExecuteAffrows();
            var row15 = FreeSqlContext.FreeSqlConnect.Insert(new Level { Id = Guid.NewGuid().ToString(), Cname = "����" }).ExecuteAffrows();

            var row6 = FreeSqlContext.FreeSqlConnect.Insert(new Student { Id = Guid.NewGuid().ToString(), Sname = "����", Age = 885, Cid = "30000" }).ExecuteAffrows();
            var row16 = FreeSqlContext.FreeSqlConnect.Insert(new Level { Id = Guid.NewGuid().ToString(), Cname = "����" }).ExecuteAffrows();

            var row7 = FreeSqlContext.FreeSqlConnect.Insert(new Student { Id = Guid.NewGuid().ToString(), Sname = "�ŷ�", Age = 879, Cid = "30000" }).ExecuteAffrows();
            var row17 = FreeSqlContext.FreeSqlConnect.Insert(new Level { Id = Guid.NewGuid().ToString(), Cname = "����" }).ExecuteAffrows();

            var row8 = FreeSqlContext.FreeSqlConnect.Insert(new Student { Id = Guid.NewGuid().ToString(), Sname = "����", Age = 888, Cid = "30000" }).ExecuteAffrows();
            var row18 = FreeSqlContext.FreeSqlConnect.Insert(new Level { Id = Guid.NewGuid().ToString(), Cname = "����" }).ExecuteAffrows();
        }
        // ��ѯ��ʾ����
        private void button4_Click(object sender, EventArgs e)
        {
            /*var list = FreeSqlContext.FreeSqlConnect.Queryable<Student>().ToList();
            dataGridView1.DataSource = list;
            var list1 = FreeSqlContext.FreeSqlConnect.Queryable<Level>().ToList();
            dataGridView2.DataSource = list1;*/



            /* Student stu = FreeSqlContext.FreeSqlConnect.Select<Student>().
                Where(it => it.Id == "c68b8beb-3e4e-41a1-bc6a-725f8a21ae14")
                .Include(it => it.Level)
                .First();
             */

            Level lev = FreeSqlContext.FreeSqlConnect.Select<Level>().Where(it => it.Cname == "����").IncludeMany(it => it.Students).First();
          /*  var list2 = FreeSqlContext.FreeSqlConnect.Select<Level>().IncludeMany(it => it.Students)
                .Where(it => it.Cname == "����").ToList();

            dataGridView1.DataSource = list2;*/

        }
        // ����ID����ɾ������
        private void Delete_Click(object sender, EventArgs e)
        {
            var row = FreeSqlContext.FreeSqlConnect.Delete<Student>( new Student{Id ="bfa630ae-3f33-40e8-85f1-9ef55b217597" ,Sname = "����ʯ"}).ToSql();

            FreeSqlContext.FreeSqlConnect.Delete<Student>(new Student { Id = "bfa630ae-3f33-40e8-85f1-9ef55b217597", Sname = "����ʯ" }).ExecuteAffrows();

            // var row1 = FreeSqlContext.FreeSqlConnect.Delete<Student>(new Student{ Sname = textBox1.ToString() }).ToSql();
            //Console.WriteLine(textBox1.ToString());

            var list = FreeSqlContext.FreeSqlConnect.Queryable<Student>().ToList();
            dataGridView1.DataSource = list;
            //ɾ��֮��gridview��ʾ����
            
        }

        //���²���������SetDto����
        private void Update_Click(object sender, EventArgs e)
        {
           // var item = new Student { Id = "bfa630ae-3f33-40e8-85f1-9ef55b217597", Sname = "����ʯ" };
           // var repo = FreeSqlContext.FreeSqlConnect.Update<Student>().SetSource(item).ExecuteAffrows();

            var row = FreeSqlContext.FreeSqlConnect.Update<Student>().SetDto(new {Sname= "��ױ���" ,Age = 6666, Cid = "10000" }).Where(a => a.Id == "0ccd0ce3-30d6-4ce5-9ed6-3d0781ab8b61").ExecuteAffrows();

            var list = FreeSqlContext.FreeSqlConnect.Queryable<Student>().ToList();
            dataGridView1.DataSource = list;

        }
    }
}
