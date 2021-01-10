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
    public partial class Scoremessage : Form
    {
        string studentnum ;
        SqlHelper sql = new SqlHelper();
        Form aaaaa;
        public Scoremessage(string studentnums,string openmessage,MainPage aaa)  //窗口传值
        {
            aaaaa = aaa;
            InitializeComponent();
            studentnum = studentnums;
            GetBeginTerm();
            GetCouseStyle();
            getcandorate();
            openselect(openmessage);
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
                BeginTime.Items.Add(sql["Name"]);
            }
        }

        private void GetCouseStyle()   //获取课程性质
        {
            string a = $@"SELECT
	                    Name
	                    FROM
	                    dbo.StudyType";
            sql.QuickRead(a);
            while (sql.HasRecord)
            {
                CourseStyle.Items.Add(sql["Name"]);
            }
        }

        private void Search_Click(object sender, EventArgs e) ////查询科目成绩
        {
            if (ShowStyle.Text == "显示全部成绩")
            {
                cousescores.Visible = true;
                string a;
                if (CourseStyle.Text != "---课程性质选择-----")
                {
                    if (BeginTime.Text != "-----选择学期-----" && CouseName.Text != "")
                    {
                        a = $@"SELECT
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0 AND E.Name='{BeginTime.Text}' AND A.Name='{CouseName.Text}'";
                    }
                    else if (BeginTime.Text != "-----选择学期-----" && CouseName.Text == "")
                    {
                        a = $@"SELECT
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0 AND E.Name='{BeginTime.Text}' ";
                    }
                    else if (BeginTime.Text == "-----选择学期-----" && CouseName.Text != "")
                    {
                        a = $@"SELECT
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0 AND A.Name='{CouseName.Text}' ";
                    }
                    else
                    {
                        a = $@"SELECT
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0";
                    }
                }else
                {
                    if (BeginTime.Text != "-----选择学期-----" && CouseName.Text != "")
                    {
                        a = $@"SELECT
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0 AND E.Name='{BeginTime.Text}' AND A.Name='{CouseName.Text}'";
                    }
                    else if (BeginTime.Text != "-----选择学期-----" && CouseName.Text == "")
                    {
                        a = $@"SELECT
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0 AND E.Name='{BeginTime.Text}' ";
                    }
                    else if (BeginTime.Text == "-----选择学期-----" && CouseName.Text != "")
                    {
                        a = $@"SELECT
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0 AND A.Name='{CouseName.Text}' ";
                    }
                    else
                    {
                        a = $@"SELECT
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' ANDF.FacultyRate <> 0 ";
                    }
                }
                int i = 0;
                sql.QuickRead(a);
                while (sql.HasRecord)
                {
                    cousescores.Rows.Add();
                    cousescores.Rows[i].Cells[0].Value = sql["学期"].ToString();
                    cousescores.Rows[i].Cells[1].Value = sql["课程号"].ToString();
                    cousescores.Rows[i].Cells[2].Value = sql["课程名"].ToString();
                    cousescores.Rows[i].Cells[3].Value = sql["总分"].ToString();
                    cousescores.Rows[i].Cells[4].Value = sql["学分"].ToString();
                    cousescores.Rows[i].Cells[5].Value = sql["课程类型"].ToString();
                    cousescores.Rows[i].Cells[6].Value = sql["考试类型"].ToString();
                    i++;
                }
                if (cousescores.Rows[0].Cells[0].Value == null)
                {
                    cousescores.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label6.Visible = true;
                    BeginTime.Visible = false;
                    CourseStyle.Visible = false;
                    CouseName.Visible = false;
                    ShowStyle.Visible = false;
                    Search.Visible = false;
                }
                button2.Visible = true;
                MessageBox.Show("部分未评教成绩不在列表内！");
            }else
            if (ShowStyle.Text == "显示最好成绩")
            {
                cousescores.Visible = true;
                string a;
                if (CourseStyle.Text != "---课程性质选择-----")
                {
                    if (BeginTime.Text != "-----选择学期-----" && CouseName.Text != "")
                    {
                        a = $@"SELECT TOP 1
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0 AND  E.Name='{BeginTime.Text}' AND A.Name='{CouseName.Text}'
                        ORDER BY
	                    F.TotalScore DESC";
                    }
                    else if (BeginTime.Text != "-----选择学期-----" && CouseName.Text == "")
                    {
                        a = $@"SELECT TOP 1
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0 AND  E.Name='{BeginTime.Text}' 
                        ORDER BY
	                    F.TotalScore DESC";
                    }
                    else if (BeginTime.Text == "-----选择学期-----" && CouseName.Text != "")
                    {
                        a = $@"SELECT TOP 1
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0 AND  A.Name='{CouseName.Text}' 
                        ORDER BY
	                    F.TotalScore DESC";
                    }
                    else
                    {
                        a = $@"SELECT TOP 1
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum} AND F.FacultyRate <> 0'
                        ORDER BY
	                    F.TotalScore DESC";
                    }
                }
                else
                {
                    if (BeginTime.Text != "-----选择学期-----" && CouseName.Text != "")
                    {
                        a = $@"SELECT TOP 1
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0 AND  E.Name='{BeginTime.Text}' AND A.Name='{CouseName.Text}'
                        ORDER BY
	                    F.TotalScore DESC";
                    }
                    else if (BeginTime.Text != "-----选择学期-----" && CouseName.Text == "")
                    {
                        a = $@"SELECT TOP 1
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0 AND  E.Name='{BeginTime.Text}' 
                        ORDER BY
	                    F.TotalScore DESC";
                    }
                    else if (BeginTime.Text == "-----选择学期-----" && CouseName.Text != "")
                    {
                        a = $@"SELECT TOP 1
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0 AND  A.Name='{CouseName.Text}'
                        ORDER BY
	                    F.TotalScore DESC";
                    }
                    else
                    {
                        a = $@"SELECT TOP 1
	              	        E.Name AS 学期,
	                        A.No AS 课程号,
	                        A.Name AS 课程名,
	                        F.TotalScore AS 总分,
	                        A.Credit AS 学分,
	                        B.Name AS 课程类型,
	                        C.Name AS 考试类型
	                    FROM
	                    dbo.Course AS A
	                    JOIN dbo.StudyType AS B ON B.No = A.StudyTypeNo
	                    JOIN dbo.EXAMTYPE AS C ON C.No = A.ExamTypeNo
	                    JOIN dbo.TeachingTast AS D ON D.CourseNo=A.No
	                    JOIN dbo.Term AS E ON E.No = D.TermNo
	                    JOIN dbo.StudentScore AS F ON F.TeachingTaskNo = D.No
	                    WHERE
	                    F.StudentNo='{studentnum}' AND F.FacultyRate <> 0
                        ORDER BY
	                    F.TotalScore DESC";
                    }
                }int i = 0;
                sql.QuickRead(a);
                while (sql.HasRecord)
                {
                    cousescores.Rows[i].Cells[0].Value = sql["学期"].ToString();
                    cousescores.Rows[i].Cells[1].Value = sql["课程号"].ToString();
                    cousescores.Rows[i].Cells[2].Value = sql["课程名"].ToString();
                    cousescores.Rows[i].Cells[3].Value = sql["总分"].ToString();
                    cousescores.Rows[i].Cells[4].Value = sql["学分"].ToString();
                    cousescores.Rows[i].Cells[5].Value = sql["课程类型"].ToString();
                    cousescores.Rows[i].Cells[6].Value = sql["考试类型"].ToString();
                    i++;
                    //}
                }
                if (cousescores.Rows[0].Cells[0].Value == null)
                {
                    cousescores.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label6.Visible = true;
                    BeginTime.Visible = false;
                    CourseStyle.Visible = false;
                    CouseName.Visible = false;
                    ShowStyle.Visible = false;
                    Search.Visible = false;
                }
                button2.Visible = true;
                MessageBox.Show("该列表仅排序已评教成绩！");
            }
            else
            {
                MessageBox.Show("请先选择显示排列方式");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //  分数获取
        {
            if (e.ColumnIndex == 7)
            {
                string a = $@"SELECT
	                    A.FinalScore,
	                    A.BasicScore,
	                    A.TotalScore
	                    FROM
	                    dbo.StudentScore AS A
	                    JOIN dbo.TeachingTast AS C ON A.TeachingTaskNo=C.No
	                    JOIN dbo.Course AS B ON B.No=C.CourseNo
	                    WHERE 
	                    A.StudentNo='{studentnum}' AND B.No='{cousescores.Rows[e.RowIndex].Cells[1].Value}'";
                sql.QuickRead(a);
                if (sql.HasRecord)
                {
                    string ss = "平时分：" + sql["BasicScore"].ToString() + "\n"
                                + "期末成绩：" + sql["FinalScore"].ToString() + "\n"
                                + "总分：" + sql["TotalScore"].ToString();
                    MessageBox.Show(ss, "分数细分");
                }
            }
        }

        private void 学籍管理ToolStripMenuItem_Click(object sender, EventArgs e)  //通过菜单栏转换tabcontrol
        {
            scorefind.Visible = false;
            messagemannege.Visible = true;

        }

        private void 我的成绩ToolStripMenuItem_Click_1(object sender, EventArgs e)  //通过菜单栏转换tabcontrol
        {
            messagemannege.Visible = false;
            scorefind.Visible = true;
        }
        private void getcandorate()                                     //获取可有的评教
        {
            string a = $@"SELECT
	                        B.Name,
	                        A.RateStyle,
	                        A.RateThing,
	                        A.BeginTime,
	                        A.OverTime
	                        FROM
	                        dbo.GiveTeacherRate AS A
	                        JOIN dbo.Term AS B ON A.TermNo=B.No
	                        JOIN dbo.Major AS C ON A.MajorNo=C.No
	                        JOIN dbo.Class AS D ON D.MajorNo=C.No
	                        JOIN dbo.Student AS E ON E.ClassNo = D.No
	                        WHERE 
	                        (GETDATE() BETWEEN A.BeginTime AND A.OverTime) AND E.No='{studentnum}'";
            sql.QuickRead(a);
            int i = 0;
            while (sql.HasRecord)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = sql["Name"].ToString();
                dataGridView2.Rows[i].Cells[1].Value = sql["RateStyle"].ToString();
                dataGridView2.Rows[i].Cells[2].Value = sql["RateThing"].ToString();
                dataGridView2.Rows[i].Cells[3].Value = sql["BeginTime"].ToString();
                dataGridView2.Rows[i].Cells[4].Value = sql["OverTime"].ToString();
                dataGridView2.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                i++;
            }
            if (dataGridView2.Rows[0].Cells[0].Value == null)
            {
                label5.Visible = true;
                dataGridView2.Visible = false;
            }
            else
            {
                dataGridView2.Visible = true;
                label5.Visible = false;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)  //评教数据填充
        {
            if (e.ColumnIndex==5)
            {
                dataGridView2.Visible = false;
                dataGridView3.Visible = true;
                button1.Visible = true;
                string a = $@"SELECT
	                            E.No,
	                            E.Name,
	                            F.Name AS T,
								A.FacultyRate 
	                            FROM
	                            dbo.StudentScore AS A
	                            JOIN dbo.TeachingTast AS B ON B.No = A.TeachingTaskNo
	                            JOIN dbo.Term AS C ON C.No = B.TermNo
	                            JOIN dbo.Course AS E ON E.No = B.CourseNo
	                            JOIN dbo.Faculty AS F ON F.No = B.FacultyNo
	                            WHERE
	                            A.StudentNo='{studentnum}' AND C.Name='{dataGridView2.Rows[e.RowIndex].Cells[0].Value}'";
                sql.QuickRead(a);
                int i = 0;
                while (sql.HasRecord)
                {
                    dataGridView3.Rows.Add();
                    dataGridView3.Rows[i].Cells[0].Value = sql["No"].ToString();
                    dataGridView3.Rows[i].Cells[1].Value = sql["Name"].ToString();
                    dataGridView3.Rows[i].Cells[2].Value = sql["T"].ToString();
                    dataGridView3.Rows[i].Cells[3].Value = sql["FacultyRate"].ToString();
                    if (dataGridView3.Rows[i].Cells[3].Value.ToString() != "")
                    {
                        dataGridView3.Rows[i].Cells[3].ReadOnly = true;
                    }
                    i++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)   //返回重选课程成绩列表
        {
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            button1.Visible = false;
            dataGridView3.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)  //返回重选评教列表
        {
            button2.Visible = false;
            cousescores.Rows.Clear();
            cousescores.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label6.Visible = false;
            BeginTime.Visible = true;
            CourseStyle.Visible = true;
            CouseName.Visible = true;
            ShowStyle.Visible = true;
            Search.Visible = true;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)   //评教
        {
            if (e.ColumnIndex == 4)
            {
                decimal rate = Convert.ToDecimal(dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString());
                if (rate >= 1&& rate<=100)
                {
                    if (dataGridView3.Rows[e.RowIndex].Cells[3].ReadOnly == false)
                    {
                        string a = $@"UPDATE dbo.StudentScore
                                    SET
                                    FacultyRate={dataGridView3.Rows[e.RowIndex].Cells[3].Value}
                                    WHERE
                                    TeachingTaskNo=(SELECT B.TeachingTaskNo
                                    FROM
                                    dbo.TeachingTast AS A
                                    JOIN dbo.StudentScore AS B ON B.TeachingTaskNo = A.No
                                    WHERE
                                    B.StudentNo='{studentnum}' AND A.CourseNo='{dataGridView3.Rows[e.RowIndex].Cells[0].Value}')";
                        int b = sql.QuickSubmit(a);
                        if (b==1)
                        {
                            MessageBox.Show("已评分，无法再次评价");
                            dataGridView3.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("已评分，无法再次评价");
                    }
                }
            }
        }

        private void openselect(string check)  //通过窗口载入数值判断启动显示页面
        {
            if (check == "课程成绩")
            {
                我的成绩ToolStripMenuItem_Click_1(null, null);
                scorefind.SelectedTab = scoreseach;
            }
            else if (check == "学生评教" || check == "教学评价")
            {
                我的成绩ToolStripMenuItem_Click_1(null, null);
                scorefind.SelectedTab = giveteachrate;
            }
            else
            {
                我的成绩ToolStripMenuItem_Click_1(null, null);
                scorefind.SelectedTab = scoreseach;
            }
        }

        private void Scoremessage_FormClosing(object sender, FormClosingEventArgs e)  //关闭时启动隐藏主页
        {
            aaaaa.Show();
        }
    }
}
