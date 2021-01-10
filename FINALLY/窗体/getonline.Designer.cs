namespace FINALLY
{
    partial class getonline
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.studentno = new System.Windows.Forms.TextBox();
            this.studentpassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.getbutton = new System.Windows.Forms.Button();
            this.getnewbt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentno
            // 
            this.studentno.Location = new System.Drawing.Point(132, 80);
            this.studentno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.studentno.Name = "studentno";
            this.studentno.Size = new System.Drawing.Size(100, 25);
            this.studentno.TabIndex = 0;
            // 
            // studentpassword
            // 
            this.studentpassword.Location = new System.Drawing.Point(132, 154);
            this.studentpassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.studentpassword.Name = "studentpassword";
            this.studentpassword.PasswordChar = '*';
            this.studentpassword.Size = new System.Drawing.Size(100, 25);
            this.studentpassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "学号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码";
            // 
            // getbutton
            // 
            this.getbutton.Location = new System.Drawing.Point(172, 216);
            this.getbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getbutton.Name = "getbutton";
            this.getbutton.Size = new System.Drawing.Size(71, 30);
            this.getbutton.TabIndex = 4;
            this.getbutton.Text = "登录";
            this.getbutton.UseVisualStyleBackColor = true;
            this.getbutton.Click += new System.EventHandler(this.getbt_Click);
            // 
            // getnewbt
            // 
            this.getnewbt.Location = new System.Drawing.Point(83, 216);
            this.getnewbt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getnewbt.Name = "getnewbt";
            this.getnewbt.Size = new System.Drawing.Size(72, 30);
            this.getnewbt.TabIndex = 5;
            this.getnewbt.Text = "注册";
            this.getnewbt.UseVisualStyleBackColor = true;
            this.getnewbt.Click += new System.EventHandler(this.getnewbt_Click);
            // 
            // getonline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 329);
            this.Controls.Add(this.getnewbt);
            this.Controls.Add(this.getbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.studentpassword);
            this.Controls.Add(this.studentno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "getonline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.getonline_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox studentno;
        private System.Windows.Forms.TextBox studentpassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button getbutton;
        private System.Windows.Forms.Button getnewbt;
    }
}

