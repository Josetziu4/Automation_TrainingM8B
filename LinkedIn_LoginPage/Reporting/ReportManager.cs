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
using OpenQA.Selenium;

namespace LinkedIn_LoginPage.Reporting
{
    class ReportManager
    {
        public string fnGetReportPath()
        {
            string strExecutionPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;//get the directory/folder where the dll is executing
            string strBaseDirectory = strExecutionPath.Substring(0, strExecutionPath.IndexOf("bin"));//Get base directory (cut the directory before bin path)
            strBaseDirectory = new Uri(strBaseDirectory).LocalPath;//Transform the directory format to match local machine (change the directory wich the system can recognize)

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
        public void fnCaptureImage(IWebDriver pobjDriver, ExtentTest pexTestStep)
        {
            //get screenshot
            ITakesScreenshot objITake = (ITakesScreenshot)pobjDriver;
            Screenshot objScreenshot = objITake.GetScreenshot();
            //Set the folder where will be saved
            string strExecutionPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;//get the directory/folder where the dll is executing
            string strBaseDirectory = strExecutionPath.Substring(0, strExecutionPath.IndexOf("bin"));//Get base directory (cut the directory before bin path)
            strBaseDirectory = new Uri(strBaseDirectory).LocalPath;//Transform the directory format to match local machine (change the directory wich the system can recognize)
            
            //Check if the folder exist, if not: create one and add a subfolder \\"Screenshots"
            string strScreenshotDirectory = strBaseDirectory + "ExtentReports\\Screenshots";
            if (!Directory.Exists(strScreenshotDirectory))
            {
                Directory.CreateDirectory(strScreenshotDirectory);
            }
            string strScreenshotPath = strScreenshotDirectory + $"\\{TestContext.CurrentContext.Test.Name}_{DateTime.Now.ToString("HHmmss")}.png"; //How to identify the screenshot
            //objScreenshot
            objScreenshot.SaveAsFile(strScreenshotPath);

            pexTestStep.Log(Status.Info, "Step ScreenShot", MediaEntityBuilder.CreateScreenCaptureFromPath(strScreenshotPath).Build());

            //return strScreenshotPath;

        }
    }
}
