using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
 public  interface IUiElement
    {
        void BuildFromElements(IList<string> locators);
        void GetLocator();

        IWebElement GetElement(int index);
    }
}
