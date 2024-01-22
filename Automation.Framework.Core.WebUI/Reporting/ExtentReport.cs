using Automation.Framework.Core.WebUI.Abstractions;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Reporting
{
   public class ExtentReport  : IExtentReport
    {
        ExtentHtmlReporter _extentHtmlReporter;
        AventStack.ExtentReports.ExtentReports _extentReports;
        IDefaultVariables _idefaultVariables;
        public ExtentReport(IDefaultVariables idefaultVariables)
        {
            _idefaultVariables = idefaultVariables;
        }

        public void InitiliazeExtentReport()
        {
            _extentHtmlReporter = new ExtentHtmlReporter(_idefaultVariables.ExtentReport);
            _extentReports = new AventStack.ExtentReports.ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);
        }

        public AventStack.ExtentReports.ExtentReports GetExtentReports()
        {
            return _extentReports;
        }

        public void FlushExtentReport()
        {
            _extentReports.Flush();
        }
    }
}
