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
using System.Windows.Shapes;
using CodeReviewNotifier;

namespace CodeReviewNotifierUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Crucible _crucible = new Crucible();
        private string REQUESTED_BODY_TEXT = null;
        private MainWindow main;
        public static string USER_NAME = null;

        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Username.Focus();
            main = new MainWindow();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            string password = Password.Password.ToString();
            REQUESTED_BODY_TEXT = _crucible.Login(Username.Text, password);
            if (_crucible.IsLogin)
            {
                main.startReview();
                this.Hide();
                USER_NAME = Username.Text;
                mainWindow.Show();
            }
            else {
                MessageBox.Show("Invalid Username or Password","Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Username.Focus();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
