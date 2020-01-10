using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedIn_LoginPage.Base_Files;
using LinkedIn_LoginPage.Page_Object;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LinkedIn_LoginPage.Test_Cases
{
    class LinkedIn_LoginTest : BaseTest
    {
        public static Linkedin_LoginPageModel objLogin;
        public static LinkedIn_SearchPageModel objSearchPage;

        WebDriverWait wait;

        [Test]
        public void LinkedIn_login()
        {
            try
            {
                exTestStep = exTestCase.CreateNode("Login","Login to LinkedIn");

                objLogin = new Linkedin_LoginPageModel(driver);
                objLogin.fnEnterUsername(username);
                exTestCase.Log(AventStack.ExtentReports.Status.Info,$"Useraname: {username}");
                objLogin.fnEnterPassword(password);
                objLogin.fnClickSignInButton();
                Assert.AreEqual("https://www.linkedin.com/feed/", driver.Url);
                exTestCase.Pass("User has Loged Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Test Case Failed");
                exTestCase.Fail($"Test Case Failed Erro: {e.Message}");
            }
            finally { }           
        }

        [Test]
        public void Linkedin_SearchPage()
        {
            try
            {
                LinkedIn_login();

                objSearchPage = new LinkedIn_SearchPageModel(driver);
                objSearchPage.fnSearchTextBox();
                objSearchPage.fnBeforeSearchTextBox();
                wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));                
                wait.Until(condition => driver.Url.Equals("https://www.linkedin.com/feed/"));
                //wait.Until(condition => driver.FindElement(By.XPath("//div[contains(@class, 'basic-typeahead')]")));
                objSearchPage.fnGetPageFilterPeopleButton();

                wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
                wait.Until(condition => driver.Url.Equals("https://www.linkedin.com/search/results/people/?origin=DISCOVER_FROM_SEARCH_HOME"));
                objSearchPage.fnGetPageFilterAllButton();
                objSearchPage.fnClickLocationMxCheckBox();
                objSearchPage.fnEnterLocationCriteria("Italia");
                objSearchPage.fnGetPageApplyFilterButton();

                wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
                wait.Until(condition => driver.Url.Equals("https://www.linkedin.com/search/results/people/?facetGeoRegion=%5B%22it%3A0%22%2C%22mx%3A0%22%5D&origin=FACETED_SEARCH"));
                objSearchPage.fnEnterTecnologyCriteria("");

                wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
                wait.Until(condition => driver.FindElement(By.XPath("(//span[@class='nav-item__icon'])[1]")));
                objSearchPage.fnSearchTecCriteria();                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Test Case Failed");
            }
            finally { }
            
        }

    }
}
