using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
  public  interface ILogging
    {

        void Debug(string msg);

        void Error(string msg);

        void Warning(string msg);


        void Information(string msg);

        void SetLogLevel(string loglevel);
    }
}
