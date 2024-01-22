using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.CustomException
{
   public class AutomationException : Exception
    {

        public AutomationException(string message) : base($"{message}")
        {

        }

        public AutomationException(ErrorItems items) : base($"{items}")
        {

        }

        public AutomationException(ErrorItems items,string message) : base($"{items} : {message}")
        {

        }
    }
}
