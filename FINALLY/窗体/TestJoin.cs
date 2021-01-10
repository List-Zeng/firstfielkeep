using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartLinli.DatabaseDevelopement;

namespace FINALLY.窗体
{
    public partial class TestJoin : Form
    {
        string studentnum;
        SqlHelper sql = new SqlHelper();
        Form aa;
        public TestJoin(string usernum, string choose,MainPage a )  //窗口传值
        {
            aa = a;
            studentnum = usernum;
            InitializeComponent();
            GetBeginTerm();
            getstyle();
            getallsocial();
            getchooseexam();
            opencheck(choose);
        }
        private void GetBeginTerm()    /////获取学期
        {
            string a = $@"SELECT
	                    Name
	                    FROM
	                    dbo.Term";
            sql.QuickRead(a);
            while (sql.HasRecord)
            {
                Term.Items.Add(sql["Name"]);
            }
        }
        private void getstyle()   //获取课程类型
        {
            string a = $@"SELECT
	                    Name
	                    FROM
	                    dbo.StudyType";
            sql.QuickRead(a);
            while(sql.HasRecord)
            {
                Cousestyle.Items.Add(sql["Name"]);
            }
        }
        private void 我的考试ToolStripMenuItem_Click(object sender, EventArgs e)   //通过菜单跳转tabcontrol
        {
            ScoreMannage.Visible = false;
            MyExam.Visible = true;
        }

        private void 成绩管理ToolStripMenuItem_Click(object sender, EventArgs e)   //通过菜单跳转tabcontrol
        {
            MyExam.Visible = false;
            ScoreMannage.Visible = true;
        }
        public void getallsocial()   //获取所有可报名社会考试
        {
            string a = $@"SELECT
                        *
                        FROM
                        dbo.AllSocialExam";
            sql.QuickRead(a);
            int i = 0;
            while (sql.HasRecord)
            {
                allsocialexam.Rows.Add();
                allsocialexam.Rows[i].Cells[0].Value = sql["No"].ToString();
                allsocialexam.Rows[i].Cells[1].Value = sql["Name"].ToString();
                allsocialexam.Rows[i].Cells[2].Value = sql["Level"].ToString();
                allsocialexam.Rows[i].Cells[5].Value = sql["Time"].ToString();
                allsocialexam.Rows[i].Cells[5].Value = sql["Cost"].ToString();
                allsocialexam.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                i++;
            }
        }
        public void getchooseexam()    //获取所有已选考试
        {
            hasgetcocial.Rows.Clear();
            string a = $@"SELECT
	                    B.No AS A,
						B.Name AS B,
						A.ExamLevel AS C,
						B.Time AS D,
						B.Cost AS E,
                        IIF(A.IsNotCost=1,'是','否') AS QUICK
	                    FROM
	                    dbo.HasGetExam  AS A
						JOIN dbo.AllSocialExam AS B ON B.No = A.ExamLevel
                        WHERE A.StudentNo='{studentnum}'";
            sql.QuickRead(a);
            int i = 0;
            while (sql.HasRecord)
            {
                hasgetcocial.Rows.Add();
                hasgetcocial.Rows[i].Cells[0].Value = sql["A"].ToString();
                hasgetcocial.Rows[i].Cells[1].Value = sql["B"].ToString();
                hasgetcocial.Rows[i].Cells[2].Value = sql["D"].ToString();
                hasgetcocial.Rows[i].Cells[3].Value = sql["E"].ToString();
                hasgetcocial.Rows[i].Cells[4].Value = sql["QUICK"].ToString();
                hasgetcocial.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                i++;
            }
        }

        private void allsocialexam_CellContentClick(object sender, DataGridViewCellEventArgs e)  //报名
        {
            if (e.ColumnIndex == 5 && allsocialexam.Rows[e.RowIndex].Cells[5].ReadOnly==false)
            {
                string a = $@"INSERT
	                    dbo.HasGetExam
	                    (
	                        StudentNo,
	                        ExamLevel,
	                        IsNotCost
	                    )
	                    VALUES
	                    (   '{studentnum}',  -- StudentNo - char(10)
	                        '{allsocialexam.Rows[e.RowIndex].Cells[0].Value}',  -- ExamLevel - varchar(10)
	                        0 -- IsNotCost - bit
	                        )";
                int ab = sql.QuickSubmit(a);
                if (ab == 1)
                {
                    allsocialexam.Rows[e.RowIndex].Cells[5].ReadOnly = true;
                    MessageBox.Show("报名成功！");
                    getchooseexam();
                }
                else
                {
                    MessageBox.Show("重复报名！");
                }
            }
        }

