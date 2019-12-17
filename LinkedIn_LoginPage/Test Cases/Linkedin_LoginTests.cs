using LinkedIn_LoginPage.Base_Files;
using LinkedIn_LoginPage.Page_Objects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_LoginPage.Test_Cases
{
    class Linkedin_LoginTests : BaseTest 
    {
        public static LinkedIn_LoginPageModel objLogin;


        [Test]

        public void LinkedIn_Login()
        {
            objLogin = new LinkedIn_LoginPageModel(driver);
            objLogin.fnEnterUsername(username);
        }
    }
}
