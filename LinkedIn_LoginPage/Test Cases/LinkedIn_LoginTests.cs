using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using LinkedIn_LoginPage.Base_Files;
using LinkedIn_LoginPage.Page_Objects;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LinkedIn_LoginPage.Test_Cases
{
    class LinkedIn_LoginTests:BaseTest
    {
        LinkedIn_LoginPageModel objLogin;
        string strScreenshotPath;

        [Test]
        public void LinkedIn_Login()
        {
            try
            {
                exTestStep = exTestCase.CreateNode("Login", "Login to LinkedIn");
                objLogin = new LinkedIn_LoginPageModel(driver);
                objLogin.fnEnterUsername(username);
                exTestCase.Log(AventStack.ExtentReports.Status.Info, $"Username: {username}");
                objLogin.fnEnterPassword(password);
                objLogin.fnClickSignInButton();
                Assert.AreEqual("https://www.linkedin.com/feed/", driver.Url);
                exTestStep.Pass("User has logged succesfully");

                exTestStep = exTestCase.CreateNode("Step2", "Test2");
                exTestStep.Pass("User has 2 succesfully");

                driver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                strScreenshotPath = manager.fnCaptureImage(driver);
                exTestStep.Log(AventStack.ExtentReports.Status.Error, "Step has failed with SS", MediaEntityBuilder.CreateScreenCaptureFromPath(strScreenshotPath).Build());
                Console.WriteLine(ex.Message);
                Console.WriteLine("Test Case Failed.");
                exTestCase.Fail($"Test Case faile with error: {ex.Message}");
            }
            //catch(AssertionException ex)
            //{
            //    Console.WriteLine("Aqui fallo por el assert");
            //}
            //catch(FormatException ex2)
            //{
            //    Console.WriteLine("Aqui fallo por el formato");
            //}
            finally
            {
                //Terminar conexiones, etc...
            }
            //objLogin = new LinkedIn_LoginPageModel(driver);
            //objLogin.fnEnterUsername(username);
            //objLogin.fnEnterPassword(password);
            //objLogin.fnClickSignInButton();
            //Assert.AreEqual("https://www.linkedin.com/feed/", driver.Url);

            //driver.Manage().Window.Maximize();
        }
    }
}
