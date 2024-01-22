using Automation.Framework.Core.WebUI.Test.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
   public interface ITestBaseManager
    {
        void SetTestBase(TestBase testBase);

        TestBase GetTestBase();


        UiTestBase GetUiTestBase();

    }
}
