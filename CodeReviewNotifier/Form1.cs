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

namespace CodeReviewNotifier
{
    public partial class Form1 : Form
    {
        private Crucible _crucible = new Crucible();

        public Form1()
        {
            InitializeComponent();
            mainPanel.Hide();
            signOnPanel.Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            RequestBodyTextBox.Text = _crucible.Login(txt_username.Text, txt_password.Text); 
            if (_crucible.IsLogin)
            {
                btn_logout.Enabled = true;
                btn_getReviews.Enabled = true;
                btn_login.Enabled = false;
                timer_getReviews.Start();
                mainPanel.Show();
                signOnPanel.Hide();
            }
        }

        private void btn_getReviews_Click(object sender, EventArgs e)
        {
            // Set Data from Server
            RequestBodyTextBox.Text = _crucible.GetReviewsString();

            // Set Review Count
            lbl_reviewCount.Text = "Count: " + _crucible.ReviewCount;
            
            // Set Review Links
            List<Review> _reviews = _crucible.GetReviews();
            this.dt_reviews.Rows.Clear();
            foreach (Review _review in _reviews)
            {
                // Make the http://crucible.ncr.com:8060/cru/ configurable
                this.dt_reviews.Rows.Add(_review.Author, _review.PermID, "http://crucible.ncr.com:8060/cru/" + _review.PermID, _review.State);
            }
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

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }


        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btn_login.PerformClick();
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btn_login.PerformClick();
            }
        }

        private void dt_reviews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string DT_REVIEWS = this.dt_reviews.Rows[e.RowIndex].Cells["Link"].Value.ToString();
            Process.Start(DT_REVIEWS);   
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) 
                this.WindowState = FormWindowState.Normal;
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
            mainPanel.Hide();
            signOnPanel.Show();
        }

        private void timer_getReviews_Tick(object sender, EventArgs e)
        {
            this.btn_getReviews.PerformClick();
        }       
 
    }
}
