using LinkedIn_LoginPage.Base_Files;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_LoginPage.Page_Objects
{
    class Linkedin_LoginPageModel : BaseTest
    {
        /*DRIVER REFERENCE*/
        private static IWebDriver _objDriver;

        public Linkedin_LoginPageModel(IWebDriver driver)
        {
            _objDriver = driver;
        }

        /*Element Locators*/
        private static readonly string STR_USERNAME_TEXTFIELD_Id = "username";
        private static readonly string STR_PASSWORD_TEXTFIELD_Id = "password";
        private static readonly string STR_LOGIN_BUTTON_XPath = "---";

        /*PAGE ELEMENT OBJECTS*/

        private static IWebElement objUsernameText => _objDriver.FindElement(By.Id(STR_USERNAME_TEXTFIELD_Id));
        private static IWebElement objPasswordText => _objDriver.FindElement(By.Id(STR_PASSWORD_TEXTFIELD_Id));
        private static IWebElement objLoginButton => _objDriver.FindElement(By.XPath(STR_LOGIN_BUTTON_XPath));

        /*GET ELEMENT METHODS*/

        public IWebElement GetUsernameField()
        {
            return objUsernameText;
        }

        public IWebElement GetPasswordField()
        {
            return objPasswordText;
        }

        public IWebElement GetLoginButton()
        {
            return objLoginButton;
        }

        /*PAGE ELEMENT ACTIONS*/

        public void fnEnterUsername(string pstrUsername)
        {
            objUsernameText.Clear();
            objUsernameText.SendKeys(pstrUsername);


        }
    }
}
