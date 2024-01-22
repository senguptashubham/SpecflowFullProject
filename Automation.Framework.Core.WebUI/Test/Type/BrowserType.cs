using Automation.Framework.Core.WebUI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Test.Type
{
   public class BrowserType : IBrowserType
    {

        public Browsers GetBrowser(string browser)
        {
            switch (browser)
            {
                case "chrome":
                    return Browsers.chrome;
                case "firefox":
                    return Browsers.firefox;
                case "remote-chrome":
                case "remote chrome":
                case "remotechrome":
                    return Browsers.remotechrome;
                case "remote firefox":
                case "remote-firefox":
                case "remotefirefox":
                    return Browsers.remotefirefox;
                default:
                    return Browsers.chrome;                    
            }
        }
    }
}
