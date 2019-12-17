using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedIn_LoginPage.Base_Files;
using OpenQA.Selenium;

namespace LinkedIn_LoginPage.Page_Objects
{
    class LinkedIn_LoginPage:BaseTest
    {
        /*DRIVER REFERENCE*/
        private static IWebDriver _objDriver;

        public LinkedIn_LoginPage(IWebDriver objDriver)
        {
            _objDriver = objDriver;
        }

        /*ELEMENT LOCATORS*/
        private static readonly string STR_USERNAME_TEXTFIELD_Id = "username";
        private static readonly string STR_PASSWORD_TEXTFIELD_Id = "password";
        private static readonly string STR_LOGIN_BUTTON_XPath = "//*[text()='Iniciar sesión' or text()='Sign in']";

        /*PAGE ELEMENT OBJECTS*/
        private static IWebElement objUsernameText => _objDriver.FindElement(By.Id(STR_USERNAME_TEXTFIELD_Id));
        private static IWebElement objPasswordText => _objDriver.FindElement(By.Id(STR_PASSWORD_TEXTFIELD_Id));
        private static IWebElement objLoginButton => _objDriver.FindElement(By.XPath(STR_LOGIN_BUTTON_XPath));

        /*GET ELEMENT METHODS*/
        /*PAGE ELEMENT ACTIONS*/
    }
}
