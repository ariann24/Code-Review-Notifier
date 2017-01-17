using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CodeReviewNotifier.Service;
using System.Collections.ObjectModel;
using CodeReviewNotifier.Model;
using System.Diagnostics;
using CodeReviewNotifier.Helper;
using System.Windows.Forms;

namespace CodeReviewNotifier.ViewModel
{
    class ReviewViewModel : ViewModelBase
    {
        #region Property declarations

        public string username;
        public string currentUserName;
        public string password;
        public string author;
        public string codeReviewID;
        public string linkID;
        public string state;
        public string loginPageVisibility;
        public string reviewPageVisibility;
        public string invalidCredentials;
        public Review selectedReview;
        public int codeReviewCount;
        public int timerInterval;
        public string welcomeText;
        public int myReviewMonths;
        public bool isClicked;
        public string settingsPageVisibility;
        public Browser selectedBrowser;

        public string Username
        {
            get { return username; }
            set
            {
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

        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                RaisePropertyChanged("Author");
            }
        }

        public string CodeReviewID
        {
            get { return codeReviewID; }
            set
            {
                codeReviewID = value;
                RaisePropertyChanged("CodeReviewID");
            }
        }

        public string LinkID
        {
            get { return linkID; }
            set
            {
                linkID = value;
                RaisePropertyChanged("LinkID");
            }
        }

        public string State
        {
            get { return state; }
            set
            {
                state = value;
                RaisePropertyChanged("State");
            }
        }

        public string LoginPageVisibility
        {
            get { return loginPageVisibility; }
            set
            {
                loginPageVisibility = value;
                RaisePropertyChanged("LoginPageVisibility");
            }
        }

        public string ReviewPageVisibility
        {
            get { return reviewPageVisibility; }
            set
            {
                reviewPageVisibility = value;
                RaisePropertyChanged("ReviewPageVisibility");
            }
        }

        public string InvalidCredentials
        {
            get { return invalidCredentials; }
            set
            {
                invalidCredentials = value;
                RaisePropertyChanged("InvalidCredentials");
            }
        }

        public Review SelectedReview
        {
            get { return selectedReview; }
            set
            {
                selectedReview = value;
                RaisePropertyChanged("SelectedReview");
            }
        }

        public int CodeReviewCount
        {
            get { return codeReviewCount; }
            set
            {
                codeReviewCount = value;
                RaisePropertyChanged("CodeReviewCount");
            }
        }

        public int TimerInterval
        {
            get { return timerInterval; }
            set
            {
                timerInterval = value;
                RaisePropertyChanged("TimerInterval");
            }
        }

        public string WelcomeText
        {
            get { return welcomeText; }
            set
            {
                welcomeText = value;
                RaisePropertyChanged("WelcomeText");
            }
        }

