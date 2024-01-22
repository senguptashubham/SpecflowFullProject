using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Selenium
{
   public class UtilityActions : IUtilityActions
    {
        ITestBaseManager _itestBaseManager;
        ILogging _ilogging;
        public UtilityActions(ITestBaseManager itestBaseManager,ILogging ilogging)
        {
            _itestBaseManager = itestBaseManager;
            _ilogging = ilogging;
        }

        public void UniqueString(ITestStep itestStep)
        {
            try
            {
                string uniqueString = itestStep.GetParameter(0) + DateTime.Now.ToString("yyyyMMdd hhmmss");
                _itestBaseManager.GetTestBase().SetDataSet(itestStep.GetParameter(1), uniqueString);
            }
            catch(Exception e)
            {
                _ilogging.Error("Error while setting the unique value with key." +e.Message);
                throw new AutomationException("Error while setting the unique value with key." + e.Message);
            }            
        }

    }
}
