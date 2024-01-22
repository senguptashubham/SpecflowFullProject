using Automation.Framework.Core.WebUI.Abstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Selenium.BrowserProfiles
{
   public class ChromeProfiles : IBrowserProfiles
    {
        IGlobalProperties _iglobalProperties;
        public ChromeProfiles(IGlobalProperties iglobalProperties)
        {
            _iglobalProperties = iglobalProperties;
        }
        public DriverOptions GetBrowserProfile()
        {
            var options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.AddExcludedArgument("enable-automation");            
            options.AddArgument("disable-extensions");
            options.AddArgument("disable-infobars");
            options.AddArgument("disable-notifications");
            options.AddArgument("disable-web-security");
            options.AddArgument("dns-prefetch-disable");
            options.AddArgument("disable-browser-side-navigation");
            options.AddArgument("disable-gpu");
            options.AddArgument("always-authorize-plugins");
            options.AddArgument("load-extension=src/main/resources/chrome_load_stopper");
            options.AddUserProfilePreference("download.default_directory", _iglobalProperties.DownloadedLocation);
            return options;
        }

        public bool IsApplicable(Browsers browsers)
        {
            switch (browsers)
            {
                case Browsers.chrome:
                case Browsers.remotechrome:
                    return true;
                default:
                    return false;
            }
        }
    }
}
