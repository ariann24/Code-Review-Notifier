using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace CodeReviewNotifier.Helper
{
    public class WindowsFormHelper
    {
        public static Window WPFWindow { get; set; }

        public static void SetCodeReviewCount(int count)
        {
            ((MainWindow)WPFWindow).SetIconCount(count);
            ((MainWindow)WPFWindow).MyTimer.Start();
        }

        public static void SetNotifyToolTipInfo(int reviewCount, int moderatorCount, int myReviewCount)
        {
            ((MainWindow)WPFWindow).MyNotifyIcon.BalloonTipTitle = "Code Reviews";
            ((MainWindow)WPFWindow).MyNotifyIcon.BalloonTipText = string.Format("Review: {0}\nModerator: {1}\nMy Review: {2}", reviewCount, moderatorCount, myReviewCount);
            ((MainWindow)WPFWindow).MyNotifyIcon.ShowBalloonTip(1000);
        }

        public static void SetTimerInterval(int interval)
        {
            ((MainWindow)WPFWindow).MyTimer.Interval = interval;
        }

        public static void ClearPassword()
        {
            ((MainWindow)WPFWindow).txtPassword.Password = "";
        }
    }
}
