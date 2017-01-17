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
            this.btn_getAuthoredReviews = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dt_reviews)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(242, 29);
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
            this.RequestBodyTextBox.Location = new System.Drawing.Point(425, 29);
            this.RequestBodyTextBox.Multiline = true;
            this.RequestBodyTextBox.Name = "RequestBodyTextBox";
            this.RequestBodyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.RequestBodyTextBox.Size = new System.Drawing.Size(502, 189);
            this.RequestBodyTextBox.TabIndex = 8;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(94, 29);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(116, 23);
            this.txt_username.TabIndex = 9;
            this.txt_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_username_KeyPress);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(94, 59);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(116, 23);
            this.txt_password.TabIndex = 10;
            this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_password_KeyPress);
            // 
            // btn_getReviews
            // 
            this.btn_getReviews.Enabled = false;
            this.btn_getReviews.Location = new System.Drawing.Point(58, 129);
            this.btn_getReviews.Name = "btn_getReviews";
            this.btn_getReviews.Size = new System.Drawing.Size(235, 40);
            this.btn_getReviews.TabIndex = 11;
            this.btn_getReviews.Text = "Get Reviews";
            this.btn_getReviews.UseVisualStyleBackColor = true;
            this.btn_getReviews.Click += new System.EventHandler(this.btn_getReviews_Click);
            // 
            // lbl_reviewCount
            // 
            this.lbl_reviewCount.AutoSize = true;
            this.lbl_reviewCount.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reviewCount.Location = new System.Drawing.Point(159, 249);
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
            this.dt_reviews.Location = new System.Drawing.Point(58, 283);
            this.dt_reviews.Name = "dt_reviews";
            this.dt_reviews.ReadOnly = true;
            this.dt_reviews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_reviews.Size = new System.Drawing.Size(869, 412);
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
            this.Link.Visible = false;
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
            this.notifierIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifierIcon.Text = "Crucible Notifier";
            this.notifierIcon.Visible = true;
            this.notifierIcon.DoubleClick += new System.EventHandler(this.restore);
            // 
            // btn_logout
            // 
            this.btn_logout.Enabled = false;
            this.btn_logout.Location = new System.Drawing.Point(242, 59);
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
            this.label1.Location = new System.Drawing.Point(55, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Review Count:";
            // 
            // timer_getReviews
            // 
            this.timer_getReviews.Enabled = true;
            this.timer_getReviews.Interval = 300000;
            this.timer_getReviews.Tick += new System.EventHandler(this.timer_getReviews_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Password:";
            // 
            // btn_getAuthoredReviews
            // 
            this.btn_getAuthoredReviews.Enabled = false;
            this.btn_getAuthoredReviews.Location = new System.Drawing.Point(58, 176);
            this.btn_getAuthoredReviews.Name = "btn_getAuthoredReviews";
            this.btn_getAuthoredReviews.Size = new System.Drawing.Size(235, 42);
            this.btn_getAuthoredReviews.TabIndex = 20;
            this.btn_getAuthoredReviews.Text = "Get Authored Review";
            this.btn_getAuthoredReviews.UseVisualStyleBackColor = true;
            this.btn_getAuthoredReviews.Click += new System.EventHandler(this.btn_getAuthoredReviews_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1057, 721);
            this.Controls.Add(this.btn_getAuthoredReviews);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.dt_reviews);
            this.Controls.Add(this.lbl_reviewCount);
            this.Controls.Add(this.btn_getReviews);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.RequestBodyTextBox);
            this.Controls.Add(this.btn_login);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Review Notifier 0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Resize += new System.EventHandler(this.minimize);
            ((System.ComponentModel.ISupportInitialize)(this.dt_reviews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Timer timer_getReviews;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeReviewID;
        private System.Windows.Forms.DataGridViewLinkColumn Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.Button btn_getAuthoredReviews;
    }
}

