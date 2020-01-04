using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedIn_LoginPage.Base_Files;
using LinkedIn_LoginPage.Page_Objects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;


namespace LinkedIn_LoginPage.Test_Cases
{
    class LinkedIn_LoginTest : BaseTest
    {
        public static LinkedIn_LoginPageModel objLogin;
        public static LinkedIn_SearchPageModel objSearch;
        WebDriverWait _objDriverWait;

        [Test]
        public void LinkedIn_Login()
        {

            try
            {
                objLogin = new LinkedIn_LoginPageModel(driver);
                objLogin.fnEnterUsername(username);
                objLogin.fnEnterPassword(password);
                objLogin.FnClickLoginButton();
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
                Console.WriteLine(ex2.Message);
                Console.WriteLine("Error due missing transaction date in valid Range");
            }

            finally
            {
                // End conections

                //driver.Close();
            }
                         
                                   
        }

        [Test]
        public void LinkedIn_Search()
        {

            try
            {
                objLogin = new LinkedIn_LoginPageModel(driver);
                objSearch = new LinkedIn_SearchPageModel(driver);
                _objDriverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                driver.Manage().Window.Maximize();
                objLogin.fnEnterUsername(username);
                objLogin.fnEnterPassword(password);
                objLogin.FnClickLoginButton();
                Assert.AreEqual("https://www.linkedin.com/feed/", driver.Url);
                objSearch.FnClickSearchField("Agile thought");
                _objDriverWait.Until(ExpectedConditions.UrlContains("results"));
                objSearch.FnClickOnPeople();
                _objDriverWait.Until(ExpectedConditions.UrlContains("people"));
                objSearch.FnClickSearchAllFilters();
                _objDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[@class='t-20 t-20--open t-black--light t-normal']")));
                objSearch.FnEnterLocations("México");
                //_objDriverWait.Until(ExpectedConditions.ElementIsVisible(objSearch.GetCountry));
                objSearch.FnEnterLocations("Mexico");
                objSearch.FnEnterLocations("Italy");
                objSearch.fnSelectEnglishCheckBox();
                _objDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='search-advanced-facets__button--apply ml4 mr2 artdeco-button artdeco-button--3 artdeco-button--primary ember-view']")));
                objSearch.fnClickAppAllFiltersButton();
                objSearch.fnMultipleSearch();

            }

            catch (FormatException X)
            {
                Assert.Fail();
                Console.WriteLine(X.Message);

                Console.WriteLine("Test case failed");
            }

            catch (AssertionException ex2)
            {
                Console.WriteLine("Error due missing information in Results");
            }

            finally
            {
                // End conections
               //driver.Close();
            }

                                          
        }


    }
}
