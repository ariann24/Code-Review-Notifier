using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeReviewNotifier.Model;
using System.Diagnostics;
using System.Threading;

namespace CodeReviewNotifier
{
    public partial class Form1 : Form
    {
        private Crucible _crucible = new Crucible();

        public Form1()
        {
            InitializeComponent();
            notifierIcon.Icon = this.GetIcon("0");
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            RequestBodyTextBox.Text = _crucible.Login(txt_username.Text, txt_password.Text);
            if (_crucible.IsLogin)
            {
                btn_logout.Enabled = true;
                btn_getReviews.Enabled = true;
                btn_login.Enabled = false;
                btn_getAuthoredReviews.Enabled = true;
                timer_getReviews.Start();
            }
        }

        private void btn_getReviews_Click(object sender, EventArgs e)
        {
            // Set Data from Server
            RequestBodyTextBox.Text = _crucible.GetReviewsString();

            // Set Review Count
            lbl_reviewCount.Text = _crucible.ReviewCount.ToString();
            
            // Set Review Links
            List<Review> _reviews = _crucible.GetReviews();
            this.dt_reviews.Rows.Clear();
            foreach (Review _review in _reviews)
            {
                // Make the http://crucible.ncr.com:8060/cru/ configurable
                this.dt_reviews.Rows.Add(_review.Author, _review.PermID, "http://crucible.ncr.com:8060/cru/" + _review.PermID, _review.State);
            }

            notifierIcon.Icon = this.GetIcon(_reviews.Count.ToString());
        }
        public System.Diagnostics.Process p = new System.Diagnostics.Process();

        private void richTextBox1_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            // Call Process.Start method to open a browser
            // with link text as URL.
            p = System.Diagnostics.Process.Start(e.LinkText);
        }

        private void minimize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState) {
                Hide();
            }
        }
        private void restore(object sender, System.EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }


        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                this.btn_login.PerformClick();
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                this.btn_login.PerformClick();
            }
        }

        private void dt_reviews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dt_reviews.Rows.Count > 0 && e.ColumnIndex == 1) {
                string DT_REVIEWS = this.dt_reviews.Rows[e.RowIndex].Cells["Link"].Value.ToString();
                Process.Start(DT_REVIEWS);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) {
                this.WindowState = FormWindowState.Normal;
            }
         }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
            dt_reviews.Rows.Clear();
            RequestBodyTextBox.Clear();
            lbl_reviewCount.Text = "0";
            _crucible.Logout();

            btn_logout.Enabled = false;
            btn_getReviews.Enabled = false;
            btn_login.Enabled = true;

            timer_getReviews.Stop();
            notifierIcon.Icon = this.GetIcon("0");
        }

        private void timer_getReviews_Tick(object sender, EventArgs e)
        {
            this.btn_getReviews.PerformClick();
            if (_crucible.ReviewCount > 0)
            {
                string CRUCIBLE_NOTIFIER = "You have " + _crucible.ReviewCount + " review(s).";
                notifierIcon.ShowBalloonTip(0, "Crucible Notifier", CRUCIBLE_NOTIFIER, ToolTipIcon.Info);
                notifierIcon.Text = "Inbox: " + _crucible.ReviewCount;
                notifierIcon.Icon = this.GetIcon(_crucible.ReviewCount.ToString());
            }
        }

        public Icon GetIcon(string text)
        {
            float left = -1f,
                right = -2f;
            Color fontColor = Color.DarkBlue;
            //Create bitmap, kind of canvas
            Bitmap bitmap = new Bitmap(16, 16);
            if (text.Length == 1)
            {
                left = 2;
            }
            if (text == "0")
            {
                text = "C";
                fontColor = Color.White;
            }

            Icon icon = new Icon(@"Image\cyra.ico");
            System.Drawing.Font drawFont = new System.Drawing.Font("Calibri", 11, FontStyle.Bold);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(fontColor);
            PointF drawPoint = new PointF(left, right);

            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);

            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            graphics.DrawIcon(icon, 0, 0);
            graphics.DrawString(text, drawFont, drawBrush, drawPoint);

            //To Save icon to disk
            bitmap.Save("icon.ico", System.Drawing.Imaging.ImageFormat.Icon);

            Icon createdIcon = Icon.FromHandle(bitmap.GetHicon());

            drawFont.Dispose();
            drawBrush.Dispose();
            graphics.Dispose();
            bitmap.Dispose();

            return createdIcon;
        }

        private void btn_getAuthoredReviews_Click(object sender, EventArgs e)
        {
            // Set Data from Server1
            List<Review> _reviews = _crucible.GetAuthoredReviews();
            this.dt_reviews.Rows.Clear();
            foreach (Review _review in _reviews)
            {
                this.dt_reviews.Rows.Add(_review.Author, _review.PermID, "http://crucible.ncr.com:8060/cru/" + _review.PermID, _review.State);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
