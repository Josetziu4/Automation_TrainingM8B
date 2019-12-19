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
    class LinkedIn_Login_Test : BaseTest
    { 
        
        public static LinkedIn_LoginPage_POM objLoginPage;

        [Test]
        public void LinkedIn_Login()
        {
            try
            {
                objLoginPage = new LinkedIn_LoginPage_POM(driver);
                objLoginPage.fnUsernameText(username);
                objLoginPage.fnPasswordText(password);
                objLoginPage.fnLoginButton();
                Assert.AreEqual("http://www.linkedin.com/feed/", driver.Url);

                driver.Manage().Window.Maximize();
            }
            catch(Exception ex)
            {
                Assert.Fail();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Test Case Failed");
            }
            finally
            {
                //Terminar conexiones

            }

            /*objLoginPage = new LinkedIn_LoginPage_POM(driver);
            objLoginPage.fnUsernameText(username);
            objLoginPage.fnPasswordText(password);
            objLoginPage.fnLoginButton();
            Assert.AreEqual("http://www.linkedin.com/feed/", driver.Url);

            driver.Manage().Window.Maximize();*/
            
        }


    }
}
