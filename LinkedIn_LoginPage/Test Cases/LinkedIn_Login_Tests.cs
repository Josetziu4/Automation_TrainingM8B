using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedIn_LoginPage.Base_Files;
using LinkedIn_LoginPage.Page_Objects;

namespace LinkedIn_LoginPage.Test_Cases
{
    class LinkedIn_Login_Tests : BaseTest
    {
        LinkedIn_LoginPage_POM objLoginPage;

        [Test]
        public void LinkedIn_Login() {
            objLoginPage = new LinkedIn_LoginPage_POM(driver);
            objLoginPage.fnUsernameText(username);
            objLoginPage.fnPasswordText(password);
            objLoginPage.fnLoginButton();
        }
            

        

    }
}
