using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.Abstractions;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Reporting
{
  public  class Logging : ILogging
    {
        LoggingLevelSwitch _loggingLevelSwitch;
        IDefaultVariables _idefaultVariables;
        public Logging(IDefaultVariables idefaultVariables)
        {
            _idefaultVariables = idefaultVariables;
            _loggingLevelSwitch = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration().MinimumLevel.ControlledBy(_loggingLevelSwitch)
                .WriteTo.File(_idefaultVariables.Log
                            , outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .Enrich.WithThreadId().CreateLogger();
        }

        public void SetLogLevel(string loglevel)
        {
            switch (loglevel.ToLower())
            {
                case "debug":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Debug;
                    break;
                case "error":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Error;
                    break;
                case "information":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Information;
                    break;
                case "fatal":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Fatal;
                    break;
                default:
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Debug;
                    break;

            }
        }

        public void Debug(string msg)
        {
            Log.Logger.Debug(msg);
        }

        public void Error(string msg)
        {
            Log.Logger.Error(msg);
        }

        public void Warning(string msg)
        {
            Log.Logger.Warning(msg);
        }

        public void Information(string msg)
        {
            Log.Logger.Information(msg);
        }

    }
}
