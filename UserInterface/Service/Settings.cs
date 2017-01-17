using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeReviewNotifier.Model;
using Microsoft.Win32;

namespace CodeReviewNotifier.Service
{
    class Settings
    {   
        public List<Browser> GetAvailableBrowsers()
        {   
            List<Browser> availableBrowsers = new List<Browser>();
            
            RegistryKey browserKeys;

            browserKeys =   Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
            if (browserKeys == null)
            {
                browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
            }

            string[] browserNames = browserKeys.GetSubKeyNames();
            foreach (string browser in browserNames)
            {   
                Browser browserObj = new Browser();
                RegistryKey browserKey = browserKeys.OpenSubKey(browser);
                browserObj.Name = (string)browserKey.GetValue(null);
                RegistryKey browserKeyPath = browserKey.OpenSubKey(@"shell\open\command");
                browserObj.Path = (string)browserKeyPath.GetValue(null).ToString();
                RegistryKey browserIconPath = browserKey.OpenSubKey(@"DefaultIcon");
                browserObj.IconPath = (string)browserIconPath.GetValue(null).ToString();

                availableBrowsers.Add(browserObj);
            }
            return availableBrowsers;
        }
    }
}
