using Automation.Framework.Core.WebUI.Abstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Test.Base
{
   public class UiTestBase : TestBase, IUiTestBase
    {
        IWebDriver _iwebDriver;
        IDefaultVariables _idefaultVariables;
        IGlobalProperties _iglobalProperties;
        IBrowserType _ibrowserType;
        IEnumerable<IBrowserProfiles> _ibrowserProfiles;
        IEnumerable<IDriver> _idriver;
        public UiTestBase(IDefaultVariables idefaultVariables,IGlobalProperties iglobalProperties,IBrowserType ibrowserType
            ,IEnumerable<IBrowserProfiles> ibrowserProfiles,IEnumerable<IDriver> idriver)
        {
            _idefaultVariables = idefaultVariables;
            _iglobalProperties = iglobalProperties;
            _ibrowserType = ibrowserType;
            _ibrowserProfiles = ibrowserProfiles;
            _idriver = idriver;
        }

        public void CloseBrowser()
        {
            _iwebDriver.Close();
        }

        public IWebDriver GetWebDriver()
        {
            if (_iwebDriver == null)
            {
                GetNewWebDriver();
            }
            return _iwebDriver;
        }
        private void GetNewWebDriver()
        {
            DriverOptions driverOptions = null;         


            foreach (var driver in _idriver)
            {
                if (driver.IsApplicable(_ibrowserType.GetBrowser(_iglobalProperties.BrowserType.ToLower())))
                {
                    foreach (var profile in _ibrowserProfiles)
                    {
                        if (profile.IsApplicable(_ibrowserType.GetBrowser(_iglobalProperties.BrowserType.ToLower())))
                        {
                            driverOptions = profile.GetBrowserProfile();
                            break;
                        }
                    }
                    _iwebDriver = driver.GetWebDriver(driverOptions);
                    break;
                }
            }
           
           //_iwebDriver = new ChromeDriver(_idefaultVariables.Resources);
        }
    }
}
