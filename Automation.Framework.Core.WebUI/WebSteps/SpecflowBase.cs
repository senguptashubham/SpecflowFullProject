using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Runner;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.WebSteps
{
    [Binding]
  public  class SpecflowBase
    {
        ScenarioContext _scenarioContext;
        ITestBaseManager _itestBaseManager;
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _itestBaseManager =SpecflowRunner._iserviceProvider.GetRequiredService<ITestBaseManager>();
            _itestBaseManager.GetTestBase().GetExtentFeatureReport().CreateScenario(scenarioContext.ScenarioInfo.Title);
        }
        [AfterScenario]
        public void AfterScenario()
        {
           IExtentReport iextentReport =SpecflowRunner._iserviceProvider.GetRequiredService<IExtentReport>();
            iextentReport.FlushExtentReport();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            ITestBaseManager itestBaseManager = SpecflowRunner._iserviceProvider.GetRequiredService<ITestBaseManager>();
           string base64= ((ITakesScreenshot)_itestBaseManager.GetUiTestBase().GetWebDriver()).GetScreenshot().AsBase64EncodedString;
            if (scenarioContext.TestError == null)
            {
                itestBaseManager.GetTestBase().GetExtentFeatureReport().Pass(scenarioContext.StepContext.StepInfo.Text,null);
            }
            else
            {                
                itestBaseManager.GetTestBase().GetExtentFeatureReport().Fail(scenarioContext.StepContext.StepInfo.Text,base64);
            }
        }
    }
}
