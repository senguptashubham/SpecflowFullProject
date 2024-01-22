using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
   public interface IUiActions
    {
        void NavigateToUrl(ITestStep itestStep);

        void Wait(ITestStep itestStep);


        void BrowserActions(ITestStep itestStep);
        void CloseUiBrowser();

        void InputText(ITestStep itestStep);

        void ClearText(ITestStep itestStep);

        void Click(ITestStep itestStep);

        void DoubleClick(ITestStep itestStep);

        void RightClick(ITestStep itestStep);

        void VerifyText(ITestStep itestStep);

        void ExecuteJavaScript(ITestStep itestStep);

        void ClickWithJavaScript(ITestStep itestStep);

        void MouseHover(ITestStep itestStep);
    }
}
