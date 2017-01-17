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
using CodeReviewNotifier.Model;
using CodeReviewNotifier;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Threading;
using WPFTaskbarNotifierExample;

namespace CodeReviewNotifierUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool START_REVIEW = false;
        private Crucible _crucible = new Crucible();
        private DataTable data = new DataTable();
        private DispatcherTimer dispatcherTimer;
        private ExampleTaskbarNotifier taskbarNotifier;
        private string CRUCIBLE_NOTIFIER = null;
        private string COMMENT_NOTIFIER = null;

        public MainWindow()
        {
            this.taskbarNotifier = new ExampleTaskbarNotifier();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
            InitializeComponent();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (_crucible.ReviewCount > 0)
            {
                CRUCIBLE_NOTIFIER = "You have " + _crucible.ReviewCount + " review(s).";
                COMMENT_NOTIFIER = "You have" + _crucible.ReviewCount + "unleave comments(s)";

                if ((CRUCIBLE_NOTIFIER != string.Empty) && (COMMENT_NOTIFIER != string.Empty))
                {
                    this.taskbarNotifier.NotifyContent.Add(new NotifyObject(CRUCIBLE_NOTIFIER, COMMENT_NOTIFIER));
                    this.ClearTextBoxes();
                    this.taskbarNotifier.Notify();
                }
            }
        }

        private void ClearTextBoxes()
        {
            this.CRUCIBLE_NOTIFIER = string.Empty;
            this.COMMENT_NOTIFIER = string.Empty;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            signOutBox.Text = Login.USER_NAME;
        }

        public void startReview()
        {
            START_REVIEW = true;
        }

        private void getReviews_Click(object sender, RoutedEventArgs e)
        {
            // Set Review Count
            labelCount.Content = _crucible.ReviewCount.ToString();
            
            List<Review> _reviews = _crucible.GetReviews();
            this.dataGrid1.RowValidationRules.Clear();
            var row = data.NewRow();

            foreach (Review _review in _reviews)
            {
                data.Rows.Add(row);
                row["Author"] = _review.Author;
                row["Code Review ID"] = _review.PermID;
                row["Link ID"] = "http://crucible.ncr.com:8060/cru/" + _review.PermID;
                row["State"] = _review.State;
            }

            //notifierIcon.Icon = this.GetIcon(_reviews.Count.ToString());
        }

        public DataTable Data1
        { get { return data; } }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = dataGrid1.ItemsSource as IEnumerable;
            if (itemsSource == null) yield return null;
            foreach (var item in itemsSource)
            {
                var row = dataGrid1.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield     
                return row;
            }
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var row_list = GetDataGridRows(dataGrid1);
                foreach (DataGridRow single_row in row_list)
                {
                    if (single_row.IsSelected == true)
                    {
                        MessageBox.Show("the row no." + single_row.GetIndex().ToString() + " is selected!");
                        //Process.Start(single_row.GetIndex().ToString());
                    }
                }
            }
            catch { }
        }

        private void tabItem1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
         CRUCIBLE_NOTIFIER = "You have " + _crucible.ReviewCount + " review(s).";
         COMMENT_NOTIFIER = "You have" + _crucible.ReviewCount + "unleave comments(s)";

         if ((CRUCIBLE_NOTIFIER.Trim() != string.Empty) && (COMMENT_NOTIFIER.Trim() != string.Empty))
         {
            this.taskbarNotifier.NotifyContent.Add(new NotifyObject(CRUCIBLE_NOTIFIER, COMMENT_NOTIFIER));
            this.taskbarNotifier.Notify();
         }
        }
    }
}
