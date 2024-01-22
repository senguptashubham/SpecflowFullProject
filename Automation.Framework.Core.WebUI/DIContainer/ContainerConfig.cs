using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.Reporting;
using Automation.Framework.Core.WebUI.Selenium.BrowserProfiles;
using Automation.Framework.Core.WebUI.Selenium.WebDrivers.LocalWebDriver;
using Automation.Framework.Core.WebUI.Selenium.WebDrivers.RemoteDriver;
using Automation.Framework.Core.WebUI.Test.Base;
using Automation.Framework.Core.WebUI.Test.Type;
using Automation.Framework.Core.WebUI.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Framework.Core.WebUI.Steps;
using Automation.Framework.Core.WebUI.UiObject;
using Automation.Framework.Core.WebUI.Selenium;
using Automation.Framework.Core.WebUI.WebSteps;

namespace Automation.Framework.Core.WebUI.DIContainer
{
    public class ContainerConfig
    {
        public static IServiceCollection serviceCollection;
        public static IServiceProvider ConfigureService()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IDefaultVariables, DefaultVariables>();
            serviceCollection.AddSingleton<ILogging, Logging>();
            serviceCollection.AddSingleton<IGlobalProperties, GlobalProperties>();
            serviceCollection.AddSingleton<IExtentReport, ExtentReport>();
            serviceCollection.AddTransient<IUiTestBase, UiTestBase>();
            serviceCollection.AddTransient<ITestBase, TestBase>();
            serviceCollection.AddTransient<ITestBaseManager, TestBaseManager>();
            serviceCollection.AddTransient<IBrowserType, BrowserType>();
            serviceCollection.AddTransient<IBrowserProfiles, ChromeProfiles>();
            serviceCollection.AddTransient<IBrowserProfiles, FirefoxProfiles>();
            serviceCollection.AddTransient<IDriver, ChromeWebDriver>();
            serviceCollection.AddTransient<IDriver, FirefoxWebDriver>();
            serviceCollection.AddTransient<IDriver, RemoteDriver>();
            serviceCollection.AddTransient<IVariableReplacer, VariableReplacer>();
            serviceCollection.AddTransient<ITestStepBuilder, TestStepBuilder>();
            serviceCollection.AddTransient<ITestStep, TestStep>();
            serviceCollection.AddTransient<IUiElementBuilder, UiElementBuilder>();
            serviceCollection.AddTransient<IUiElement, UiElement>();
            serviceCollection.AddTransient<IUiActions, UiActions>();
            serviceCollection.AddTransient<IUtilityActions, UtilityActions>();
            serviceCollection.AddTransient<IStepDefinitions, StepDefinitions>();
            serviceCollection.AddTransient<IExtentFeatureReport, ExtentFeatureReport>();
            return serviceCollection.BuildServiceProvider();
        }

    }
}
