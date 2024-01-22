using Automation.Framework.Core.WebUI.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
   public interface ITestStepBuilder
    {
        TestStepBuilder SetParams(params string[] param);
        ITestStep Build();

        TestStepBuilder SetUiElement(IUiElement iuiElement);
    }
}
