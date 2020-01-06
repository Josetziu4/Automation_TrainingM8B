using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedIn_LoginPage.Base_Files;
using OpenQA.Selenium;

namespace LinkedIn_LoginPage.Page_Object
{
    class Linkedin_LoginPageModel : BaseTest
    {
        //DRIVER REFERENCESS
        private static IWebDriver _objDriver;        

        public Linkedin_LoginPageModel(IWebDriver driver)
        {
            _objDriver = driver;            
        }

        //ELEMENT LOCATOR 
        private static readonly string STR_USSERNAME_TEXTFIELD_ID = "username";
        private static readonly string STR_PASSWORD_TEXTFIELD_ID = "password";
        private static readonly string STR_LOGIN_BUTTON_XPath = "//*[text()='Iniciar sesión' or text()='Sign in']";
        

        //PAGE ELEMENT OBJECT
        private static IWebElement objUsernameText => _objDriver.FindElement(By.Id(STR_USSERNAME_TEXTFIELD_ID));
        private static IWebElement objPasswordText => _objDriver.FindElement(By.Id(STR_PASSWORD_TEXTFIELD_ID));
        private static IWebElement objLogin_Button => _objDriver.FindElement(By.XPath(STR_LOGIN_BUTTON_XPath));
       
        //GET ELEMENT METHODS
        public IWebElement GetUsernameField()
        {
            return objUsernameText;
        }
        public IWebElement GetUserpasswordField()
        {
            return objPasswordText;
        }
        public IWebElement GetLoginButton()
        {
            return objLogin_Button;
        }
        
        //PAGE ELELEMET ACTION
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
        public void fnClickSignInButton()
        {
            objLogin_Button.Click();           
        }
       

    }
}
