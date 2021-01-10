using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartLinli.DatabaseDevelopement;

namespace FINALLY.窗体
{
    public partial class GetCouseLearn : Form
    {
        string Studentno;
        Form aa;
        SqlHelper sql = new SqlHelper();
        public GetCouseLearn(string studentno,string opencheck,MainPage a)  //窗口传值
        {
            aa = a;
            InitializeComponent();
            Studentno = studentno;
            monthCalendar1.Hide();
            getterm();
            getalltermplan();
            getallplan();
            openselect(opencheck);
        }
        public void getterm()   //获取学期并赋予至下拉框
        {
            string a = $@"SELECT
	                        Name
	                        FROM
	                        dbo.Term";
            sql.QuickRead(a);
            while (sql.HasRecord)
            {
                yearterm.Items.Add(sql["Name"]);
                comboBox1.Items.Add(sql["Name"]);
            }
        }  
        
        private void Search_Click_1(object sender, EventArgs e)  //通过下拉框文本框文本获取课程信息
        {
            if (cousestyle.Text != "----请选择---" && yearterm.Text != "----请选择---")
            {
                string a,b;
                if (cousestyle.Text == "公共选修课")
                {
                    a = $@"SELECT
	                            No AS 序号,
	                            Name AS 课程名,
	                            Credit AS 学分,
	                            NULL AS 周次,
	                            NULL AS 地点,
	                            StudentNumber AS 人数
	                            FROM
	                            dbo.AllCouse
	                            WHERE
	                            No LIKE 'N%'AND Name LIKE '%公选%'";
                    int i = 0;
                    sql.QuickRead(a);
                    while (sql.HasRecord)
                    {
                        if (dataGridView1.Visible == false)
                        {
                            dataGridView1.Visible = true;
                        }
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = sql["序号"].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = sql["课程名"].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = sql["学分"].ToString();
                        dataGridView1.Rows[i].Cells[5].Value = sql["人数"].ToString();
                        i++;
                    }
                    int j = 0;
                    while (j<i)
                    {
                        b = $@"SELECT
	                        1
	                        FROM
	                        dbo.StudentScore AS A
	                        JOIN dbo.TeachingTast AS B ON B.No = A.TeachingTaskNo
	                        WHERE
	                        B.CourseNo='{dataGridView1.Rows[j].Cells[0]}'";
                        int reture = sql.QuickReturn<int>(b);
                        if (reture == 0)
                        {
                            dataGridView1.Rows[j].Cells[6].Value = "未选";
                        }
                        else if (reture == 1)
                        {
                            dataGridView1.Rows[j].Cells[6].Value = "已选";
                        }
                        j++;
                    }
                    
                }
                else
                {
                    if (cousestyle.Text == "挂牌选课")
                    {
                        a = $@"SELECT
	                            No AS 序号,
	                            Name AS 课程名,
	                            Credit AS 学分,
	                            NULL AS 周次,
	                            NULL AS 地点,
	                            StudentNumber AS 人数
	                            FROM
	                            dbo.AllCouse
	                            WHERE
	                            No LIKE 'N%'AND Name LIKE '%挂牌%'";
                        int i = 0;
                        sql.QuickRead(a);
                        while (sql.HasRecord)
                        {
                            if (dataGridView1.Visible == false)
                            {
                                dataGridView1.Visible = true;
                            }
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = sql["序号"].ToString();
                            dataGridView1.Rows[i].Cells[1].Value = sql["课程名"].ToString();
                            dataGridView1.Rows[i].Cells[2].Value = sql["学分"].ToString();
                            dataGridView1.Rows[i].Cells[5].Value = sql["人数"].ToString();
                            i++;
                        }
                        int j = 0;
                        while (j < i)
                        {
                            b = $@"SELECT
	                        1
	                        FROM
	                        dbo.StudentScore AS A
	                        JOIN dbo.TeachingTast AS B ON B.No = A.TeachingTaskNo
	                        WHERE
	                        B.CourseNo='{dataGridView1.Rows[j].Cells[0]}'";
                            sql.QuickReturn<int>(b);
                            if (sql.QuickSubmit(b) == 0)
                            {
                                dataGridView1.Rows[j].Cells[6].Value = "未选";
                            }
                            else
                            {
                                dataGridView1.Rows[j].Cells[6].Value = "已选";
                            }
                            j++;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("未选择选课类型或学期");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)  //点击课程后的操作列后启动，可选课及退课
        {
            if (e.ColumnIndex == 7)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() == "已选")
                {
                    string a = $@"DELETE dbo.TeachingTast
                                    WHERE CourseNo='{dataGridView1.Rows[e.RowIndex].Cells[0].Value}'";
                    string b = $@"DELETE
	                                dbo.StudentScore
	                                WHERE
	                                StudentNo='{Studentno}' AND TeachingTaskNo='{yearterm.Text + "-" + dataGridView1.Rows[e.RowIndex].Cells[0].Value}'";
                    string c = $@"DELETE
	                            dbo.Course
	                            WHERE
	                            No='{dataGridView1.Rows[e.RowIndex].Cells[0].Value}'";
                    int returns = sql.QuickSubmit(b);
                    int returnss = sql.QuickSubmit(a);
                    int returnsss = sql.QuickSubmit(c);
                    if (returns == 1 && returnss == 1 && returnsss == 1)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = "未选";
                        MessageBox.Show("退修成功");
                    }
                }
                else if(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() == "未选")
                {
                    int termno;
                    string c = $@"SELECT
	                                *
	                                FROM
	                                dbo.Term
	                                WHERE
	                                Name='{yearterm.Text}'";
                    sql.QuickRead(c);
                    if (sql.HasRecord)
                    {
                        termno = Convert.ToInt32(sql["No"].ToString());
                    }
                    else
                    {
                        termno = 0;
                    }
                    string teacher;
                    string d = $@"SELECT
	                            DefaultFacultyNo
	                            FROM
	                            dbo.AllCouse
	                            WHERE
	                            No='{dataGridView1.Rows[e.RowIndex].Cells[0].Value}'";
                    sql.QuickRead(d);
                    if (sql.HasRecord)
                    {
                        teacher = sql["DefaultFacultyNo"].ToString();
                    }
                    else
                    {
                        teacher = null;
                    }

                    decimal credit = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());

                    string choosecouse = $@"INSERT
	                                    dbo.Course
	                                    (
	                                        No,
	                                        Name,
	                                        Pinyin,
	                                        PreCouseNo,
	                                        Credit,
	                                        StudyTypeNo,
	                                        ExamTypeNo,
	                                        DefaultFacultyNo
	                                    )
	                                    VALUES
	                                    (   '{dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()}',   -- No - char(4)
	                                        '{dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()}',   -- Name - varchar(50)
	                                        NULL,   -- Pinyin - varchar(50)
	                                        NULL,   -- PreCouseNo - char(4)
	                                        {credit}, -- Credit - decimal(3, 1)
	                                        1,    -- StudyTypeNo - int
	                                        1,    -- ExamTypeNo - int
	                                        '{teacher}'    -- DefaultFacultyNo - char(7)
	                                        )";

                   int newcouse = sql.QuickSubmit(choosecouse);
                    if (newcouse == 1)
                    {
                        string b = $@"INSERT
	                            dbo.TeachingTast
	                            (
	                                No,
	                                TermNo,
	                                FacultyNo,
	                                CourseNo,
	                                BookNo,
	                                BookNo2
	                            )
	                            VALUES
	                            (   '{yearterm.Text + "-" + dataGridView1.Rows[e.RowIndex].Cells[0].Value}', -- No - varchar(30)
	                                {termno},  -- TermNo - int
	                                '{teacher}', -- FacultyNo - char(7)
	                                '{dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()}', -- CourseNo - char(4)
	                                NULL,  -- BookNo - int
	                                NULL   -- BookNo2 - int
	                                )";
                        int newrask = sql.QuickSubmit(b);
                        if (newrask == 1)
                        {
                            string newa = $@"INSERT
	                                        dbo.StudentScore
	                                        (
	                                            StudentNo,
	                                            TeachingTaskNo,
	                                            BookOrderFlag,
	                                            BasicScore,
	                                            FinalScore,
	                                            TotalScore,
	                                            FacultyRate,
	                                            LastModifyTime
	                                        )
	                                        VALUES
	                                        (   '{Studentno}',                   -- StudentNo - char(10)
	                                            '{yearterm.Text + "-" + dataGridView1.Rows[e.RowIndex].Cells[0].Value}',                   -- TeachingTaskNo - varchar(30)
	                                            NULL,                 -- BookOrderFlag - bit
	                                            NULL,                 -- BasicScore - decimal(4, 1)
	                                            NULL,                 -- FinalScore - decimal(4, 1)
	                                            NULL,                 -- TotalScore - numeric(7, 2)
	                                            NULL,                 -- FacultyRate - decimal(4, 1)
	                                            GETDATE() -- LastModifyTime - smalldatetime
	                                            )";
                            int reture = sql.QuickSubmit(newa);
                            if (reture == 1)
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[6].Value = "已选";
                                MessageBox.Show("选修成功");
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)    //点击按钮日历（calander）显示
        {
            monthCalendar1.Show();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)   //选择日期后执行赋日历值至文本框
        {
            date.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)  //借用及退借教室
        {
            if (e.ColumnIndex == 4)
            {
                string alldate = date.Text.Substring(date.Text.Length - 2);
                string newdd = null;
                if (dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString() != "已借用")
                {
                    string b = $@"SELECT
	                            BorrowDetail
	                            FROM
	                            dbo.Room
	                            WHERE
	                            No='{dataGridView2.Rows[e.RowIndex].Cells[0].Value}'";
                    sql.QuickRead(b);
                    while (sql.HasRecord)
                    {
                        string dd = sql["BorrowDetail"].ToString();
                        string[] sArray = dd.Split(' ');
                        for (int i = 0; i < sArray.Length; i++)
                        {
                            if (datetime.Text != "----请输入-----")
                            {
                                if (sArray[i] != Studentno + alldate + "-" + datetime.Text)
                                {
                                    newdd = sArray[i] + " ";
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                DialogResult dialogResult;
                                dialogResult = MessageBox.Show("选择时间为早上吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                if (dialogResult==DialogResult.OK)
                                {
                                    datetime.Text = "上午";
                                    if (sArray[i] != Studentno + alldate + "-" + datetime.Text)
                                    {
                                        newdd = sArray[i] + " ";
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (dialogResult==DialogResult.Cancel)
                                {
                                    datetime.Text = "下午";
                                    if (sArray[i] != Studentno + alldate + "-" + datetime.Text)
                                    {
                                        newdd = sArray[i] + " ";
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (dialogResult ==DialogResult.None)
                                {
                                    break;
                                }
                            }
                        }
                        string a = $@"UPDATE
	                            dbo.Room
	                            SET BorrowDetail = '{newdd}'
	                            WHERE
	                            BorrowDetail = '{dd}' AND No = '{dataGridView2.Rows[e.RowIndex].Cells[0].Value}'";
                        int d = sql.QuickSubmit(a);
                        if (d == 1)
                        {
                            MessageBox.Show($"借用成功{datetime.Text}");
                            dataGridView2.Rows[e.RowIndex].Cells[3].Value = "已借用";
                        }
                    }
                }
                else
                {
                    string b = $@"SELECT
	                            BorrowDetail
	                            FROM
	                            dbo.Room
	                            WHERE
	                            No='{dataGridView2.Rows[e.RowIndex].Cells[0].Value}'";
                    sql.QuickRead(b);
                    while (sql.HasRecord)
                    {
                        string dd = sql["BorrowDetail"].ToString();
                        if (datetime.Text != "----请输入-----")
                        {
                            string a = $@"UPDATE
	                            dbo.Room
	                            SET BorrowDetail = '{dd + Studentno + alldate + "-" + datetime.Text + " "}'
	                            WHERE
	                            BorrowDetail = '{dd}' AND No = '{dataGridView2.Rows[e.RowIndex].Cells[0].Value}'";
                            int d = sql.QuickSubmit(a);
                            if (d == 1)
                            {
                                MessageBox.Show("退借成功！");
                                dataGridView2.Rows[e.RowIndex].Cells[3].Value = "未借用";
                            }
                        }
                    }
                }
            }
        }

        private void sercher_Click_1(object sender, EventArgs e)  //获取教室及教室借用情况
        {
            if (date.Text != "")
            {
                if (datetime.Text == "----请输入-----")
                {
                    string alldate = date.Text.Substring(date.Text.Length - 2);
                    string a = $@"SELECT
	                                *
	                                FROM
	                                dbo.Room
                                    WHERE
                                    BorrowDetail NOT LIKE '%{alldate + "-" + "上午"}%' AND BorrowDetail NOT LIKE '%{Studentno + alldate + "-" + "下午"}%'";
                    sql.QuickRead(a);
                    int i = 0;
                    while (sql.HasRecord)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = sql["No"].ToString();
                        dataGridView2.Rows[i].Cells[1].Value = sql["Name"].ToString();
                        dataGridView2.Rows[i].Cells[2].Value = sql["State"].ToString();
                        dataGridView2.Rows[i].Cells[3].Value = "未借用";
                        dataGridView2.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        i++;
                    }
                }
                else if (datetime.Text == "上午")
                {
                    string alldate = date.Text.Substring(date.Text.Length - 2);
                    string a = $@"SELECT
	                                *
	                                FROM
	                                dbo.Room
                                    WHERE
                                    BorrowDetail NOT LIKE '%{alldate + "-" + "上午"}%'";
                    sql.QuickRead(a);
                    int i = 0;
                    while (sql.HasRecord)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = sql["No"].ToString();
                        dataGridView2.Rows[i].Cells[1].Value = sql["Name"].ToString();
                        dataGridView2.Rows[i].Cells[2].Value = sql["State"].ToString();
                        dataGridView2.Rows[i].Cells[3].Value = "未借用";
                        dataGridView2.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        i++;
                    }
                }
                else
                {
                    string alldate = date.Text.Substring(date.Text.Length - 2);
                    string a = $@"SELECT
	                                *
	                                FROM
	                                dbo.Room
                                    WHERE
                                    BorrowDetail NOT LIKE '%{alldate + "-" + "下午"}%'";
                    sql.QuickRead(a);
                    int i = 0;
                    while (sql.HasRecord)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = sql["No"].ToString();
                        dataGridView2.Rows[i].Cells[1].Value = sql["Name"].ToString();
                        dataGridView2.Rows[i].Cells[2].Value = sql["State"].ToString();
                        dataGridView2.Rows[i].Cells[3].Value = "未借用";
                        dataGridView2.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        i++;
                    }
                }
                dataGridView2.Visible = true;
            }
            else
            {
                MessageBox.Show("请获取借用时间");
            }
        }

        private void 教材管理ToolStripMenuItem_Click(object sender, EventArgs e) //点击菜单转换tabcontrol
        {
            tabControl2.Visible = true;
            tabControl1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)   //书本查找
        {
            dataGridView3.Rows.Clear();
            returnbook.Visible = true;
            if (comboBox1.Text != "----请选择---")
            {
                string A = $@"SELECT
	                        SUBSTRING(B.No,1,11) AS TERM,
	                        B.CourseNo AS COUNO,
	                        C.Name AS COUSENAME,
	                        A.Isbn AS ISBN,
	                        A.Name BOOKNAME,
	                        A.Author AS AUTHOR,
	                        IIF(D.BookOrderFlag=1,'已订购','未订购') AS isnotorder
	                        FROM
	                        dbo.BOOK AS A
	                        JOIN dbo.TeachingTast AS B ON A.No = B.BookNo OR B.BookNo2=A.No
	                        JOIN dbo.Course AS C ON C.No = B.CourseNo
	                        JOIN dbo.StudentScore AS D ON D.TeachingTaskNo = B.No
	                        WHERE
	                        D.StudentNo = '{Studentno}' AND SUBSTRING(B.No,1,11) = '{comboBox1.Text}'";
                sql.QuickRead(A);
                int i = 0;
                while (sql.HasRecord)
                {
                    dataGridView3.Rows.Add();
                    dataGridView3.Rows[i].Cells[0].Value = sql["TERM"].ToString();
                    dataGridView3.Rows[i].Cells[1].Value = sql["COUNO"].ToString();
                    dataGridView3.Rows[i].Cells[2].Value = sql["COUSENAME"].ToString();
                    dataGridView3.Rows[i].Cells[3].Value = sql["ISBN"].ToString();
                    dataGridView3.Rows[i].Cells[4].Value = sql["BOOKNAME"].ToString();
                    dataGridView3.Rows[i].Cells[5].Value = sql["AUTHOR"].ToString();
                    dataGridView3.Rows[i].Cells[6].Value = sql["isnotorder"].ToString();
                    dataGridView3.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    i++;
                }
                dataGridView3.Visible = true;
            }
            else
            {
                MessageBox.Show("请先获取学期");
            }
        }

        private void returnbook_Click(object sender, EventArgs e)     //返回按钮
        {
            dataGridView3.Visible = false;
            returnbook.Visible = false;
        }

        public void getalltermplan()   //获取学期课程要求书籍
        {
            var a = $@"SELECT
                    	E.Name AS FNA,
	                    SUBSTRING(b.No,1,11) AS TERM,
	                    C.Name AS COUNAME,
	                    C.No AS COUNO,
	                    F.Isbn AS ISBN,
	                    F.Name AS BOOKNA,
	                    F.Author AS BOOKAUTH,
	                    F.Press AS PUBLICC,
	                    IIF(D.BookOrderFlag=1,'已定','未定') AS ISNOT
	                    FROM
	                    dbo.TeachingTast AS B 
	                    JOIN dbo.Course AS C ON C.No = B.CourseNo
	                    JOIN dbo.StudentScore AS D ON D.TeachingTaskNo = B.No
	                    JOIN dbo.Faculty AS E ON E.No = B.FacultyNo
	                    JOIN dbo.BOOK AS F ON B.BookNo2=F.No OR B.BookNo=F.No
	                    WHERE
	                    D.StudentNo = '{Studentno}' AND (SUBSTRING(B.No,1,4) = '{DateTime.Now.Year}' OR SUBSTRING(B.No,6,9)='{DateTime.Now.Year}')";
            sql.QuickRead(a);
            int i = 0;
            while (sql.HasRecord)
            {
                dataGridView4.Rows.Add();
                dataGridView4.Rows[i].Cells[0].Value = sql["FNA"].ToString();
                dataGridView4.Rows[i].Cells[1].Value = sql["COUNAME"].ToString();
                dataGridView4.Rows[i].Cells[2].Value = sql["TERM"].ToString();
                dataGridView4.Rows[i].Cells[3].Value = sql["BOOKNA"].ToString();
                dataGridView4.Rows[i].Cells[4].Value = sql["ISBN"].ToString();
                dataGridView4.Rows[i].Cells[5].Value = sql["BOOKAUTH"].ToString();
                dataGridView4.Rows[i].Cells[7].Value = sql["PUBLICC"].ToString();
                dataGridView4.Rows[i].Cells[6].Value = sql["ISNOT"].ToString();
                dataGridView4.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                i++;
            }
            if (dataGridView4.Rows[0].Cells[0].Value==null)
            {
                dataGridView4.Visible = false;
                label6.Visible = true;
            }
            else
            {
                dataGridView4.Visible = true;
                label6.Visible = false;
            }
        }

        private void 选课管理ToolStripMenuItem_Click(object sender, EventArgs e)   ////点击菜单转换tabcontrol
        {
            tabControl1.Visible = true;
            tabControl2.Visible = false;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e) //点击dataGridView订书及退书
        {
            if (e.RowIndex==8)
            {
                var a = $@"SELECT
	                    IIF(D.BookOrderFlag=1,'已定','未定') AS AAAA
	                    FROM
	                    dbo.TeachingTast AS B 
	                    JOIN dbo.Course AS C ON C.No = B.CourseNo
	                    JOIN dbo.StudentScore AS D ON D.TeachingTaskNo = B.No
	                    JOIN dbo.Faculty AS E ON E.No = B.FacultyNo
	                    JOIN dbo.BOOK AS F ON B.BookNo2=F.No OR B.BookNo=F.No
	                    WHERE
	                    D.StudentNo = '{Studentno}' AND F.Isbn='{dataGridView4.Rows[e.RowIndex].Cells[4].Value}'";
                sql.QuickRead(a);
                if (sql.HasRecord)
                {
                    if (sql["AAAA"].ToString() == "未定")
                    {
                        MessageBox.Show($@"是否选定{dataGridView4.Rows[e.RowIndex].Cells[3].Value}这本书", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (MessageBox.Show($@"是否选定{dataGridView4.Rows[e.RowIndex].Cells[3].Value}这本书", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            var abc = $@"UPDATE
	                                    dbo.StudentScore
	                                    SET
	                                    BookOrderFlag=1
	                                    WHERE
	                                    StudentNo='' AND
	                                    TeachingTaskNo=(
	                                    SELECT A.No 
	                                    FROM 
	                                    dbo.TeachingTast AS A
	                                    JOIN dbo.Course AS B ON B.No = A.CourseNo
	                                    JOIN dbo.BOOK AS C ON A.BookNo=C.No OR A.BookNo2 =C.No
	                                    JOIN dbo.StudentScore AS D ON D.TeachingTaskNo = A.No
	                                    WHERE D.StudentNo='{Studentno}' AND C.Name='{dataGridView4.Rows[e.RowIndex].Cells[3].Value}')";
                            int ab = sql.QuickSubmit(abc);
                            if (ab==1)
                            {
                                MessageBox.Show("已提交订阅");
                                getalltermplan();
                            }
                        }
                        else
                        {
                            getalltermplan();
                        }
                    }
                    else
                    {
                        MessageBox.Show($@"是否退订{dataGridView4.Rows[e.RowIndex].Cells[3].Value}这本书", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (MessageBox.Show($@"是否退订{dataGridView4.Rows[e.RowIndex].Cells[3].Value}这本书", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            var abc = $@"UPDATE
	                                    dbo.StudentScore
	                                    SET
	                                    BookOrderFlag=0
	                                    WHERE
	                                    StudentNo='' AND
	                                    TeachingTaskNo=(
	                                    SELECT A.No 
	                                    FROM 
	                                    dbo.TeachingTast AS A
	                                    JOIN dbo.Course AS B ON B.No = A.CourseNo
	                                    JOIN dbo.BOOK AS C ON A.BookNo=C.No OR A.BookNo2 =C.No
	                                    JOIN dbo.StudentScore AS D ON D.TeachingTaskNo = A.No
	                                    WHERE D.StudentNo='{Studentno}' AND C.Name='{dataGridView4.Rows[e.RowIndex].Cells[3].Value}')";
                            int ab = sql.QuickSubmit(abc);
                            if (ab == 1)
                            {
                                MessageBox.Show("已提交订阅");
                                getalltermplan();
                            }
                        }
                        else
                        {
                            getalltermplan();
                        }
                    }
                }
            }
        }
        public void getallplan()   //获取所有培养方案
        {
            string a = $@"SELECT
	                        A.No AS TERM,
	                        C.No AS COUNO,
	                        C.Name AS COUNA,
	                        C.Credit AS CRE,
	                        D.Name AS AAAAA
	                        FROM
	                        dbo.Term AS A
	                        JOIN dbo.TeachingTast AS B ON B.TermNo = A.No
	                        JOIN dbo.Course AS C ON C.No = B.CourseNo
	                        JOIN dbo.EXAMTYPE AS D ON D.No = C.ExamTypeNo
	                        JOIN dbo.StudentScore AS E ON E.TeachingTaskNo = B.No
	                        WHERE
	                        E.StudentNo='{Studentno}'";
            sql.QuickRead(a);
            int i = 0;
            while (sql.HasRecord)
            {
                dataGridView5.Rows.Add();
                dataGridView5.Rows[i].Cells[0].Value = sql["TERM"].ToString();
                dataGridView5.Rows[i].Cells[1].Value = sql["COUNO"].ToString();
                dataGridView5.Rows[i].Cells[2].Value = sql["COUNA"].ToString();
                dataGridView5.Rows[i].Cells[3].Value = sql["CRE"].ToString();
                dataGridView5.Rows[i].Cells[4].Value = sql["AAAAA"].ToString();
                i++;
            }
        }

        private void GetCouseLearn_FormClosing(object sender, FormClosingEventArgs e)   //窗口关闭后主页取消隐藏
        {
            aa.Show();
        }
        private void openselect(string select)    //通过初始化启动窗体时传入数值打开页面
        {
            if (select == "培养方案")
            {
                教材管理ToolStripMenuItem_Click(null, null);
                tabControl2.SelectedTab = tabPage2;
            }
            else if (select == "选课中心")
            {
                选课管理ToolStripMenuItem_Click(null, null);
                tabControl1.SelectedTab = searchcourse;
            }
            else
            {
                教材管理ToolStripMenuItem_Click(null, null);
                tabControl2.SelectedTab = tabPage2;
            }
        }
    }
}
