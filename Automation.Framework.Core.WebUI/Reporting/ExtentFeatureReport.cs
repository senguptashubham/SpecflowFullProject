using Automation.Framework.Core.WebUI.Abstractions;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Reporting
{
  public  class ExtentFeatureReport : IExtentFeatureReport
    {
        IExtentReport _iextentReport;
        AventStack.ExtentReports.ExtentTest _feature, _scenario, _step;

        public ExtentFeatureReport(IExtentReport iextentReport)
        {
            _iextentReport = iextentReport;
            _feature = null;
            _scenario = null;
            _step = null;
        }

        public void CreateFeature(string feature)
        {
            _feature = _iextentReport.GetExtentReports().CreateTest(feature);
        }

        public void CreateScenario(string scenario)
        {
            _scenario = _feature.CreateNode(scenario);
        }

        public void AddStepInformation(string msg,Status status,string base64)
        {
            if (base64 == null)
            {
                _scenario.Log(status, msg);
            }
            else
            {
                _scenario.Log(status, msg, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
            }                                    
        }

        public void Error(string msg,string base64)
        {
            AddStepInformation(msg, Status.Error,base64);
        }

        public void Pass(string msg, string base64)
        {
            AddStepInformation(msg, Status.Pass, base64);
        }

        public void Information(string msg, string base64)
        {
            AddStepInformation(msg, Status.Info, base64);
        }

        public void Warning(string msg, string base64)
        {
            AddStepInformation(msg, Status.Warning, base64);
        }

        public void Fail(string msg, string base64)
        {
            AddStepInformation(msg, Status.Fail, base64);
        }
    }
}
