using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
  public  interface ITestStep
    {
        void SetParameters(List<string> parameters);

        void SetUiObject(IUiElement iuiElement);

        ITestStep Run();

        string GetParameter(int index);
        IUiElement GetUiElement();
    }
}
