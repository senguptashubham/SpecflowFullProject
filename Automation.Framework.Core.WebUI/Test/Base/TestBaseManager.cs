using Automation.Framework.Core.WebUI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Test.Base
{
   public class TestBaseManager : ITestBaseManager
    {
        private static ThreadLocal<TestBase> _testBase = new ThreadLocal<TestBase>();


        public void SetTestBase(TestBase testBase)
        {
            _testBase.Value = testBase;
        }

        public TestBase GetTestBase()
        {
            return _testBase.Value;
        }

        public UiTestBase GetUiTestBase()
        {
            return (UiTestBase)_testBase.Value;
        }

    }
}
