using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeReviewNotifier.Service;

namespace CodeReviewNotifier.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        public string username;
        public string password;
        public bool isLogin;

        private Crucible _crucible;

        public LoginViewModel()
        {
            _crucible = new Crucible();
        }

        public string Username
        {
            get { return username; }
            set {
                username = value;
                RaisePropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        public bool IsLogin
        {
            get { return isLogin; }
            set
            {
                isLogin = value;
                RaisePropertyChanged("IsLogin");
            }
        }

        public void Login()
        {
            _crucible.Login(username, password);
            IsLogin = true;
        }

    }
}
