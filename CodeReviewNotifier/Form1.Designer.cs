namespace CodeReviewNotifier
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_login = new System.Windows.Forms.Button();
            this.RequestBodyTextBox = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_getReviews = new System.Windows.Forms.Button();
            this.lbl_reviewCount = new System.Windows.Forms.Label();
            this.dt_reviews = new System.Windows.Forms.DataGridView();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeReviewID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewLinkColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notifierIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btn_logout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer_getReviews = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.signOnPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dt_reviews)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.signOnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(128, 146);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(87, 27);
            this.btn_login.TabIndex = 0;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // RequestBodyTextBox
            // 
            this.RequestBodyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestBodyTextBox.Location = new System.Drawing.Point(12, 516);
            this.RequestBodyTextBox.Multiline = true;
            this.RequestBodyTextBox.Name = "RequestBodyTextBox";
            this.RequestBodyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.RequestBodyTextBox.Size = new System.Drawing.Size(376, 135);
            this.RequestBodyTextBox.TabIndex = 8;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(128, 39);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(168, 23);
            this.txt_username.TabIndex = 9;
            this.txt_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_username_KeyPress);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(128, 78);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(168, 23);
            this.txt_password.TabIndex = 10;
            this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_password_KeyPress);
            // 
            // btn_getReviews
            // 
            this.btn_getReviews.Enabled = false;
            this.btn_getReviews.Location = new System.Drawing.Point(13, 10);
            this.btn_getReviews.Name = "btn_getReviews";
            this.btn_getReviews.Size = new System.Drawing.Size(169, 40);
            this.btn_getReviews.TabIndex = 11;
            this.btn_getReviews.Text = "Get Reviews";
            this.btn_getReviews.UseVisualStyleBackColor = true;
            this.btn_getReviews.Click += new System.EventHandler(this.btn_getReviews_Click);
            // 
            // lbl_reviewCount
            // 
            this.lbl_reviewCount.AutoSize = true;
            this.lbl_reviewCount.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reviewCount.Location = new System.Drawing.Point(113, 63);
            this.lbl_reviewCount.Name = "lbl_reviewCount";
            this.lbl_reviewCount.Size = new System.Drawing.Size(15, 18);
            this.lbl_reviewCount.TabIndex = 14;
            this.lbl_reviewCount.Text = "0";
            // 
            // dt_reviews
            // 
            this.dt_reviews.AllowUserToAddRows = false;
            this.dt_reviews.AllowUserToDeleteRows = false;
            this.dt_reviews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_reviews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Author,
            this.CodeReviewID,
            this.Link,
            this.State});
            this.dt_reviews.Location = new System.Drawing.Point(12, 101);
            this.dt_reviews.Name = "dt_reviews";
            this.dt_reviews.ReadOnly = true;
            this.dt_reviews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_reviews.Size = new System.Drawing.Size(919, 412);
            this.dt_reviews.TabIndex = 16;
            this.dt_reviews.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_reviews_CellClick);
            // 
            // Author
            // 
            this.Author.FillWeight = 75F;
            this.Author.HeaderText = "Author";
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            // 
            // CodeReviewID
            // 
            this.CodeReviewID.FillWeight = 75F;
            this.CodeReviewID.HeaderText = "Code Review ID";
            this.CodeReviewID.Name = "CodeReviewID";
            this.CodeReviewID.ReadOnly = true;
            // 
            // Link
            // 
            this.Link.HeaderText = "Link";
            this.Link.Name = "Link";
            this.Link.ReadOnly = true;
            this.Link.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Link.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // State
            // 
            this.State.FillWeight = 75F;
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // notifierIcon
            // 
            this.notifierIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifierIcon.Icon")));
            this.notifierIcon.Text = "Crucible Notifier";
            this.notifierIcon.Visible = true;
            this.notifierIcon.DoubleClick += new System.EventHandler(this.restore);
            this.notifierIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btn_logout
            // 
            this.btn_logout.Enabled = false;
            this.btn_logout.Location = new System.Drawing.Point(861, 10);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(87, 26);
            this.btn_logout.TabIndex = 17;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Review Count:";
            // 
            // timer_getReviews
            // 
            this.timer_getReviews.Interval = 30000;
            this.timer_getReviews.Tick += new System.EventHandler(this.timer_getReviews_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Password:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Controls.Add(this.btn_login);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_username);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_password);
            this.groupBox1.Location = new System.Drawing.Point(323, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 223);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Welcome to CRUNOS";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.btn_getReviews);
            this.mainPanel.Controls.Add(this.btn_logout);
            this.mainPanel.Controls.Add(this.RequestBodyTextBox);
            this.mainPanel.Controls.Add(this.dt_reviews);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.lbl_reviewCount);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(951, 654);
            this.mainPanel.TabIndex = 21;
            // 
            // signOnPanel
            // 
            this.signOnPanel.BackColor = System.Drawing.Color.Transparent;
            this.signOnPanel.Controls.Add(this.groupBox1);
            this.signOnPanel.Location = new System.Drawing.Point(12, 3);
            this.signOnPanel.Name = "signOnPanel";
            this.signOnPanel.Size = new System.Drawing.Size(951, 663);
            this.signOnPanel.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(975, 678);
            this.Controls.Add(this.signOnPanel);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ";";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Resize += new System.EventHandler(this.minimize);
            ((System.ComponentModel.ISupportInitialize)(this.dt_reviews)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.signOnPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox RequestBodyTextBox;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_getReviews;
        private System.Windows.Forms.Label lbl_reviewCount;
        private System.Windows.Forms.DataGridView dt_reviews;
        private System.Windows.Forms.NotifyIcon notifierIcon;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeReviewID;
        private System.Windows.Forms.DataGridViewLinkColumn Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.Timer timer_getReviews;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel signOnPanel;
    }
}

