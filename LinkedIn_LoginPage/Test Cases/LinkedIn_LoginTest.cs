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
                objLogin = new Linkedin_LoginPageModel(driver);
                objLogin.fnEnterUsername(username);
                objLogin.fnEnterPassword(password);
                objLogin.fnClickSignInButton();                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Test Case Failed");
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
                wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
                wait.Until(condition => driver.Url.Equals("https://www.linkedin.com/feed/"));
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
                //wait.Until(condition => driver.Manage().Timeouts(driver, new TimeSpan() )); //.Url.Distinct("https://www.linkedin.com/search/results/people/?facetGeoRegion=%5B%22it%3A0%22%2C%22mx%3A0%22%5D&origin=FACETED_SEARCH"));
                //wait.Until(condition => driver.PageSource.StartsWith("https://www.linkedin.com/search/results/people/?facetGeoRegion=%5B%22it%3A0%22%2C%22mx%3A0%22%5D&origin=FACETED_SEARCH"));
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
