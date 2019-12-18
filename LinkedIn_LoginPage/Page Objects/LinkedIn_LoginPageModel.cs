using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedIn_LoginPage.Base_Files;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LinkedIn_LoginPage.Page_Objects
{
    class LinkedIn_LoginPageModel : BaseTest
    {
        /*DRIVER REFERENCE*/
        private IWebDriver _objDriver;

        public LinkedIn_LoginPageModel(IWebDriver driver)
        {
            _objDriver = driver;
        }
        /*ELEMENT LOCATORS*/
        private static readonly string str_username_textfield_Id = "username";
        private static readonly string str_password_textfield_Id = "password";
        private static readonly string str_login_button_Xpath = "//button[@class='btn__primary--large from__button--floating']";

        /*PAGE ELEMENT OBJECTS*/
        private  IWebElement objUsernameText => _objDriver.FindElement(By.Id(str_username_textfield_Id));
        private  IWebElement objPasswordText => _objDriver.FindElement(By.Id(str_password_textfield_Id));
        private  IWebElement objLoginButton => _objDriver.FindElement(By.XPath(str_login_button_Xpath));

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

        /*ELEMENT ACTIONS*/
        public void fnEnterUsername(string pstrUsername)
        {
            objUsernameText.Clear();
            objUsernameText.SendKeys(pstrUsername);
        }

        public void fnEnterPassword(string pstrPassword)
        {
            objPasswordText.Clear();
            objPasswordText.SendKeys(pstrPassword);
        }

        public void fnClickLoginButton()
        {
            objLoginButton.Click();
        }
    }
}
