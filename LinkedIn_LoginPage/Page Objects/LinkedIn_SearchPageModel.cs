using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedIn_LoginPage.Base_Files;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;



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
        private static readonly string str_member_name_Xpath = "//span[@class='actor-name']";
        private static readonly string str_member_roles_Xpath = "//p[@class='subline-level-1 t-14 t-black t-normal search-result__truncate']";
        private static readonly string str_member_urls_Xpath = "//div[@class='search-result__info pt3 pb4 ph0']//a[@href]";
        private static readonly string str_AppFilters_button_Xpath = "//button[@class='search-advanced-facets__button--apply ml4 mr2 artdeco-button artdeco-button--3 artdeco-button--primary ember-view']//following::span[1][text()='Apply']";
        private static readonly string str_English_Checkbox_Xpath = "//*[@class='search-s-facet__values search-s-facet__values--profileLanguage']//descendant::li[1]//descendant::input//following::label[1]";

        /*PAGE ELEMENT OBJECTS*/

        private IWebElement objSearchField => _objDriver.FindElement(By.XPath(str_search_field_Xpath));
        //private IWebElement objSearchLocation => _objDriver.FindElement(By.XPath(str_Search_location_Xpath));
        private IWebElement objSearchPeople => _objDriver.FindElement(By.XPath(str_Search_People));
        private IWebElement objSearchAllFilters => _objDriver.FindElement(By.XPath(str_Search_AllFilters));
        private IWebElement objSearchAddLocations => _objDriver.FindElement(By.XPath(str_Add_locations_Xpath));
        private IWebElement objLabelCountry => _objDriver.FindElement(By.XPath(str_Label_country));
        private IWebElement objAppFiltersButton => _objDriver.FindElement(By.XPath(str_AppFilters_button_Xpath));
        private IWebElement objEnglishCheckBox => _objDriver.FindElement(By.XPath(str_English_Checkbox_Xpath));

        private static IList<IWebElement> objMemberNames;
        private static IList<IWebElement> objMemberRoles;
        private static IList<IWebElement> objMemberUrls;

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

        public IWebElement GetEnglishCheckbox()
        {
            return objEnglishCheckBox;
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
            Thread.Sleep(1000);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            objSearchAddLocations.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);            
            objSearchAddLocations.SendKeys(Keys.Enter);
            
                 }

        public void fnClickAppAllFiltersButton()
        {
            objAppFiltersButton.Click();
        }

        public void fnSelectEnglishCheckBox()
        {
            objEnglishCheckBox.Click();
        }

        public void fnMultipleSearch()
        {
            string[] arrTechnologies = { "Java", "C", "Phyton", "Pega", "C#" };

            for (int i = 0; i < arrTechnologies.Length; i++)
            {
                FnClickSearchField(arrTechnologies[i]);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1); ;

                objMemberNames = _objDriver.FindElements(By.XPath(str_member_name_Xpath));
                objMemberRoles = _objDriver.FindElements(By.XPath(str_member_roles_Xpath));
                objMemberUrls = _objDriver.FindElements(By.XPath(str_member_urls_Xpath));

                for (int j = 0; j < objMemberNames.Count; j++)
{
                    Console.WriteLine("Name: {0}", objMemberNames[j].Text);
                    Console.WriteLine("Role: {0}", objMemberRoles[j].Text);
                    Console.WriteLine("URL: {0}", objMemberUrls[j].GetAttribute("href"));
                    Console.WriteLine();
                }
            }
        }
    }
}