        public int MyReviewMonths
        {
            get { return myReviewMonths; }
            set
            {
                myReviewMonths = value;
                RaisePropertyChanged("MyReviewMonths");
            }
        }
        public string UserName
        {
            get { return currentUserName; }
            set
            {
                currentUserName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public bool IsUserNameClicked 
        {
            get { return isClicked; }
            set
            {
                isClicked = value;
                RaisePropertyChanged("IsUserNameClicked");
            }
        }

        public string SettingsPageVisibility 
        {
            get { return settingsPageVisibility; }
            set 
            {
                settingsPageVisibility = value;
                RaisePropertyChanged("SettingsPageVisibility");
            }
        }

        public Browser SelectedBrowser
        {
            get { return selectedBrowser; }
            set
            {
                selectedBrowser = value;
                RaisePropertyChanged("SelectedBrowser");
            }
        }
        public ObservableCollection<ReviewListItem> Reviews
        { get; set; }
        public ObservableCollection<ReviewListItem> ModeratorReviews
        { get; set; }
        public ObservableCollection<ReviewListItem> MyReviews
        { get; set; }

        public ObservableCollection<Browser> Browsers
        { get; set; }


        #endregion Property declarations

        // Command Declarations
        public ICommand LoginCommand { get; set; }
        public ICommand EnterKeyCommand { get; set; }
        public ICommand GetReviewsCommand { get; set; }
        public ICommand GetModeratorReviewCommand { get; set; }
        public ICommand SetTimerIntervalCommand { get; set; }
        public ICommand OpenSettingsPageCommand { get; set; }
        public ICommand SetSettingsCommand { get; set; }
        public ICommand CloseSettingsPageCommand { get; set; }
        public ICommand LogOutCommand { get; set; }

        private Crucible _crucible;
        private Settings _settings;

        public ReviewViewModel()
        {
            LoginCommand = new ReviewCommand(Login);
            GetReviewsCommand = new ReviewCommand(GetAllReviews);
            GetModeratorReviewCommand = new ReviewCommand(GetModeratorReviews);
            SetTimerIntervalCommand = new ReviewCommand(SetTimerInterval);
            OpenSettingsPageCommand = new ReviewCommand(OpenSettingsPage);
            CloseSettingsPageCommand = new ReviewCommand(CloseSettingsPage);
            _crucible = new Crucible();
            _settings = new Settings();
            Reviews = new ObservableCollection<ReviewListItem>();
            ModeratorReviews = new ObservableCollection<ReviewListItem>();
            MyReviews = new ObservableCollection<ReviewListItem>();
            MyReviewMonths = 6;
            Browsers = new ObservableCollection<Browser>();
            LogOutCommand = new ReviewCommand(LogOut);
        }

        public void Login()
        {
                if (_crucible.Login(Username, Password))
                {
                    LoginPageVisibility = "Hidden";
                    ReviewPageVisibility = "Visible";
                    InvalidCredentials = "Hidden";
                    SettingsPageVisibility = "Hidden";
                    this.GetAllReviews();
                    WelcomeText = String.Format("こんにちは  {0}!", _crucible.GetProfile().Name);
                    UserName = _crucible.GetProfile().Name;
                    this.GetWebBrowsers();
                }
                InvalidCredentials = "Visible";
        }

        private void GetReviews()
        {
            Reviews.Clear();

            List<Review> reviewList = _crucible.GetReviews();

            foreach (Review review in reviewList)
            {
                DateTime reviewDate = Convert.ToDateTime(review.DateCreated);
                List<Comment> comments = _crucible.GetComments(review.PermID);
                List<Comment> unreadComments = _crucible.GetUnreadComments(comments);
                Reviews.Add(new ReviewListItem()
                {
                    Author = review.Author,
                    PermID = review.PermID,
                    Description = review.Name,
                    DateCreated = String.Format("{0:MMMM dd, yyyy}", reviewDate),
                    State = review.State,
                    Comments = comments.Count,
                    UnreadComments = unreadComments.Count,
                    CommentCountDisplay = unreadComments.Count > 0 ? String.Format("{0} ({1})", comments.Count, unreadComments.Count) : comments.Count.ToString()
                });
            }
        }

        private void GetModeratorReviews()
        {
            ModeratorReviews.Clear();

            List<Review> reviewList = _crucible.GetModeratorReviews();

            foreach (Review review in reviewList)
            {
                DateTime reviewDate = Convert.ToDateTime(review.DateCreated);
                List<Comment> comments = _crucible.GetComments(review.PermID);
                List<Comment> unreadComments = _crucible.GetUnreadComments(comments);
                ModeratorReviews.Add(new ReviewListItem()
                {
                    Author = review.Author,
                    PermID = review.PermID,
                    Description = review.Name,
                    DateCreated = String.Format("{0:MMMM dd, yyyy}", reviewDate),
                    State = review.State,
                    Comments = comments.Count,
                    UnreadComments = unreadComments.Count,
                    CommentCountDisplay = unreadComments.Count > 0 ? String.Format("{0} ({1})", comments.Count, unreadComments.Count) : comments.Count.ToString(),
                    ReviewsStatus = review.AllReviewersCompleted ? "Complete" : "Incomplete"
                });


            }
        }
        
        private void GetMyReviews()
        {
            MyReviews.Clear();

            List<Review> reviewList = _crucible.GetMyReviews(MyReviewMonths);

            foreach (Review review in reviewList)
            {
                DateTime reviewDate = Convert.ToDateTime(review.DateCreated);
                List<Comment> comments = _crucible.GetComments(review.PermID);
                List<Comment> unreadComments = _crucible.GetUnreadComments(comments);
                MyReviews.Add(new ReviewListItem()
                {
                    Author = review.Author,
                    PermID = review.PermID,
                    Description = review.Name,
                    DateCreated = String.Format("{0:MMMM dd, yyyy}", reviewDate),
                    State = review.State,
                    Comments = comments.Count,
                    UnreadComments = unreadComments.Count,
                    CommentCountDisplay = unreadComments.Count > 0 ? String.Format("{0} ({1})", comments.Count, unreadComments.Count) : comments.Count.ToString()
                });
            }
        }

        private void SetTimerInterval()
        {
            int milliseconds = 0;
            milliseconds = (TimerInterval * 60) * 1000;

            if (milliseconds < 10000)
            {
                TimerInterval = 1;
                milliseconds = 1800000;
            }

            WindowsFormHelper.SetTimerInterval(milliseconds);
        }

        private int GetCodeReviewCount()
        {
            CodeReviewCount = ModeratorReviews.Count + Reviews.Count + MyReviews.Count;
            WindowsFormHelper.SetCodeReviewCount(CodeReviewCount);
            WindowsFormHelper.SetNotifyToolTipInfo(Reviews.Count, ModeratorReviews.Count, MyReviews.Count);
            return CodeReviewCount;
        }

        public void GoToReview(object selectedItem)
        {
            if (selectedItem != null)
            {
                ReviewListItem r = selectedItem as ReviewListItem;
                if (SelectedBrowser != null)
                {
                    Process.Start(SelectedBrowser.Path, "http://crucible.ncr.com:8060/cru/" + r.PermID);
                }
                else
                {
                    Process.Start("http://crucible.ncr.com:8060/cru/" + r.PermID);
                }
            }
        }

        public void GetAllReviews()
        {
            this.GetReviews();
            this.GetModeratorReviews();
            this.GetMyReviews();
            this.GetCodeReviewCount();
        }

        public void OpenSettingsPage()
        {
            SettingsPageVisibility = "Visible";
        }

        public void GetWebBrowsers()
        {
            List<Browser> browserList = _settings.GetAvailableBrowsers();
            foreach (Browser _browser in browserList)
            {
                Browsers.Add(new Browser()
                {
                    Name = _browser.Name,
                    IconPath = _browser.IconPath,
                    Path = _browser.Path
                });
            }
        }

        public void CloseSettingsPage() 
        {
            SettingsPageVisibility = "Hidden";
        }

        public void LogOut()
        {
            _crucible.Logout();
            Username = "";
            LoginPageVisibility = "Visible";
            ReviewPageVisibility = "Hidden";
            InvalidCredentials = "Hidden";
            SettingsPageVisibility = "Hidden";
            WindowsFormHelper.ClearPassword();
        }
    }
}
