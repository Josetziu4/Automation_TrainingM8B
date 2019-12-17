using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LinkedIn_LoginPage.Base_Files;
using NUnit.Framework;

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
        private static readonly string str_username_textfield = "username";
        private static readonly string str_password_textfield = "password";

        /*PAGE ELEMENT OBJECTS*/
        /*GET ELEMENT METHODS*/
        /*ELEMENT ACTIONS*/
    }
}
