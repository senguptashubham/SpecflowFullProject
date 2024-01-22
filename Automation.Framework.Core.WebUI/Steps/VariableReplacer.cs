using Automation.Framework.Core.WebUI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Steps
{
 public   class VariableReplacer : IVariableReplacer
    {
        ITestBaseManager _itestBaseManager;
        ILogging _ilogging;
        IGlobalProperties _iglobalProperties;
        string _input;
        string _startindicator;
        string _endindicator;
        List<string> _dataVariables;
        public VariableReplacer(IGlobalProperties iglobalProperties,ILogging ilogging,ITestBaseManager itestBaseManager)
        {
            _itestBaseManager = itestBaseManager;
            _iglobalProperties = iglobalProperties;
            _ilogging = ilogging;
        }

        public VariableReplacer SetDataSet(string value,string startIndicator,string endIndicator)
        {
            _dataVariables = new List<string>();
            _input = value;
            _startindicator = startIndicator;
            _endindicator = endIndicator;
            return this;
        }

        public string GetConfigValues()
        {
            foreach(string param in _dataVariables)
            {
                _input = _input.Replace(_startindicator + param + _endindicator,_iglobalProperties.GetProperty(param));
            }
            return _input;
        }

        public string GetTestDataSet()
        {
            foreach(string param in _dataVariables)
            {
                _input = _input.Replace(_startindicator + param + _endindicator, _itestBaseManager.GetTestBase().GetDataSet(param));
            }
            return _input;
        }

        public VariableReplacer GetAllVariables()
        {
            for (int i = _input.IndexOf(_startindicator, 0); i != -1 && _input.IndexOf(_startindicator, i) >= 0
                                                  && _input.IndexOf(_endindicator, i) >= 0; i = _input.IndexOf(_endindicator, i) + 1)
            {
                _dataVariables.Add(_input.Substring(_input.IndexOf(_startindicator, i) + _startindicator.Length
                                             , _input.IndexOf(_endindicator, i) - (_input.IndexOf(_startindicator, i) + _startindicator.Length)));
            }
            return this;
        }
    }
}
