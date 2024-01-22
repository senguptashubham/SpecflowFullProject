using Automation.Framework.Core.WebUI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Steps
{
   public class TestStep : ITestStep
    {
        List<string> _parameters;

        IUiElement _iuiElement;
        IVariableReplacer _ivariableReplacer;
        public TestStep(IVariableReplacer ivariableReplacer)
        {
            _ivariableReplacer = ivariableReplacer;
            _parameters = new List<string>();
        }
        public void SetParameters(List<string> parameters)
        {
            this._parameters = parameters;
        }

        public IUiElement GetUiElement()
        {
            return _iuiElement;
        }

        public string GetParameter(int index)
        {
            return _parameters[index];
        }

        public void SetUiObject(IUiElement iuiElement)
        {
            this._iuiElement = iuiElement;
        }

        public ITestStep Run()
        {            
            CheckVars();
            return this;
        }

        public void CheckVars()
        {
            if (_iuiElement != null)
            {
                _iuiElement.GetLocator();
            }

            for(int i = 0; i < _parameters.Count; i++)
            {
                _parameters[i] = ReplaceVariables(_parameters[i]);            
            }
        }

        public string ReplaceVariables(string str)
        {
           return CheckTestData(str);
        }

        public string CheckTestData(string parameter)
        {
          return  CheckConfigData(_ivariableReplacer.SetDataSet(parameter, "<$", "$>").GetAllVariables().GetTestDataSet()
                );
        }

        public string CheckConfigData(string parameter)
        {
           return _ivariableReplacer.SetDataSet(parameter, "<#", "#>").GetAllVariables().GetConfigValues();
        }
    }
}
