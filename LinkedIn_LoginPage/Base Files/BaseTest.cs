using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace LinkedIn_LoginPage.Base_Files
{
    class BaseTest
    {
        public IWebDriver driver;
        public string url;
        public string username;
        public string password;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            url = Environment.GetEnvironmentVariable("url", EnvironmentVariableTarget.User);
            username = Environment.GetEnvironmentVariable("username", EnvironmentVariableTarget.User);
            password = Environment.GetEnvironmentVariable("password", EnvironmentVariableTarget.User);
        }

        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver();
            driver.Url = url;
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Close();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            driver.Quit();
        }
    }
}
