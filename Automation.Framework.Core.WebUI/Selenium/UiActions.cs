using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.CustomException;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Selenium
{
   public class UiActions : IUiActions
    {
        ITestBaseManager _itestBaseManager;
        ILogging _ilogging;
        public UiActions(ITestBaseManager itestBaseManager,ILogging ilogging)
        {
            _itestBaseManager = itestBaseManager;
            _ilogging = ilogging;
        }

        public void NavigateToUrl(ITestStep itestStep)
        {
            try
            {
                _itestBaseManager.GetUiTestBase().GetWebDriver().Navigate().GoToUrl(itestStep.GetParameter(0));
            }
            catch(Exception e)
            {
                _ilogging.Error("Error while navigating to url. " + itestStep.GetParameter(0));
                throw new AutomationException("Error while navigating to url. " + itestStep.GetParameter(0));
            }           
        }

        public void Wait(ITestStep itestStep)
        {
            try
            {
                int wait = Convert.ToInt32(itestStep.GetParameter(0));
                Thread.Sleep(wait);
            }
            catch(Exception e)
            {
                _ilogging.Error("Error while converting input to int: " + e.Message);
                throw new AutomationException("Error while converting input to int: " + e.Message);
            }
        }

        public void CloseUiBrowser()
        {
            _itestBaseManager.GetUiTestBase().CloseBrowser();
        }

        public void BrowserActions(ITestStep itestStep)
        {
            switch (itestStep.GetParameter(0).ToLower())
            {
                case "refresh":
                    _itestBaseManager.GetUiTestBase().GetWebDriver().Navigate().Refresh();
                    break;
                case "back":
                    _itestBaseManager.GetUiTestBase().GetWebDriver().Navigate().Back();
                    break;
                case "minimize":
                    _itestBaseManager.GetUiTestBase().GetWebDriver().Manage().Window.Minimize();
                    break;
                case "maximize":
                    _itestBaseManager.GetUiTestBase().GetWebDriver().Manage().Window.Maximize();
                    break;
                default:
                    _ilogging.Error("You have selected wrong option for browser actions. Please select refresh/back/minimize/maximize.");
                    throw new AutomationException("You have selected wrong option for browser actions. Please select refresh/back/minimize/maximize.");                    
            }
        }

        public void InputText(ITestStep itestStep)
        {
            IWebElement webElement = itestStep.GetUiElement().GetElement(0);
           
            webElement.SendKeys(itestStep.GetParameter(0));
        }

        public void ClearText(ITestStep itestStep)
        {
            IWebElement webElement = itestStep.GetUiElement().GetElement(0);            
            webElement.Click();            
            webElement.SendKeys(Keys.Control + "a");
            webElement.SendKeys(Keys.Delete);
        }

        public void Click(ITestStep itestStep)
        {

            for(int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = itestStep.GetUiElement().GetElement(0);                    
                    Actions actions = new Actions(_itestBaseManager.GetUiTestBase().GetWebDriver());
                    actions.MoveToElement(webElement).Click().Build().Perform();
                    break;
                }
                catch (StaleElementReferenceException staleElement) { }
                catch (ElementClickInterceptedException interceptedException) { }
            }    
        }

        public void DoubleClick(ITestStep itestStep)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = itestStep.GetUiElement().GetElement(0);
                    Actions actions = new Actions(_itestBaseManager.GetUiTestBase().GetWebDriver());
                    actions.MoveToElement(webElement).DoubleClick().Build().Perform();
                    break;
                }
                catch (StaleElementReferenceException staleElement) { }
                catch (ElementClickInterceptedException interceptedException) { }
            }
        }

        public void RightClick(ITestStep itestStep)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = itestStep.GetUiElement().GetElement(0);
                    Actions actions = new Actions(_itestBaseManager.GetUiTestBase().GetWebDriver());
                    actions.MoveToElement(webElement).ContextClick().Build().Perform();
                    break;
                }
                catch (StaleElementReferenceException staleElement) { }
                catch (ElementClickInterceptedException interceptedException) { }
            }
        }

        public void VerifyText(ITestStep itestStep)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(_itestBaseManager.GetUiTestBase().GetWebDriver(), TimeSpan.FromSeconds(10));
                webDriverWait.IgnoreExceptionTypes(typeof(ElementNotVisibleException), typeof(StaleElementReferenceException), typeof(NoSuchElementException));
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'" + itestStep.GetParameter(0) + "')]")));
            }
            catch(Exception e)
            {
                _ilogging.Error("Timeout error while finding text on the page. Text: " + itestStep.GetParameter(0));
                throw new AutomationException("Timeout error while finding text on the page. Text: " + itestStep.GetParameter(0));
            }

            _ilogging.Information("Text is present on the page. Text: " + itestStep.GetParameter(0));            
        }

        public void ExecuteJavaScript(ITestStep itestStep)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_itestBaseManager.GetUiTestBase().GetWebDriver();
                js.ExecuteScript(itestStep.GetParameter(0));
            }
            catch(Exception e)
            {
                _ilogging.Error("Error while executing javascript." + itestStep.GetParameter(0));
                throw new AutomationException("Error while executing javascript." + itestStep.GetParameter(0));
            }            
        }

        public void ClickWithJavaScript(ITestStep itestStep)
        {
            for(int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = itestStep.GetUiElement().GetElement(0);
                    IJavaScriptExecutor js = (IJavaScriptExecutor)_itestBaseManager.GetUiTestBase().GetWebDriver();
                    js.ExecuteScript("arguments[0].click()", webElement);
                    break;
                }
                catch (StaleElementReferenceException staleElement) { }
                catch (Exception e)
                {
                    _ilogging.Error("Error while clicking element with javascript.");
                    throw new AutomationException("Error while clicking element with javascript.");
                }
            }                        
        }

        public void MouseHover(ITestStep itestStep)
        {
            for(int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = itestStep.GetUiElement().GetElement(0);
                    Actions actions = new Actions(_itestBaseManager.GetUiTestBase().GetWebDriver());
                    actions.MoveToElement(webElement).Build().Perform();
                    break;
                }
                catch (StaleElementReferenceException staleElement) { }
                catch (ElementClickInterceptedException interceptedException) { }
                catch(Exception e)
                {
                    _ilogging.Error("Error while moving to element on the page."+e.Message);
                    throw new AutomationException("Error while moving to element on the page." + e.Message);
                }                
            }         
        }
        
    }
}
