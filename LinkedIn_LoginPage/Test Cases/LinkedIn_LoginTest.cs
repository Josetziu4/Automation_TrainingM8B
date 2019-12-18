using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedIn_LoginPage.Base_Files;
using LinkedIn_LoginPage.Page_Objects;
using NUnit.Framework;

namespace LinkedIn_LoginPage.Test_Cases
{
    class LinkedIn_LoginTest:BaseTest
    {
        public static LinkedIn_LoginPageModel objLogin;

        [Test]
        public void LinkedIn_Login()
        {
            try
            {
                objLogin = new LinkedIn_LoginPageModel(driver);
                driver.Manage().Window.Maximize();
                objLogin.fnEnterUsername(username);
                objLogin.fnEnterPassword(password);
                objLogin.fnClickLoginButton();
                Assert.AreEqual("https://www.linkedin.com/feed/", driver.Url);
            }
            catch (Exception ex)
            {
                Assert.Fail();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Test Case Failed.");
            }
            //catch(AssertionException x)
            //{
            //    Console.WriteLine("Exception due to assert.");
            //}
            finally
            {
                //Terminar conexciones, etc...
            }
        }
    }
}
