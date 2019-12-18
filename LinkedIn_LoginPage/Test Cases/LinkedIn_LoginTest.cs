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
    class LinkedIn_LoginTest : BaseTest
    {
        public static LinkedIn_LoginPageModel objLogin;

        [Test]
        public void LinkedIn_Login()
        {

            try
            {
                objLogin = new LinkedIn_LoginPageModel(driver);
                objLogin.fnEnterUsername(username);
                objLogin.fnEnterPassword(password);
                objLogin.fnClickLoginButton();
                Assert.AreEqual("https://www.linkedin.com/feed/", driver.Url);

                driver.Manage().Window.Maximize();
            }

            catch (FormatException X)
            {
                Assert.Fail();
                Console.WriteLine(X.Message);
                
                Console.WriteLine("Test case failed");
            }

            catch (AssertionException ex2)
            {
                Console.WriteLine("Error due missing transaction date in valid Range");
            }

            finally
            {
                // End conections

                //driver.Close();
            }


           


            
        }

        
    }
}
