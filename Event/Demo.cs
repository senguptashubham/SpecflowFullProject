using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Event
{
    [Binding]
   public class Demo
    {
        IStepDefinitions _istepDefinitions;
        ITestBaseManager _itestBaseManager;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _istepDefinitions = SpecflowRunner._iserviceProvider.GetRequiredService<IStepDefinitions>();
            _istepDefinitions.BeforeStep();
            _itestBaseManager = SpecflowRunner._iserviceProvider.GetRequiredService<ITestBaseManager>();
        }

        [Given(@"user login to saucelab application")]
        public void SupplierLogin()
        {
            if (_itestBaseManager.GetUiTestBase().GetWebDriver() != null)
            {
                Console.WriteLine("Invoked browser");
            }
            _istepDefinitions.GivenUserNavigatesToUrl("<#url#>");
            _istepDefinitions.EnterText("standard_user", "SauceLabLogin.txtUsername");
            _istepDefinitions.EnterText("secret_sauce", "SauceLabLogin.txtPassword");
            _istepDefinitions.WhenUserClicksOn("SauceLabLogin.btnLogin");
        }
    }
}
