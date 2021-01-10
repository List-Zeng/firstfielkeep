using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartLinli.DatabaseDevelopement;
using FINALLY.窗体;

namespace FINALLY
{
    public partial class getonline : Form
    {
        public getonline()
        {
            InitializeComponent();
            this.FormClosed += (_, __) =>  //close（）函数调用时启动
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            };
        }
        
        private void getbt_Click(object sender, EventArgs e) //登录采用非对称加密密码，课上没怎么讲，线下看着学了下怎么加密解密
        {
            string connextion = $@"SELECT
	                                    1
	                                    FROM
	                                    dbo.Users
	                                    WHERE
	                                    No='{studentno.Text}' AND 
	                                    CONVERT(VARCHAR(128),DECRYPTBYASYMKEY(AsymKey_Id('ak_EduBase_ForSymKeyCrypto'),
	                                    ENCRYPTBYASYMKEY(AsymKey_ID('ak_EduBase_ForSymKeyCrypto'),CONVERT(VARBINARY(MAX),Password)),N'1qaz@WSX')) = '{studentpassword.Text}'";
            SqlHelper sqlHelper = new SqlHelper();
            int a = sqlHelper.QuickReturn<int>(connextion);
            if (a == 1)
            {
                MessageBox.Show("登陆成功");
                MainPage getCouseLearn = new MainPage(studentno.Text);
                getCouseLearn.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("登陆失败，账号或密码有误！");
                studentpassword.Text = "";
            }
        }

        private void getnewbt_Click(object sender, EventArgs e) //注册按钮，新增账户
        {
            SqlHelper sqlHelper = new SqlHelper();
            string a = $@"SELECT 1
                            FROM dbo.Users
                            WHERE
                            No='{studentno.Text}'";
            int aa = sqlHelper.QuickReturn<int>(a);
            if (aa == 1)
            {
                MessageBox.Show("注册失败，用户名已存在");
            }
            else if (aa == 0)
            {
                string connext = $@"INSERT
	                            dbo.Users
	                            (
	                                No,
	                                Password,
	                                Question1,
	                                Answer1,
	                                LastModifyTime,
	                                Question2,
	                                Answer2
	                            )
	                            VALUES
	                            (   '{studentno.Text}',                    -- No - varchar(20)
	                                '{studentpassword.Text}',                    -- Password - varchar(128)
	                                '',                    -- Question1 - varchar(100)
	                                NULL,                  -- Answer1 - varbinary(128)
	                                GETDATE(), -- LastModifyTime - smalldatetime
	                                '',                    -- Question2 - varchar(50)
	                                NULL                   -- Answer2 - varbinary(128)
	                                )";
                int ab = sqlHelper.QuickSubmit(connext);
                if (ab == 1)
                {
                    MessageBox.Show("注册成功");
                }
            }
        }

        private void getonline_FormClosing(object sender, FormClosingEventArgs e) //手动关闭时启动，close（）函数启动时也会调用该函数
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
}
