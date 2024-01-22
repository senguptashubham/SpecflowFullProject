using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
   public interface IDefaultVariables
    {

        string Log
        {
            get;
        }

        string Resources
        {
            get;
        }

        string GridHubUrl
        {
            get;
        }

        string filePath
        {
            get;
        }

        string ExtentReport
        {
            get;
        }

    }
}
