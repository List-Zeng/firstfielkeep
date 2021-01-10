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
using FINALLY.窗体;

namespace FINALLY
{
    public partial class MainPage : Form
    {
        SqlHelper Sql = new SqlHelper();  //全局调用
        public MainPage(string stuno)    //窗口传值
        {
            InitializeComponent();
            getstuname(stuno);
        }
        
        private void getstuname(string stuno)     //获取学生姓名并在lable内赋值
        {
            string a = $@"SELECT
                            Name
	                        FROM
	                        dbo.Student
	                        WHERE
	                        No='{stuno}'";
            Sql.QuickRead(a);
            if (Sql.HasRecord)
            {
                label4.Text = stuno;
                label3.Text = Sql["Name"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)    //按钮点击时启动窗体并隐藏本窗体
        {
            GetCouseLearn aaaa = new GetCouseLearn(label4.Text, "选课中心", this);
            this.Hide();
            aaaa.Show();
        }

        private void button3_Click(object sender, EventArgs e)    //按钮点击时启动窗体并隐藏本窗体
        {
            GetCouseLearn aaaa = new GetCouseLearn(label4.Text, "培养方案", this);
            this.Hide();
            aaaa.Show();
        }

        private void button5_Click(object sender, EventArgs e)   //按钮点击时启动窗体并隐藏本窗体
        {
            mydesktop a = new mydesktop(label4.Text,"留言中心",this);
            this.Hide();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)    //按钮点击时启动窗体并隐藏本窗体
        {
            mydesktop a = new mydesktop(label4.Text, "公告中心", this);
            this.Hide();
            a.Show();
        }

        private void button6_Click(object sender, EventArgs e)   //按钮点击时启动窗体并隐藏本窗体
        {
            Scoremessage aaaa = new Scoremessage(label4.Text, "课程成绩", this);
            this.Hide();
            aaaa.Show();
        }

        private void button7_Click(object sender, EventArgs e)   //按钮点击时启动窗体并隐藏本窗体
        {
            GetCouseLearn aaaa = new GetCouseLearn(label4.Text, "授课计划", this);
            this.Hide();
            aaaa.Show();
        }

        private void button8_Click(object sender, EventArgs e)  //按钮点击时启动窗体并隐藏本窗体
        {
            TestJoin aaaa = new TestJoin(label4.Text, "社会考试报名",this);
            this.Hide();
            aaaa.Show();
        }

        private void button2_Click(object sender, EventArgs e)   //按钮点击时启动窗体并隐藏本窗体
        {
            Scoremessage aaaa = new Scoremessage(label4.Text, "学生评教", this);
            this.Hide();
            aaaa.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)   //菜单栏点击时启动窗体并隐藏本窗体
        {
            mydesktop a = new mydesktop(label4.Text, "我的桌面", this);
            this.Hide();
            a.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)    //菜单栏点击时启动窗体并隐藏本窗体
        {
            Scoremessage aaaa = new Scoremessage(label4.Text, "学籍成绩",this);
            this.Hide();
            aaaa.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)   //菜单栏点击时启动窗体并隐藏本窗体
        {
            TestJoin aaaa = new TestJoin(label4.Text, "考试报名", this);
            this.Hide();
            aaaa.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)   //菜单栏点击时启动窗体并隐藏本窗体
        {
            Scoremessage aaaa = new Scoremessage(label4.Text, "教学评价", this);
            this.Hide();
            aaaa.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)  //菜单栏点击时启动
        {
            GetCouseLearn aaaa = new GetCouseLearn(label4.Text, "培养管理",this);
            this.Hide();
            aaaa.Show();
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)  //退出时启动，并防止误触推退出
        {
            DialogResult a =
            MessageBox.Show($@"是否退出当前程序", "提示", MessageBoxButtons.OKCancel);
            if (a == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
