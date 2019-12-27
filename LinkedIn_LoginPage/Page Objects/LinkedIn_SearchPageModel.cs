using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedIn_LoginPage.Base_Files;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace LinkedIn_LoginPage.Page_Objects 
{
    class LinkedIn_SearchPageModel : BaseTest
    {
        private IWebDriver _objDriver;
        
        public LinkedIn_SearchPageModel(IWebDriver driver)
        {
            _objDriver = driver;
        }
        /*ELEMENT LOCATORS*/
        private static readonly string str_search_field_Xpath = "//input[@class='search-global-typeahead__input always-show-placeholder']";          
        private static readonly string str_Search_People = "//button[@class='search-vertical-filter__filter-item-button artdeco-button artdeco-button--muted artdeco-button--2 artdeco-button--tertiary ember-view']";
        private static readonly string str_Search_AllFilters = "//button[@data-control-name='all_filters']";
        private static readonly string str_Add_locations_Xpath = "//input[@placeholder='Añadir un país o región']";
        private static readonly string str_Label_country = "//label[text()='México']";
        
        

        /*PAGE ELEMENT OBJECTS*/

        private IWebElement objSearchField => _objDriver.FindElement(By.XPath(str_search_field_Xpath));
        //private IWebElement objSearchLocation => _objDriver.FindElement(By.XPath(str_Search_location_Xpath));
        private IWebElement objSearchPeople => _objDriver.FindElement(By.XPath(str_Search_People));
        private IWebElement objSearchAllFilters => _objDriver.FindElement(By.XPath(str_Search_AllFilters));
        private IWebElement objSearchAddLocations => _objDriver.FindElement(By.XPath(str_Add_locations_Xpath));
        private IWebElement objLabelCountry => _objDriver.FindElement(By.XPath(str_Label_country));

        /*GET ELEMENT METHODS*/

        public IWebElement GetSearchField()
        {
            return objSearchField;
        }

        public IWebElement GetSearchPeople()
        {
            return objSearchPeople;
        }

        public IWebElement GetSearchAllFilters()
        {
            return objSearchAllFilters;
        }

        public IWebElement GetCountry()
        {
            return objLabelCountry;
        }

        /*ELEMENT ACTIONS*/
        public void FnClickSearchField(string pstrDataSearch)
        {
            objSearchField.Clear();
            objSearchField.SendKeys(pstrDataSearch);
            objSearchField.SendKeys(Keys.Enter);
        }

        
        public void FnClickOnPeople()
        {
             objSearchPeople.Click();
        }

        public void FnClickSearchAllFilters()
        {
            objSearchAllFilters.Click();
        }

        public void FnEnterLocations(string pstrLocations)
        {
            objSearchAddLocations.Clear();
            objSearchAddLocations.SendKeys(pstrLocations);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            objSearchAddLocations.SendKeys(Keys.ArrowDown);
            objSearchAddLocations.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            //objSearchAddLocations.
            //objSearchAddLocations.Click();
        }
    }
}
