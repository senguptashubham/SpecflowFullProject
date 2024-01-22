using Automation.Framework.Core.WebUI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.Test.Base
{
   public class TestBase : ITestBase
    {
        private FeatureContext _featureContext;
        private Dictionary<string, string> _dataSet;
        private IExtentFeatureReport _iextentFeatureReport;

        public TestBase()
        {
            _dataSet = new Dictionary<string, string>();                        
        }


        public void SetContext(FeatureContext featureContext)
        {
            _featureContext = featureContext;           
        }

        public FeatureContext GetContext()
        {
            return _featureContext;
        }


        public IExtentFeatureReport GetExtentFeatureReport()
        {
            return _iextentFeatureReport;
        }

        public void SetExtent(IExtentFeatureReport iextentFeatureReport)
        {
            _iextentFeatureReport = iextentFeatureReport;
            _iextentFeatureReport.CreateFeature(_featureContext.FeatureInfo.Title);
        }
        public void SetDataSet(string key,string value)
        {
            if (_dataSet.ContainsKey(key))
            {
                _dataSet[key] = value;
            }
            else
            {
                _dataSet.Add(key, value);
            }
        }

        public string GetDataSet(string key)
        {
           return _dataSet[key];
        }
    }
}
