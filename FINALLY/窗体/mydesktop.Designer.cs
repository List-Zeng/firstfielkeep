namespace FINALLY
{
    partial class mydesktop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.我的桌面 = new System.Windows.Forms.TabControl();
            this.publicmessage = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsNotread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.priivatymessage = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Noget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getmessages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fromone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsNotREADER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.changemessage = new System.Windows.Forms.TabPage();
            this.keepques = new System.Windows.Forms.Button();
            this.getquesnull = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.answer2 = new System.Windows.Forms.TextBox();
            this.question2 = new System.Windows.Forms.TextBox();
            this.answer1 = new System.Windows.Forms.TextBox();
            this.question1 = new System.Windows.Forms.TextBox();
            this.stuname = new System.Windows.Forms.TextBox();
            this.onlineno = new System.Windows.Forms.TextBox();
            this.changepassword = new System.Windows.Forms.TabPage();
            this.getpassnull = new System.Windows.Forms.Button();
            this.keeppass = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.newpass1 = new System.Windows.Forms.TextBox();
            this.newpass = new System.Windows.Forms.TextBox();
            this.biginpass = new System.Windows.Forms.TextBox();
            this.onlineuserno = new System.Windows.Forms.TextBox();
            this.getmessageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mymaindatebaseDataSet = new FINALLY.MymaindatebaseDataSet();
            this.getmessageTableAdapter = new FINALLY.MymaindatebaseDataSetTableAdapters.GetmessageTableAdapter();
            this.mymaindatebaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getmessageBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mymaindatebaseDataSet1 = new FINALLY.MymaindatebaseDataSet1();
            this.publicMessageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.publicMessageTableAdapter = new FINALLY.MymaindatebaseDataSet1TableAdapters.PublicMessageTableAdapter();
            this.我的桌面.SuspendLayout();
            this.publicmessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.priivatymessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.changemessage.SuspendLayout();
            this.changepassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getmessageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mymaindatebaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mymaindatebaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getmessageBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mymaindatebaseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicMessageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // 我的桌面
            // 
            this.我的桌面.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.我的桌面.Controls.Add(this.publicmessage);
            this.我的桌面.Controls.Add(this.priivatymessage);
            this.我的桌面.Controls.Add(this.changemessage);
            this.我的桌面.Controls.Add(this.changepassword);
            this.我的桌面.Cursor = System.Windows.Forms.Cursors.Default;
            this.我的桌面.Location = new System.Drawing.Point(0, 1);
            this.我的桌面.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.我的桌面.Name = "我的桌面";
            this.我的桌面.SelectedIndex = 0;
            this.我的桌面.Size = new System.Drawing.Size(629, 330);
            this.我的桌面.TabIndex = 0;
            // 
            // publicmessage
            // 
            this.publicmessage.Controls.Add(this.dataGridView1);
            this.publicmessage.Location = new System.Drawing.Point(4, 25);
            this.publicmessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.publicmessage.Name = "publicmessage";
            this.publicmessage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.publicmessage.Size = new System.Drawing.Size(621, 301);
            this.publicmessage.TabIndex = 0;
            this.publicmessage.Text = "公告";
            this.publicmessage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Message,
            this.From,
            this.IsNotread,
            this.readit});
            this.dataGridView1.Location = new System.Drawing.Point(-5, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(629, 295);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.No.HeaderText = "序号";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Message
            // 
            this.Message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Message.HeaderText = "文本内容";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            // 
            // From
            // 
            this.From.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.From.HeaderText = "发件人";
            this.From.Name = "From";
            this.From.ReadOnly = true;
            // 
            // IsNotread
            // 
            this.IsNotread.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsNotread.HeaderText = "是否已读";
            this.IsNotread.Name = "IsNotread";
            this.IsNotread.ReadOnly = true;
            // 
            // readit
            // 
            this.readit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.readit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readit.HeaderText = "查看";
            this.readit.Name = "readit";
            this.readit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.readit.Text = "点击查看";
            this.readit.UseColumnTextForButtonValue = true;
            // 
            // priivatymessage
            // 
            this.priivatymessage.Controls.Add(this.dataGridView2);
            this.priivatymessage.Location = new System.Drawing.Point(4, 25);
            this.priivatymessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.priivatymessage.Name = "priivatymessage";
            this.priivatymessage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.priivatymessage.Size = new System.Drawing.Size(621, 301);
            this.priivatymessage.TabIndex = 1;
            this.priivatymessage.Text = "留言";
            this.priivatymessage.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Noget,
            this.getmessages,
            this.Fromone,
            this.IsNotREADER,
            this.Resent,
            this.Column1});
            this.dataGridView2.Location = new System.Drawing.Point(-4, 0);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(629, 305);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Noget
            // 
            this.Noget.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Noget.HeaderText = "序号";
            this.Noget.Name = "Noget";
            this.Noget.ReadOnly = true;
            // 
            // getmessages
            // 
            this.getmessages.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.getmessages.HeaderText = "留言主体";
            this.getmessages.Name = "getmessages";
            this.getmessages.ReadOnly = true;
            // 
            // Fromone
            // 
            this.Fromone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fromone.HeaderText = "发件人";
            this.Fromone.Name = "Fromone";
            this.Fromone.ReadOnly = true;
            // 
            // IsNotREADER
            // 
            this.IsNotREADER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsNotREADER.HeaderText = "是否已读";
            this.IsNotREADER.Name = "IsNotREADER";
            this.IsNotREADER.ReadOnly = true;
            // 
            // Resent
            // 
            this.Resent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Resent.HeaderText = "回复文本";
            this.Resent.Name = "Resent";
            this.Resent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Resent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "操作";
            this.Column1.Name = "Column1";
            this.Column1.Text = "回复";
            this.Column1.UseColumnTextForButtonValue = true;
            // 
            // changemessage
            // 
            this.changemessage.Controls.Add(this.keepques);
            this.changemessage.Controls.Add(this.getquesnull);
            this.changemessage.Controls.Add(this.label6);
            this.changemessage.Controls.Add(this.label5);
            this.changemessage.Controls.Add(this.label4);
            this.changemessage.Controls.Add(this.label3);
            this.changemessage.Controls.Add(this.label2);
            this.changemessage.Controls.Add(this.label1);
            this.changemessage.Controls.Add(this.answer2);
            this.changemessage.Controls.Add(this.question2);
            this.changemessage.Controls.Add(this.answer1);
            this.changemessage.Controls.Add(this.question1);
            this.changemessage.Controls.Add(this.stuname);
            this.changemessage.Controls.Add(this.onlineno);
            this.changemessage.Location = new System.Drawing.Point(4, 25);
            this.changemessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.changemessage.Name = "changemessage";
            this.changemessage.Size = new System.Drawing.Size(621, 301);
            this.changemessage.TabIndex = 2;
            this.changemessage.Text = "修改个人信息";
            this.changemessage.UseVisualStyleBackColor = true;
            // 
            // keepques
            // 
            this.keepques.Location = new System.Drawing.Point(220, 238);
            this.keepques.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.keepques.Name = "keepques";
            this.keepques.Size = new System.Drawing.Size(75, 32);
            this.keepques.TabIndex = 13;
            this.keepques.Text = "保存";
            this.keepques.UseVisualStyleBackColor = true;
            this.keepques.Click += new System.EventHandler(this.keepques_Click);
            // 
            // getquesnull
            // 
            this.getquesnull.Location = new System.Drawing.Point(331, 238);
            this.getquesnull.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getquesnull.Name = "getquesnull";
            this.getquesnull.Size = new System.Drawing.Size(75, 32);
            this.getquesnull.TabIndex = 12;
            this.getquesnull.Text = "重置";
            this.getquesnull.UseVisualStyleBackColor = true;
            this.getquesnull.Click += new System.EventHandler(this.getquesnull_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "回答二：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "密保问题二：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "回答一：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "密保问题一：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "真实姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "登录账号：";
            // 
            // answer2
            // 
            this.answer2.Location = new System.Drawing.Point(305, 190);
            this.answer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.answer2.Name = "answer2";
            this.answer2.ReadOnly = true;
            this.answer2.Size = new System.Drawing.Size(100, 25);
            this.answer2.TabIndex = 5;
            // 
            // question2
            // 
            this.question2.Location = new System.Drawing.Point(305, 159);
            this.question2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.question2.Name = "question2";
            this.question2.Size = new System.Drawing.Size(100, 25);
            this.question2.TabIndex = 4;
            this.question2.Validated += new System.EventHandler(this.question2_Validated);
            // 
            // answer1
            // 
            this.answer1.Location = new System.Drawing.Point(305, 128);
            this.answer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.answer1.Name = "answer1";
            this.answer1.ReadOnly = true;
            this.answer1.Size = new System.Drawing.Size(100, 25);
            this.answer1.TabIndex = 3;
            // 
            // question1
            // 
            this.question1.Location = new System.Drawing.Point(305, 98);
            this.question1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.question1.Name = "question1";
            this.question1.Size = new System.Drawing.Size(100, 25);
            this.question1.TabIndex = 2;
            this.question1.Validated += new System.EventHandler(this.question1_Validated);
            // 
            // stuname
            // 
            this.stuname.Location = new System.Drawing.Point(305, 66);
            this.stuname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stuname.Name = "stuname";
            this.stuname.Size = new System.Drawing.Size(100, 25);
            this.stuname.TabIndex = 1;
            // 
            // onlineno
            // 
            this.onlineno.Location = new System.Drawing.Point(305, 35);
            this.onlineno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.onlineno.Name = "onlineno";
            this.onlineno.ReadOnly = true;
            this.onlineno.Size = new System.Drawing.Size(100, 25);
            this.onlineno.TabIndex = 0;
            // 
            // changepassword
            // 
            this.changepassword.Controls.Add(this.getpassnull);
            this.changepassword.Controls.Add(this.keeppass);
            this.changepassword.Controls.Add(this.label10);
            this.changepassword.Controls.Add(this.label9);
            this.changepassword.Controls.Add(this.label8);
            this.changepassword.Controls.Add(this.label7);
            this.changepassword.Controls.Add(this.newpass1);
            this.changepassword.Controls.Add(this.newpass);
            this.changepassword.Controls.Add(this.biginpass);
            this.changepassword.Controls.Add(this.onlineuserno);
            this.changepassword.Location = new System.Drawing.Point(4, 25);
            this.changepassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.changepassword.Name = "changepassword";
            this.changepassword.Size = new System.Drawing.Size(621, 301);
            this.changepassword.TabIndex = 3;
            this.changepassword.Text = "修改密码";
            this.changepassword.UseVisualStyleBackColor = true;
            // 
            // getpassnull
            // 
            this.getpassnull.Location = new System.Drawing.Point(328, 204);
            this.getpassnull.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getpassnull.Name = "getpassnull";
            this.getpassnull.Size = new System.Drawing.Size(85, 30);
            this.getpassnull.TabIndex = 9;
            this.getpassnull.Text = "重置";
            this.getpassnull.UseVisualStyleBackColor = true;
            this.getpassnull.Click += new System.EventHandler(this.getpassnull_Click);
            // 
            // keeppass
            // 
            this.keeppass.Enabled = false;
            this.keeppass.Location = new System.Drawing.Point(215, 204);
            this.keeppass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.keeppass.Name = "keeppass";
            this.keeppass.Size = new System.Drawing.Size(85, 30);
            this.keeppass.TabIndex = 8;
            this.keeppass.Text = "保存";
            this.keeppass.UseVisualStyleBackColor = true;
            this.keeppass.Click += new System.EventHandler(this.keeppass_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(212, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 7;
            this.label10.Text = "确认密码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(227, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "新密码：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(227, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "原密码：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "登录账号：";
            // 
            // newpass1
            // 
            this.newpass1.Location = new System.Drawing.Point(300, 155);
            this.newpass1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newpass1.Name = "newpass1";
            this.newpass1.Size = new System.Drawing.Size(113, 25);
            this.newpass1.TabIndex = 3;
            this.newpass1.Validated += new System.EventHandler(this.newpass1_Validated);
            // 
            // newpass
            // 
            this.newpass.Location = new System.Drawing.Point(300, 124);
            this.newpass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newpass.Name = "newpass";
            this.newpass.Size = new System.Drawing.Size(113, 25);
            this.newpass.TabIndex = 2;
            // 
            // biginpass
            // 
            this.biginpass.Location = new System.Drawing.Point(300, 92);
            this.biginpass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.biginpass.Name = "biginpass";
            this.biginpass.Size = new System.Drawing.Size(113, 25);
            this.biginpass.TabIndex = 1;
            // 
            // onlineuserno
            // 
            this.onlineuserno.Location = new System.Drawing.Point(300, 62);
            this.onlineuserno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.onlineuserno.Name = "onlineuserno";
            this.onlineuserno.ReadOnly = true;
            this.onlineuserno.Size = new System.Drawing.Size(113, 25);
            this.onlineuserno.TabIndex = 0;
            // 
            // getmessageBindingSource
            // 
            this.getmessageBindingSource.DataMember = "Getmessage";
            this.getmessageBindingSource.DataSource = this.mymaindatebaseDataSet;
            // 
            // mymaindatebaseDataSet
            // 
            this.mymaindatebaseDataSet.DataSetName = "MymaindatebaseDataSet";
            this.mymaindatebaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getmessageTableAdapter
            // 
            this.getmessageTableAdapter.ClearBeforeFill = true;
            // 
            // mymaindatebaseDataSetBindingSource
            // 
            this.mymaindatebaseDataSetBindingSource.DataSource = this.mymaindatebaseDataSet;
            this.mymaindatebaseDataSetBindingSource.Position = 0;
            // 
            // getmessageBindingSource1
            // 
            this.getmessageBindingSource1.DataMember = "Getmessage";
            this.getmessageBindingSource1.DataSource = this.mymaindatebaseDataSet;
            // 
            // mymaindatebaseDataSet1
            // 
            this.mymaindatebaseDataSet1.DataSetName = "MymaindatebaseDataSet1";
            this.mymaindatebaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // publicMessageBindingSource
            // 
            this.publicMessageBindingSource.DataMember = "PublicMessage";
            this.publicMessageBindingSource.DataSource = this.mymaindatebaseDataSet1;
            // 
            // publicMessageTableAdapter
            // 
            this.publicMessageTableAdapter.ClearBeforeFill = true;
            // 
            // mydesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 328);
            this.Controls.Add(this.我的桌面);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mydesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "我的桌面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mydesktop_FormClosing);
            this.Load += new System.EventHandler(this.mydesktop_Load);
            this.我的桌面.ResumeLayout(false);
            this.publicmessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.priivatymessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.changemessage.ResumeLayout(false);
            this.changemessage.PerformLayout();
            this.changepassword.ResumeLayout(false);
            this.changepassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getmessageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mymaindatebaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mymaindatebaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getmessageBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mymaindatebaseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicMessageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl 我的桌面;
        private System.Windows.Forms.TabPage publicmessage;
        private System.Windows.Forms.TabPage priivatymessage;
        private System.Windows.Forms.TabPage changemessage;
        private System.Windows.Forms.Button keepques;
        private System.Windows.Forms.Button getquesnull;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox answer2;
        private System.Windows.Forms.TextBox question2;
        private System.Windows.Forms.TextBox answer1;
        private System.Windows.Forms.TextBox question1;
        private System.Windows.Forms.TextBox stuname;
        private System.Windows.Forms.TextBox onlineno;
        private System.Windows.Forms.TabPage changepassword;
        private System.Windows.Forms.Button getpassnull;
        private System.Windows.Forms.Button keeppass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox newpass1;
        private System.Windows.Forms.TextBox newpass;
        private System.Windows.Forms.TextBox biginpass;
        private System.Windows.Forms.TextBox onlineuserno;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MymaindatebaseDataSet mymaindatebaseDataSet;
        private System.Windows.Forms.BindingSource getmessageBindingSource;
        private MymaindatebaseDataSetTableAdapters.GetmessageTableAdapter getmessageTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource mymaindatebaseDataSetBindingSource;
        private System.Windows.Forms.BindingSource getmessageBindingSource1;
        private MymaindatebaseDataSet1 mymaindatebaseDataSet1;
        private System.Windows.Forms.BindingSource publicMessageBindingSource;
        private MymaindatebaseDataSet1TableAdapters.PublicMessageTableAdapter publicMessageTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsNotread;
        private System.Windows.Forms.DataGridViewButtonColumn readit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noget;
        private System.Windows.Forms.DataGridViewTextBoxColumn getmessages;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fromone;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsNotREADER;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resent;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
    }
}