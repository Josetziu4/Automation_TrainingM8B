using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using LinkedIn_LoginPage.Reporting;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace LinkedIn_LoginPage.Reporting
{
    class ReportManager
    {
        public string fnGetReportPath()
        {
            string strExecutionPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string strBaseDirectory = strExecutionPath.Substring(0, strExecutionPath.IndexOf("bin"));
            strBaseDirectory = new Uri(strBaseDirectory).LocalPath;

            string strReportDirectory = strBaseDirectory + "ExtentReports";
            if (!Directory.Exists(strReportDirectory))
            {
                Directory.CreateDirectory(strReportDirectory);
            }
            string strReportPath = strReportDirectory + "\\ExtentReport_" + DateTime.Now.ToString("MMddyyyy_HHmmss") + ".html";  //ExtentReport_MMDDYYYY_HHMMSS.html

            return strReportPath;
        }
        public void fnReportSetUp(ExtentV3HtmlReporter htmlReporter, ExtentReports extent)
        {
            htmlReporter.Config.DocumentTitle = "Automation Framework Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.ReportName = "LinkedIn";

            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("Proyect Name", "LinkedIn");
            extent.AddSystemInfo("Application:","WebPage");
            extent.AddSystemInfo("Environment:","QA");
            extent.AddSystemInfo("Date: ",DateTime.Now.ToShortDateString());

        }
    }
}
