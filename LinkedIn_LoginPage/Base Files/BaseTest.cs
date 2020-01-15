using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using LinkedIn_LoginPage.Reporting;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace LinkedIn_LoginPage.Base_Files
{
    class BaseTest
    {
        public IWebDriver driver;
        public string url;
        public string username;
        public string password;

        public ReportManager manager;
        public ExtentV3HtmlReporter htmlReporter;
        public ExtentReports extent;
        public ExtentTest exTest;

        public ExtentTest exTestSuit;
        public ExtentTest exTestCase;
        public ExtentTest exTestStep;

        [OneTimeSetUp]//ambientes de nuestra maquina
        public void BeforeAllTest()
        {
            url = Environment.GetEnvironmentVariable("url", EnvironmentVariableTarget.User);
            username = Environment.GetEnvironmentVariable("username", EnvironmentVariableTarget.User);
            password = Environment.GetEnvironmentVariable("password", EnvironmentVariableTarget.User);

            manager = new ReportManager();

            extent = new ExtentReports();
            htmlReporter = new ExtentV3HtmlReporter(manager.fnGetReportPath());

            manager.fnReportSetUp(htmlReporter, extent);

            exTestSuit = extent.CreateTest(TestContext.CurrentContext.Test.ClassName);
        }

        [SetUp]
        public void BoforeTest()
        {
            driver = new ChromeDriver();
            driver.Url = url;
            driver.Manage().Window.Maximize();

            exTestCase = exTestSuit.CreateNode(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {
          //  driver.Close();
        }

        [OneTimeTearDown]
        public void AfterAllTest()
        {
            extent.Flush();//generate the report at the end
            //  driver.Quit();
        }

    }
}
