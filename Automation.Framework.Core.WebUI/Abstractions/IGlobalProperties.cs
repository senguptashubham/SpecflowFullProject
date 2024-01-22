using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
    public interface IGlobalProperties
    {
        string DownloadedLocation
        {
            get;
        }
        string GridHubUrl
        {
            get;
        }

        string BrowserType
        {
            get;
        }

        string GetProperty(string key);

        string ORConnection { get; set; }
        string ORSql { get; set; }

    }
}
