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

namespace FINALLY
{
    public partial class mydesktop : Form
    {
        string studentno;
        Form aaa;
        public mydesktop(string stuno,string check,MainPage a)    // 窗口传入学号
        {
            aaa = a;
            InitializeComponent();
            studentno = stuno;
            getquestion(stuno);
            getname(stuno);
            studentno = stuno;
            getpublicmessage();
            getnoticemessage();
            opencheck(check);
        }
        
        public void getname(string b)    //获取学生姓名
        {
            string a = $@"SELECT
	                    No,Name
	                    FROM
	                    dbo.Student
	                    WHERE
	                    No='{b}'";
            SqlHelper s = new SqlHelper();
            s.QuickRead(a);
            if (s.HasRecord)
            {
                stuname.Text = s["Name"].ToString();
                onlineuserno.Text = s["No"].ToString();
                onlineno.Text = s["No"].ToString();
            }
        }
        public bool getquestion(string b)   //获取用户密保问题，若不为空则不开放使用文本框
        {
            string a = $@"SELECT
	                    *
	                    FROM
	                    dbo.Users
	                    WHERE
	                    No='{b}' AND (Question1 IS NULL OR Question2 IS NULL)";
            SqlHelper sqlHelper = new SqlHelper();
            int c = sqlHelper.QuickSubmit(a);
            if (c == 0)
            {
                    question1.ReadOnly = true;
                    question2.ReadOnly = true;
                    return true;
            }
            else return false;
        }
        private void keepques_Click(object sender, EventArgs e)   //密保问题导入
        {
            SqlHelper sqlHelper = new SqlHelper();
            if (question1.Text != null && answer1.Text != null)
            {
                string a = $@"UPDATE
	                            dbo.Users
	                            SET Question1 = '{question1.Text}' ,Answer1=CONVERT(VARBINARY(128),'{answer1.Text}')
                                WHERE 
	                            No='{studentno}'";
                int c =
                sqlHelper.QuickSubmit(a);
                if (c == 1)
                {
                    MessageBox.Show("问题一导入成功");
                }
                else
                {
                    MessageBox.Show("问题一导入失败");
                }
            }
            else MessageBox.Show("存在空数据");
            if (question2.Text != null && answer2.Text != null)
            {
                string a = $@"UPDATE
	                            dbo.Users
	                            SET Question2 = '{question2.Text}' ,Answer2=CONVERT(VARBINARY(128),'{answer2.Text}')
                                WHERE 
	                            No='{studentno}'";
                int c =
                sqlHelper.QuickSubmit(a);
                if (c == 1)
                {
                    MessageBox.Show("问题二导入成功");
                }
                else
                {
                    MessageBox.Show("问题二导入失败");
                }

            }
            else MessageBox.Show("存在空数据");
        }

        private void question1_Validated(object sender, EventArgs e)    //验证问题一，成功方可设置回答
        {
            if (question1.Text!=null)
            {
                answer1.ReadOnly = false;
            }
        }

        private void question2_Validated(object sender, EventArgs e) ///同上
        {
            if (question2.Text != null)
            {
                answer2.ReadOnly = false;
            }
        }

        private void getquesnull_Click(object sender, EventArgs e)    //重置清空数据库数据和文本框
        {
            question1.Text = null;
            question2.Text = null;
            answer1.Text = null;
            answer2.Text = null;
            string a = $@"UPDATE
	                            dbo.Users
	                            SET Question2 = '' ,Answer2=CONVERT(VARBINARY(128),''),Question1 = '' ,Answer1=CONVERT(VARBINARY(128),'')
                                WHERE 
	                            No='{studentno}'";
            SqlHelper s = new SqlHelper();
            int reture = s.QuickSubmit(a);
            if (reture==1)
            {
                MessageBox.Show("重置成功");
            }
            else
            {
                MessageBox.Show("重置失败");
            }
        }

        private void newpass1_Validated(object sender, EventArgs e)  //验证密码一致及原密码
        {
            string a = $@"SELECT
	                        Password
	                        FROM
	                        dbo.Users
                            WHERE
                            No = '{studentno}'";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(a);
            if (sqlHelper.HasRecord)
            {
                string b = sqlHelper["Password"].ToString();
                if (newpass.Text != null && newpass1.Text != null && newpass.Text == newpass1.Text)
                {
                    if (b == biginpass.Text)
                    {
                        keeppass.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("原密码错误");
                    }
                }
                else
                {
                    MessageBox.Show("新密码为空或两次密码不一致");
                }
            }
        }

        private void getpassnull_Click(object sender, EventArgs e)   //清空文本框
        {
            biginpass.Text = null;
            newpass.Text = null;
            newpass1.Text = null;
            keeppass.Enabled = false;
        }

