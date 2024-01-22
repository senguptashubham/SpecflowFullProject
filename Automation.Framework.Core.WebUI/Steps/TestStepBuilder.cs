using Automation.Framework.Core.WebUI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Steps
{
    public class TestStepBuilder : ITestStepBuilder
    {
        ITestStep _itestSteps;

        public TestStepBuilder(ITestStep itestStep)
        {
            this._itestSteps = itestStep;
        }

        public TestStepBuilder SetParams(params string[] param)
        {
            this._itestSteps.SetParameters(param.ToList<string>());
            return this;
        }

        public TestStepBuilder SetUiElement(IUiElement iuiElement)
        {
            _itestSteps.SetUiObject(iuiElement);
            return this;
        }

        public ITestStep Build()
        {
            return this._itestSteps.Run(); ;
        }

    }
}

