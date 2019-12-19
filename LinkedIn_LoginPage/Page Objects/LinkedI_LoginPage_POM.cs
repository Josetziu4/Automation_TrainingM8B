using LinkedIn_LoginPage.Base_Files;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_LoginPage.Page_Objects
{
    class LinkedIn_LoginPage_POM : BaseTest
    {
        //DRIVER REFERENCE
        private static IWebDriver _objDriver;
        public LinkedIn_LoginPage_POM (IWebDriver driver)
        {
            _objDriver = driver;
        }

        //ELEMENT LOCATORS
        private static readonly string STR_USERNAME_TEXTFIELD = "username";
        private static readonly string STR_PASSWORD_TEXTFIELD = "password";
        private static readonly string STR_LOGIN_BUTTON = "//*[text()='Iniciar sesión' or text()='Sign In']";

        // <-- Relative
        // button <-- element type
        // [] <-- start filter
        // @ class <-- tag


        //PAGE ELEMENT OBJECTS
        private static IWebElement objUsername => _objDriver.FindElement(By.Id(STR_USERNAME_TEXTFIELD));
        private static IWebElement objPassword => _objDriver.FindElement(By.Id(STR_PASSWORD_TEXTFIELD));
        private static IWebElement objLoginButton => _objDriver.FindElement(By.XPath(STR_LOGIN_BUTTON));



        //GET ELEMENT METHODS
        public IWebElement GetUsernameField()
        {
            return objUsername;
        }

        public IWebElement GetPasswordField()
        {
            return objPassword;
        }

        public IWebElement GetLoginButton()
        {
            return objLoginButton;
        }

        //PAGE ELEMENT ACTIONS
        public void fnUsernameText(string strUsername)
        {
            objUsername.Clear();
            objUsername.SendKeys(strUsername);
        }

        public void fnPasswordText(string strPassword)
        {
            objPassword.Clear();
            objPassword.SendKeys(strPassword);
        }

        public void fnLoginButton()
        {
            objLoginButton.Click();
        }

    }
}
