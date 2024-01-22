using Automation.Framework.Core.WebUI.DIContainer;
using Automation.Framework.Core.WebUI.Runner;
using Automation.Framework.Core.WebUI.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.WebSteps
{

    [Binding]
  public  class StepDefinitions : IStepDefinitions
    {
        ITestBaseManager _itestBaseManager;
        ILogging _ilogging;
        ITestStepBuilder _itestStepBuilder;
        IUiElementBuilder _iuiElementBuilder;
        IUiActions _iuiActions;
        IUtilityActions _iutilityActions;     
        

        [BeforeStep]
        public void BeforeStep()
        {
            _itestStepBuilder = SpecflowRunner._iserviceProvider.GetRequiredService<ITestStepBuilder>();
            _iuiElementBuilder = SpecflowRunner._iserviceProvider.GetRequiredService<IUiElementBuilder>(); 
            _iuiActions= SpecflowRunner._iserviceProvider.GetRequiredService<IUiActions>();
            _iutilityActions = SpecflowRunner._iserviceProvider.GetRequiredService<IUtilityActions>();           
        }

        [Given(@"User is on the login page")]
        public void GivenUserIsOnTheLoginPage()
        {
            
        }

        [Given(@"I am on the page ""(.*)""")]
        public void GivenIAmOnThePage(string url)
        {
            
        }

        [When(@"I save value ""(.*)"" with key ""(.*)""")]
        public void WhenISaveValueWithKey(string value, string key)
        {
            
        }

        [When(@"I provide ""(.*)"" to locator ""(.*)""")]
        public void WhenIProvideToLocator(string value, string locator)
        {
            
        }

        [When(@"I click object ""(.*)""")]
        public void WhenIClickObject(string locator)
        {
            
        }

        [When(@"I fetch value of key ""(.*)"" and enter to locator ""(.*)""")]
        public void WhenIFetchValueOfKeyAndEnterToLocator(string key, string locator)
        {
          
        }


        [Given(@"User navigates to url ""(.*)""")]
        public void GivenUserNavigatesToUrl(string url)
        {
            _iuiActions.NavigateToUrl(_itestStepBuilder.SetParams(url).Build());
        }


        [When(@"User waits for ""(.*)""")]
        public void WhenUserWaitsFor(string wait)
        {
            _iuiActions.Wait(_itestStepBuilder.SetParams(wait).Build());
        }

        [When(@"User close the browser")]
        public void WhenUserCloseTheBrowser()
        {
            _iuiActions.CloseUiBrowser();
        }

        [When(@"User ""(.*)"" browser")]
        public void WhenUserBrowser(string browserActions)
        {
            _iuiActions.BrowserActions(_itestStepBuilder.SetParams(browserActions).Build());
        }

        [When(@"User switches to frame ""(.*)""")]
        public void WhenUserSwitchesToFrame(string frame)
        {
            _itestStepBuilder.SetParams(frame).Build();
        }

        [When(@"waits for ""(.*)"" seconds")]
        public void WhenWaitsForSeconds(string wait)
        {
            _itestStepBuilder.SetParams(wait).Build();
        }


        [When(@"User format date ""(.*)"" from old format ""(.*)"" to new format ""(.*)"" and save the result for key ""(.*)""")]
        public void WhenUserFormatDateToNewFormat(string date, string oldformat, string newformat, string key)
        {
            
        }

        [When(@"User runs query ""(.*)"" with connection ""(.*)"" and save with key ""(.*)""")]
        public void WhenUserRunsQueryAndSaveWithKey(string sqlQuery, string connection, string key)
        {
            
        }

        [When(@"User executes query ""(.*)"" with connection ""(.*)""")]
        public void WhenUserExecutesQuery(string sqlQuery, string connection)
        {
            
        }


       

        [When(@"User drag source element ""(.*)"" and drop to destination ""(.*)""")]
        public void WhenUserDragSourceElementAndDropToDestination(string source, string destination)
        {
            
        }

        [When(@"User enters text ""(.*)"" in ""(.*)""")]
        public void EnterText(string text, string locator)
        {
           _iuiActions.InputText(_itestStepBuilder.SetUiElement(_iuiElementBuilder.BuildFromNames(locator).Build()).SetParams(text).Build());

        }

        [When(@"User clears field ""(.*)""")]
        public void WhenUserClearsField(string locator)
        {
            _iuiActions.ClearText(_itestStepBuilder.SetUiElement(_iuiElementBuilder.BuildFromNames(locator).Build()).Build());            
           
        }


        [When(@"User clicks on ""(.*)""")]
        public void WhenUserClicksOn(string locator)
        {
            _iuiActions.Click(_itestStepBuilder.SetUiElement(_iuiElementBuilder.BuildFromNames(locator).Build()).Build());
        }

        [When(@"User double click on ""(.*)""")]
        public void WhenUserDoubleClickOn(string locator)
        {
            _iuiActions.DoubleClick(_itestStepBuilder.SetUiElement(_iuiElementBuilder.BuildFromNames(locator).Build()).Build());
        }


        [When(@"user right click on ""(.*)""")]
        public void WhenUserRightClickOn(string locator)
        {
            _iuiActions.RightClick(_itestStepBuilder.SetUiElement(_iuiElementBuilder.BuildFromNames(locator).Build()).Build());
        }

        [Then(@"verifies text is ""(.*)"" present on the page")]
        public void ThenVerifiesTextIsPresentOnThePage(string text)
        {
            _iuiActions.VerifyText(_itestStepBuilder.SetParams(text).Build());
        }



        [When(@"User saves value ""(.*)"" with key ""(.*)""")]
        public void WhenUserSavesValueWithKey(string value, string key)
        {
            
        }

        [When(@"User executes javascript ""(.*)""")]
        public void WhenUserExecutesJavascript(string script)
        {
            _iuiActions.ExecuteJavaScript(_itestStepBuilder.SetParams(script).Build());
        }

        [When(@"User click element ""(.*)"" with javascript")]
        public void WhenUserClickElementWithJavascript(string locator)
        {
            _iuiActions.ClickWithJavaScript(_itestStepBuilder.SetUiElement(_iuiElementBuilder.BuildFromNames(locator).Build()).Build());
        }

        [When(@"User generate a unique string prefix with ""(.*)"" and save with key ""(.*)""")]
        public void stepDefGenerateUniqueString(string prefix, string key)
        {
            _iutilityActions.UniqueString(_itestStepBuilder.SetParams(prefix, key).Build());
        }

        [When(@"User hover mouse ""(.*)""")]
        public void WhenUserHoverMouse(string locator)
        {
            _iuiActions.MouseHover(_itestStepBuilder.SetUiElement(_iuiElementBuilder.BuildFromNames(locator).Build()).Build());
        }

    }
}
