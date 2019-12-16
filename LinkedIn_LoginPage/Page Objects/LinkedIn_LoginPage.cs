using LinkedIn_LoginPage.Base_Files;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_LoginPage.Page_Objects
{
    class LinkedIn_LoginPage : BaseTest
    {
        /*DRIVER REFERENCE*/
        private static IWebDriver _objDriver;

        public LinkedIn_LoginPage(IWebDriver objDriver)
        {
            _objDriver = objDriver;
        }

        /*ELEMENT LOCATORS*/
        private static readonly string STR_USERNAME_TEXTFIELD = "username";
        private static readonly string STR_PASSWORD_TEXTFIELD = "password";

        /*PAGE ELEMENT OBJECTS*/
        /*GET ELEMENT METHODS*/
        /*PAGE ELEMENT ACTIONS*/

    }
}