        private void hasgetcocial_CellContentClick(object sender, DataGridViewCellEventArgs e)  //取消报名
        {
            if (e.ColumnIndex == 5)
            {
                string a = $@"DELETE dbo.HasGetExam
                        WHERE StudentNo='{studentnum}' AND ExamLevel='{hasgetcocial.Rows[e.RowIndex].Cells[0].Value}'";
                if ((hasgetcocial.Rows[e.RowIndex].Cells[4].Value).ToString() == "是")
                {
                    MessageBox.Show("已缴费项目不得取消报名");
                }
                else
                {
                    int c = sql.QuickSubmit(a);
                    if (c == 1)
                    {
                        MessageBox.Show("退选成功！");
                        getchooseexam();
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)  //课程考试信息获取
        {
            dataGridView1.Rows.Clear();
            if (Term.Text != "---请选择---")
            {
                dataGridView1.Visible = true;
                if (Cousestyle.Text == "---请选择---")
                {
                    string a = $@"SELECT
	                            A.No AS 课程号,
	                            A.Name AS 课程名,
	                            A.ExamPlace AS 考试地点,
	                            A.ExamTime AS 考试时间,
	                            C.Name AS 考试方式
	                            FROM
	                            dbo.ExamCouse AS A
	                            JOIN dbo.Term AS B ON B.No = A.TermNo
	                            JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                            WHERE
	                            B.Name='{Term.Text}' AND StudentNo='{studentnum}'";
                    int i = 0;
                    sql.QuickRead(a);
                    while (sql.HasRecord)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = sql["课程号"].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = sql["课程名"].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = sql["考试方式"].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = sql["考试地点"].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = sql["考试时间"].ToString();
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        i++;
                    }
                    if (dataGridView1.Rows[0].Cells[0].Value == null)
                    {
                        dataGridView1.Visible = false;
                        label4.Visible = true;
                        Term.Visible = false;
                        Cousestyle.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                        button1.Visible = false;
                    }
                    button2.Visible = true;
                }
                else
                {
                    string a = $@"SELECT
	                            A.No AS 课程号,
	                            A.Name AS 课程名,
	                            B.Name AS 学期,
	                            A.ExamPlace AS 考试地点,
	                            A.ExamTime AS 考试时间,
	                            C.Name AS 考试方式
	                            FROM
	                            dbo.ExamCouse AS A
	                            JOIN dbo.Term AS B ON B.No = A.TermNo
	                            JOIN dbo.Course AS E ON E.No = A.No
	                            JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                            JOIN dbo.StudyType AS D ON D.No = E.StudyTypeNo
	                            WHERE
	                            B.Name='{Term.Text}' AND E.Name='{Cousestyle.Text}'AND StudentNo='{studentnum}'";
                    int i = 0;
                    sql.QuickRead(a);
                    while (sql.HasRecord)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = sql["课程号"].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = sql["课程名"].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = sql["考试方式"].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = sql["考场"].ToString();
                        dataGridView1.Rows[i].Cells[5].Value = sql["考试时间"].ToString();
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        i++;
                    }
                    if (dataGridView1.Rows[0].Cells[0].Value == null)
                    {
                        dataGridView1.Visible = false;
                        label4.Visible = true;
                        Term.Visible = false;
                        Cousestyle.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                        button1.Visible = false;
                    }
                    button2.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("学期为空");
            }
        }

        private void button2_Click(object sender, EventArgs e)    //返回选择列表
        {
            dataGridView1.Visible = false;
            button2.Visible = false;
            label4.Visible = false;
            Term.Visible = true;
            Cousestyle.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            button1.Visible = true;
        }
        
        private void opencheck(string check)    //通过启动页跳转tabcontrol
        {
            成绩管理ToolStripMenuItem_Click(null, null);
            ScoreMannage.SelectedTab = sociationexam;
        }

        private void TestJoin_FormClosing(object sender, FormClosingEventArgs e)  //页面关闭启动隐藏主页
        {
            aa.Show();
        }
    }
}