        private void keeppass_Click(object sender, EventArgs e) // 重置密码
        {
            string c = $@"UPDATE
	                            dbo.Users
	                            SET Password = '{newpass.Text}'
                                WHERE 
	                            No='{studentno}'";
            SqlHelper sqlHelper = new SqlHelper();
            int returns = sqlHelper.QuickSubmit(c);
            if (returns == 1)
            {
                MessageBox.Show("密码修改成功");
            }
            else
            {
                MessageBox.Show("未知错误");
            }
        }

        private void mydesktop_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“mymaindatebaseDataSet1.PublicMessage”中。您可以根据需要移动或删除它。
            this.publicMessageTableAdapter.Fill(this.mymaindatebaseDataSet1.PublicMessage);
            // TODO: 这行代码将数据加载到表“mymaindatebaseDataSet.Getmessage”中。您可以根据需要移动或删除它。
            this.getmessageTableAdapter.Fill(this.mymaindatebaseDataSet.Getmessage);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                int A = dataGridView1.CurrentRow.Index;
                string a = $@"SELECT
	                        No,
	                        Message,
	                        [From],
	                        IIF(IsNotReturn=1,'已读','未读') AS IsNotread
	                        FROM
	                        dbo.PublicMessage
	                        WHERE
	                        No='{A+1}'";
                SqlHelper sqlHelper = new SqlHelper();
                sqlHelper.QuickRead(a);
                if (sqlHelper.HasRecord)
                {
                    MessageBox.Show(sqlHelper["Message"].ToString());
                string b = $@"UPDATE 
	                            dbo.PublicMessage
	                            SET IsNotReturn=1
	                            WHERE
	                            No = '{A+1}'";
                sqlHelper.QuickSubmit(b);
                if (sqlHelper.QuickSubmit(b) == 1)
                {
                    dataGridView1.Rows[A].Cells[3].Value = "已读";
                }
                }
        }
        public void getpublicmessage()     //公告获取
        {
            string a = $@"SELECT
                            No,
	                        Message,
	                        [From],
	                        IIF(IsNotReturn=1,'已读','未读') AS IsNotread
	                        FROM
	                        dbo.PublicMessage";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(a);
            int i = 0;
            while (sqlHelper.HasRecord)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = sqlHelper["No"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = sqlHelper["Message"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = sqlHelper["From"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = sqlHelper["IsNotread"].ToString();
                i++;
            }
        }


        public void getnoticemessage()   //留言获取
        {
            string a = $@"SELECT
	                        No,
	                        Message,
	                        [From],
	                        IIF(IsNotRead=1,'已读','未读') AS IsNotread,
							Reture
	                        FROM
	                        dbo.Getmessage";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(a);
            int i = 0;
            while (sqlHelper.HasRecord)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = sqlHelper["No"].ToString();
                dataGridView2.Rows[i].Cells[1].Value = sqlHelper["Message"].ToString();
                dataGridView2.Rows[i].Cells[2].Value = sqlHelper["From"].ToString();
                dataGridView2.Rows[i].Cells[3].Value = sqlHelper["IsNotread"].ToString();
                dataGridView2.Rows[i].Cells[4].Value = sqlHelper["Reture"].ToString();
                i++;
            }
        }
    

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)//留言回复
        {
            if (e.ColumnIndex == 5)
            {
                string a = $@"UPDATE
	                    dbo.Getmessage
	                    SET
	                    Reture='{dataGridView2.Rows[e.RowIndex].Cells[4].Value}'
	                    WHERE
	                    No='{e.RowIndex + 1}'";
                SqlHelper sqlHelper = new SqlHelper();
                sqlHelper.QuickSubmit(a);
                if (sqlHelper.QuickSubmit(a) == 1)
                {
                    string b = $@"UPDATE 
	                        dbo.Getmessage
	                        SET IsNotRead=1
	                        WHERE
	                        No = '{e.RowIndex + 1}'";
                    sqlHelper.QuickSubmit(b);
                    if (sqlHelper.QuickSubmit(b) == 1)
                    {
                        MessageBox.Show("已回复");
                    }
                }
            }
        }
        
        private void opencheck(string cjeck)    //窗口启动时根据load函数传值判断引用事件跳转至该页面
        {
            if (cjeck == "留言中心")
            {
                我的桌面.SelectedTab = priivatymessage;
            }
            else if (cjeck == "公告中心")
            {
                我的桌面.SelectedTab = publicmessage;
            }
            else
            {
                我的桌面.SelectedTab = changemessage;
            }
        }

        private void mydesktop_FormClosing(object sender, FormClosingEventArgs e)   //关闭时启动隐藏的窗体
        {
            aaa.Show();
        }
    }
}
