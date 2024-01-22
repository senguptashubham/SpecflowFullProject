using Automation.Framework.Core.WebUI.Abstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Selenium.WebDrivers.LocalWebDriver
{
  public  class FirefoxWebDriver : IDriver
    {
        IDefaultVariables _idefaultVariables;
        public FirefoxWebDriver(IDefaultVariables idefaultVariables)
        {
            _idefaultVariables = idefaultVariables;
        }
        public IWebDriver GetWebDriver(DriverOptions options)
        {
            return new FirefoxDriver(_idefaultVariables.Resources, (FirefoxOptions)options);
        }

        public bool IsApplicable(Browsers browsers)
        {
            switch (browsers)
            {
                case Browsers.firefox:
                    return true;
                default:
                    return false;
            }
        }
    }
}
