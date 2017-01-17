using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CodeReviewNotifier.ViewModel;
using System.Data;
using System.Windows.Interop;
using System.Drawing;
using CodeReviewNotifier.Helper;

namespace CodeReviewNotifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ReviewViewModel _reviewVM = new ReviewViewModel();
        public System.Windows.Forms.NotifyIcon MyNotifyIcon;
        public System.Windows.Forms.ContextMenuStrip ContextMenuStripIcon;
        public System.Windows.Forms.Timer MyTimer;
        public System.Windows.Forms.WebBrowser browser;

        private const int DEFAULT_TIME = 1800000; // 30 minutes
        private const int DEFAULT_TIME_MINUTES = 30;
        private const string DEFAULT_NOTIFY_COUNT = "";

        public MainWindow()
        {
            InitializeComponent();
            _reviewVM.RequestClose += delegate
            {
                Close();
            };

            _reviewVM.ReviewPageVisibility = "Hidden";
            _reviewVM.InvalidCredentials = "Hidden";
            _reviewVM.SettingsPageVisibility = "Hidden";
            _reviewVM.TimerInterval = DEFAULT_TIME_MINUTES;
            DataContext = _reviewVM; 

            MyNotifyIcon = new System.Windows.Forms.NotifyIcon();
            MyNotifyIcon.Icon = this.GetIcon(_reviewVM.CodeReviewCount == 0 ? DEFAULT_NOTIFY_COUNT : _reviewVM.CodeReviewCount.ToString());
            MyNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(MyNotifyIcon_MouseDoubleClick);
            MyNotifyIcon.Visible = true;

           // browser = new System.Windows.Forms.WebBrowser();
           


            ContextMenuStripIcon = new System.Windows.Forms.ContextMenuStrip();
            ContextMenuStripIcon.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(item1_Click);
            ContextMenuStripIcon.Items.Add("Show");
            ContextMenuStripIcon.Items.Add("Sign Off");
            ContextMenuStripIcon.Items.Add("Update Reviews");
            ContextMenuStripIcon.Items.Add("Exit");

            MyTimer = new System.Windows.Forms.Timer();
            MyTimer.Interval = DEFAULT_TIME;
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyNotifyIcon.ContextMenuStrip = ContextMenuStripIcon;
            WindowsFormHelper.WPFWindow = this;
        }

        private void SavePassword(object sender, TextChangedEventArgs e)
        {
            _reviewVM.Password = plain.Text;
        }

        private void Row_Select(object sender, SelectedCellsChangedEventArgs e)
        {
            int index = gridReview.CurrentCell.Column.DisplayIndex;

            if (index == 0)
            {
                _reviewVM.GoToReview(gridReview.SelectedItem);
            }
            gridReview.SelectedItem = null;
        }

        private void ModeratorRow_Select(object sender, SelectedCellsChangedEventArgs e)
        {
            int index = gridModeratorReview.CurrentCell.Column.DisplayIndex;

            if (index == 0)
            {
                _reviewVM.GoToReview(gridModeratorReview.SelectedItem);
            }
            gridModeratorReview.SelectedItem = null;
        }

        private void MyReviewRow_Select(object sender, SelectedCellsChangedEventArgs e)
        {
            int index = gridMyReview.CurrentCell.Column.DisplayIndex;

            if (index == 0)
            {
                _reviewVM.GoToReview(gridMyReview.SelectedItem);
            }
            gridMyReview.SelectedItem = null;
        }

        void MyNotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.ShowInTaskbar = true;
            this.Activate();
        }

        void item1_Click(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Show") 
            {
                this.WindowState = WindowState.Normal;
                this.Activate();
            }
            else if (e.ClickedItem.Text == "Sign Off")
            {
                _reviewVM.LogOut();
            }
            else if (e.ClickedItem.Text == "Update Reviews")
            {
                _reviewVM.GetAllReviews();
            }
            else if (e.ClickedItem.Text == "Exit") 
            {
                Application.Current.Shutdown();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MyNotifyIcon.Visible = false;
        }

        /// <summary>
        /// Creating Icon Dynamically with text
        /// </summary>
        /// <param name="text">Text to display in the icon</param>
        /// <returns>Created Icon</returns>
        /// <misc>Saving icon to disk: bitmap.Save("icon.ico", System.Drawing.Imaging.ImageFormat.Icon);</misc>
        public Icon GetIcon(string text)
        {
            float left = 3,
                top = -0.5f,
                fontSize = 9f;
            Icon icon;
            System.Drawing.Color fontColor = System.Drawing.Color.DarkBlue;
            //Create bitmap, kind of canvas
            Bitmap bitmap = new Bitmap(16, 16);
            if (text == DEFAULT_NOTIFY_COUNT)
            {
                icon = new Icon(@"Images\cyra.ico");
            }
            else
            {
                icon = new Icon(@"Images\cyra_active.ico");
            }
            if (text.Length >= 2)
            {
                left = 1;
                top = -0.5f;
                fontSize = 7.5f;
            }

            System.Drawing.Font drawFont = new System.Drawing.Font("Calibri", fontSize, System.Drawing.FontStyle.Bold);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(fontColor);
            PointF drawPoint = new PointF(left, top);

            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);

            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            graphics.DrawIcon(icon, 0, 0);
            graphics.DrawString(text, drawFont, drawBrush, drawPoint);

            System.Drawing.Icon createdIcon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());

            drawFont.Dispose();
            drawBrush.Dispose();
            graphics.Dispose();
            bitmap.Dispose();

            return createdIcon;
        }

        public void SetIconCount(int count)
        {
            MyNotifyIcon.Icon = this.GetIcon(count == 0 ? DEFAULT_NOTIFY_COUNT : count.ToString());
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            _reviewVM.GetAllReviews();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
        }

        private void txtUsername_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                _reviewVM.Login();
            }
        }

        private void txtPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                _reviewVM.Login();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = WindowState.Minimized;
        }
    }
}
