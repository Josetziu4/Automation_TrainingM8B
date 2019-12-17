using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedIn_LoginPage.Base_Files;
using LinkedIn_LoginPage.Page_Object;
using NUnit.Framework;

namespace LinkedIn_LoginPage.Test_Cases
{
    class LinkedIn_LoginTest : BaseTest
    {
        public static Linkedin_LoginPageModel objLogin;

        [Test]

        public void LinkedIn_login()
        {
            objLogin = new Linkedin_LoginPageModel(driver);
            objLogin.fnEnterUsername(username);
        }
    }
}
