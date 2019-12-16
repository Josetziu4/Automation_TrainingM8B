using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedIn_LoginPage.Base_Files;
using OpenQA.Selenium;

namespace LinkedIn_LoginPage.Page_Object
{
    class Linkedin_LoginPage : BaseTest
    {
        //DRIVER REFERENCESS
        private static IWebDriver _objDriver;

        public Linkedin_LoginPage(IWebDriver driver)
        {
            _objDriver = driver;
        }
        //ELEMENT LOCATOR 
        private static readonly string STR_USSERNAME_TEXTFIELD = "username";
        private static readonly string STR_PASSWORD_TEXTFIELD = "password";
       // private static readonly string STR_USSERNAME_TEXTFIELD = "username";

        //PAGE ELEMENT OBJECT
        //GET ELEMENT METHODS
        //PAGE ELELEMET ACTION

    }
}
