using Automation.Framework.Core.WebUI.WebSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
  public  interface IStepDefinitions
    {
        void EnterText(string text, string locator);
        void WhenUserClicksOn(string locator);
        void BeforeStep();
        void GivenUserNavigatesToUrl(string url);

    }
}
