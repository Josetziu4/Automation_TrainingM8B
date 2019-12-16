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
    class LinkedIn_LoginPage : BaseTest
    {
        /*DRIVER REFERENCE*/
        private IWebDriver _objDriver;

        public LinkedIn_LoginPage(IWebDriver driver)
        {
            _objDriver = driver;
        }
        /*ELEMENT LOCATORS*/
        private static readonly string STR_USERNAME_TEXTFIELD = "username";
        private static readonly string STR_PASSWORD_TEXTFIELD = "password";
        
        /*PAGE ELEMENT OBJECTS*/
        /*GET ELEMENT METHODS*/
        /*ELEMENT ACTIONS*/
    }
}
