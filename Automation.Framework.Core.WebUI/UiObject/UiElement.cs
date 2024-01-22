using Automation.Framework.Core.WebUI.Abstractions;
using MySql.Data.MySqlClient;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Framework.Core.WebUI.CustomException;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Automation.Framework.Core.WebUI.UiObject
{
   public class UiElement : IUiElement
    {
        IList<string> _locators;
        ITestBaseManager _itestBaseManager;
        IGlobalProperties _iglobalProperties;
        ILogging _ilogging;
        public UiElement(IGlobalProperties iglobalProperties, ITestBaseManager testBaseManager, ILogging ilogging)
        {
            _iglobalProperties = iglobalProperties;
            _itestBaseManager = testBaseManager;
            _ilogging = ilogging;
        }

        public void BuildFromElements(IList<string> locators)
        {           

            this._locators = locators;

        }

        public IWebElement GetElement(int index)
        {

            By by;             
            string[] arr = _locators[index].Split('|');
            switch (arr[0].ToLower())
            {
                case "xpath":
                    by = By.XPath(arr[1]);
                    break;
                case "id":
                    by = By.Id(arr[1]);
                    break;
                default:
                    _ilogging.Error("Provded locator does not exists. " + arr[0]);
                    throw new AutomationException("Provded locator does not exists. " + arr[0]);
                    break;
            }
            WebDriverWait wait = new WebDriverWait(_itestBaseManager.GetUiTestBase().GetWebDriver(), TimeSpan.FromSeconds(30));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
           return wait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(by));
           
        }

        public void GetLocator()
        {
            MySqlConnection connection = new MySqlConnection(_iglobalProperties.ORConnection);
            connection.Open();
            
            MySqlCommand mySqlCommand = new MySqlCommand(_iglobalProperties.ORSql, connection);

            for(int i=0;i<_locators.Count;i++)
            {
                string[] arr = _locators[i].Split('.');

                mySqlCommand.Parameters.AddRange(new[]
                {
                    new MySqlParameter("pagename",arr[0]),
                    new MySqlParameter("objectname",arr[1])
                });

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    _locators[i] = mySqlDataReader["propertyname"].ToString() + "|" + mySqlDataReader["propertyvalue"].ToString();
                }
            }

        }
    }
}
