using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
   public interface IBrowserProfiles
    {
        DriverOptions GetBrowserProfile();

        bool IsApplicable(Browsers browsers);
    }
}
