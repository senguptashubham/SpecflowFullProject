using Automation.Framework.Core.WebUI.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
   public interface IVariableReplacer
    {
        VariableReplacer SetDataSet(string value, string startIndicator, string endIndicator);
        VariableReplacer GetAllVariables();

        string GetTestDataSet();
    }
}
