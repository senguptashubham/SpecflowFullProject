using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
   public interface IExtentFeatureReport
    {
        void CreateFeature(string feature);
        void CreateScenario(string scenario);
        void Error(string msg, string base64);
        void Information(string msg, string base64);
        void Warning(string msg, string base64);
        void Fail(string msg, string base64);
        void Pass(string msg, string base64);
    }
}
