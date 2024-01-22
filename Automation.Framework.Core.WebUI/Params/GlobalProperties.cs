using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.CustomException;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Params
{
  public  class GlobalProperties : IGlobalProperties
    {
        IDefaultVariables _idefaultVariables;
        ILogging _ilogging;
        IExtentReport _iextentReport;
        IConfigurationSection _iconfigurationSection;        
        
        public  string BrowserType { get; set; }
        string BrowserVersion { get; set; }
       public string GridHubUrl { get; set; }
        string Region { get; set; }
        bool StepScreenShot { get; set; }
        string ExtentReportPortalUrl { get; set; }
        bool ExtentReportToPortal { get; set; }
        string LogLevel { get; set; }
        string DataSetLocation { get; set; }
        
       public string DownloadedLocation { get; set; }
        public string ORConnection { get; set; }
        public string ORSql { get; set; }
        public GlobalProperties(IDefaultVariables idefaultVariables,ILogging ilogging,IExtentReport iextentReport)
        {
            _idefaultVariables = idefaultVariables;
            _ilogging = ilogging;
            _iconfigurationSection = null;
            _iextentReport = iextentReport;
             Configuration();
        }

        public string GetProperty(string key)
        {
            if (string.IsNullOrEmpty(_iconfigurationSection[key]))
            {
                _ilogging.Error("Key does not exists in configuration section. " + key);
                throw new AutomationException("Key does not exists in configuration section. " + key);
            }
            return _iconfigurationSection[key];
        }
        public void Configuration()
        {
            IConfiguration builder = null;
            try
            {
                 builder = new ConfigurationBuilder().SetBasePath(_idefaultVariables.Resources)
                .AddJsonFile("frameworkSettings.json").Build();
            }
            catch(FileNotFoundException fn)
            {
                _ilogging.Error("FrameworkSettings.json does not exists." + fn.Message);
                System.Environment.Exit(0);
            }

            BrowserType = string.IsNullOrEmpty(builder["BrowserType"]) ? "chrome" : builder["BrowserType"];
            BrowserVersion = builder["BrowserVersion"];
            GridHubUrl = string.IsNullOrEmpty(builder["GridHubUrl"]) ? _idefaultVariables.GridHubUrl : builder["GridHubUrl"];
            Region = builder["Region"];
            StepScreenShot = builder["StepScreenShot"].ToLower().Equals("on") ? true : false;
            ExtentReportPortalUrl = builder["ExtentReportPortalUrl"];
            ExtentReportToPortal = builder["ExtentReportToPortal"].ToLower().Equals("on") ? true : false;
            LogLevel = builder["LogLevel"];
            DataSetLocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _idefaultVariables.filePath : builder["DataSetLocation"];
            DownloadedLocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _idefaultVariables.filePath : builder["DownloadedLocation"]; 

            if(string.IsNullOrEmpty(Region))
            {
                _ilogging.Error("User has not provided application environment information.");
                System.Environment.Exit(0);
            }

            _ilogging.SetLogLevel(LogLevel);

            IConfiguration applicationBuilder = null;            
            try
            {
                applicationBuilder = new ConfigurationBuilder().SetBasePath(_idefaultVariables.Resources)
               .AddJsonFile("applicationRegion.json").Build();
               _iconfigurationSection= applicationBuilder.GetSection(Region);
            }
            catch (FileNotFoundException fn)
            {
                _ilogging.Error("ApplicationRegion.json does not exists." + fn.Message);
                System.Environment.Exit(0);
            }

            IConfiguration objectRepoBuilder = null;
            try
            {
                objectRepoBuilder = new ConfigurationBuilder().SetBasePath(_idefaultVariables.Resources)
               .AddJsonFile("ObjectRepo.json").Build();
                this.ORConnection = objectRepoBuilder["ORConnectionString"];
                this.ORSql = objectRepoBuilder["ORSQL"];
            }
            catch (FileNotFoundException fn)
            {
                _ilogging.Error("ObjectRepo.json does not exists." + fn.Message);
                System.Environment.Exit(0);
            }

            _iextentReport.InitiliazeExtentReport();
            

            _ilogging.Debug("********************************************************************************");
            _ilogging.Information("********************************************************************************");
            _ilogging.Information("Configuration |RUN PARAMETERS");
            _ilogging.Information("********************************************************************************");
            _ilogging.Information("Configuration|BROWSER TYPE: " + BrowserType);
            _ilogging.Information("Configuration|BROWSER VERSION: " + BrowserVersion);
            _ilogging.Information("Configuration|GRID HUB URL: " + GridHubUrl);
            _ilogging.Information("Configuration|REGION: " + builder["region"]);
            _ilogging.Information("Configuration|STEP SCREENSHOT: " + builder["StepScreenShot"]);
            _ilogging.Information("Configuration|EXTENT REPORT PORTAL URL: " + ExtentReportPortalUrl);
            _ilogging.Information("Configuration|EXTENT REPORT LOCALLY: " + builder["ExtentReportToPortal"]);
            _ilogging.Information("Configuration|LOG LEVEL: " + LogLevel);
            _ilogging.Information("Configuration|DATA SET LOCATION: " + DataSetLocation);
            _ilogging.Information("Configuration|DOWNLOADED LOCATION: " + DownloadedLocation);
            _ilogging.Information("********************************************************************************");
            _ilogging.Information("********************************************************************************");
        }
    }
}
