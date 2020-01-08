using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LinkedIn_LoginPage.Base_Files;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LinkedIn_LoginPage.Page_Object
{
    internal class LinkedIn_SearchPageModel : Linkedin_LoginPageModel
    {
        //DRIVER REFERENCESS        
        private static IWebDriver _objDriver;
        WebDriverWait wait;

        //ELEMENT LOCATOR         
        private static readonly string STR_SEARCH_TEXTBOX_XPath = "//*[contains(@class,'search-global-typeahead__input')]";
        private static readonly string STR_FILTER_PEOPLE_BTN_XPath = "//li[contains(@aria-label, 'Buscar personas')]";
        private static readonly string STR_FILTER_ALL_BTN_XPath = "//span[text()='Todos los filtros']";        
        private static readonly string STR_LOCATION_MX_OPTION_CHECKBOX_XPath = "//label[@for='sf-geoRegion-mx:0' and text()[normalize-space()='México'] or text()[normalize-space()='Mexico']]";
        private readonly static string STR_LOCATION_TEXT_BOX = "//input[@placeholder='Add a country/region' or @placeholder='Añadir un país o región']";
        private static readonly string STR_APPLY_FILTER_BTN_XPath = "//span[text()[normalize-space()='Aplicar']]";
        private static readonly string STR_SEARCH_JAVA_TEC_CRT_XPath = "//p[contains(@class,'subline-level-1-js mt1') and text()[normalize-space()='Java Developer en iTexico']]";

        private static readonly string STR_SEARCH_NAME_CRT_XPath = "(//span[@class='name actor-name' or @class='actor-name'])[1]";
        private static readonly string STR_SEARCH_ROLE_CRT_XPath = "(//span[@dir='ltr'])[1]";
        private static readonly string STR_SEARCH_URL_CRT_XPath = "(//div[@class='search-result__info pt3 pb4 ph0']/a)[1]";
        
        public LinkedIn_SearchPageModel(IWebDriver driver) : base(driver)
        {
            _objDriver = driver;
        }

        //PAGE ELEMENT OBJECT       
        private static IWebElement objSearch_TextBox => _objDriver.FindElement(By.XPath(STR_SEARCH_TEXTBOX_XPath));
        private static IWebElement objFilter_People_Button => _objDriver.FindElement(By.XPath(STR_FILTER_PEOPLE_BTN_XPath));
        private static IWebElement objFilter_All_Button => _objDriver.FindElement(By.XPath(STR_FILTER_ALL_BTN_XPath));
        private static IWebElement objLocation_Mx_CheckBox => _objDriver.FindElement(By.XPath(STR_LOCATION_MX_OPTION_CHECKBOX_XPath));
        private static IWebElement objLocation_Text_Box => _objDriver.FindElement(By.XPath(STR_LOCATION_TEXT_BOX));
        private static IWebElement objApply_Filter_Button => _objDriver.FindElement(By.XPath(STR_APPLY_FILTER_BTN_XPath));
        private static IWebElement objSearch_Java_Tec_Crt_TxtBox => _objDriver.FindElement(By.XPath(STR_SEARCH_JAVA_TEC_CRT_XPath));

        private static IWebElement objSearch_Name_TxtBox => _objDriver.FindElement(By.XPath(STR_SEARCH_NAME_CRT_XPath));
        private static IWebElement objSearch_Role_TxtBox => _objDriver.FindElement(By.XPath(STR_SEARCH_ROLE_CRT_XPath));
        private static IWebElement objSearch_URL_TxtBox => _objDriver.FindElement(By.XPath(STR_SEARCH_URL_CRT_XPath));
                          
        //GET ELEMENT METHODS
        public IWebElement GetSearchTextBox()
        {
            return objSearch_TextBox;
        }
        public IWebElement GetPageFilterPeopleButton()
        {
            return objFilter_People_Button;
        }
        public IWebElement GetPageFilterAllButton()
        {
            return objFilter_All_Button;
        }
        public IWebElement GetLocationMxCheckBox()
        {
            return objLocation_Mx_CheckBox;
        }
        public IWebElement GetLocationTextBox()
        {
            return objLocation_Text_Box;
        }
        public IWebElement GetPageApplyFilterButton()
        {
            return objApply_Filter_Button;
        }
        public IWebElement GetSearchJavaTecCrtTxtBox()
        {           
            return objSearch_Java_Tec_Crt_TxtBox;            
        }
        public IWebElement GetSearchNameTxt()
        {
            return objSearch_Name_TxtBox;
        }
        public IWebElement GetSearchRoleTxt()
        {
            return objSearch_Role_TxtBox;
        }
        public IWebElement GetSearchURLTxt()
        {            
          return objSearch_URL_TxtBox;        
        }

        //PAGE ELELEMET ACTION
        public void fnSearchTextBox()
        {
            objSearch_TextBox.Click();
        }
        public void fnGetPageFilterPeopleButton()
        {
            objFilter_People_Button.Click();
        }
        public void fnGetPageFilterAllButton()
        {
            objFilter_All_Button.Click();
        }
        public void fnClickLocationMxCheckBox()
        {
            objLocation_Mx_CheckBox.Click();
        }
        public void fnEnterLocationCriteria(string strLocationCrt)
        {
            objLocation_Text_Box.Clear();
            objLocation_Text_Box.SendKeys(strLocationCrt);
            Thread.Sleep(1000);
            objLocation_Text_Box.Click();
            objLocation_Text_Box.SendKeys(Keys.ArrowDown);
            objLocation_Text_Box.SendKeys(Keys.Enter);
        }
        public void fnGetPageApplyFilterButton()
        {
            objApply_Filter_Button.Click();
        }       
        public void fnGetSearch_URL_TxtBox()
        {
            string url;
            url = objSearch_URL_TxtBox.GetAttribute("href").ToString();
        }
        public void fnEnterTecnologyCriteria(string strTecnologyCrt)
        {
            objSearch_TextBox.Clear();           
            objSearch_TextBox.SendKeys(strTecnologyCrt);           
        }
        public void fnEnterTecnologyCriteriaEnter()
        {            
            objSearch_TextBox.SendKeys(Keys.Enter);
        }
        public void fnSearchTecCriteria()
        {
          string[] arrTechnologies = new string[] { "Java Developer", "C Developer", "Phyton Developer", "Pega Developer", "C# Developer" };

            foreach (string technology in arrTechnologies)
            {
                if (technology== "Java Developer")
                {
                    fnEnterTecnologyCriteria(technology);

                    fnEnterTecnologyCriteriaEnter();
                    Console.WriteLine("****************New Member*****************");
                    Console.WriteLine("");
                    Console.WriteLine("Tecnology Information: " + technology);
                    Console.WriteLine("Name: " + objSearch_Name_TxtBox.Text.ToString());                   
                    Console.WriteLine("Role: " + objSearch_Role_TxtBox.Text.ToString());                    
                    Console.WriteLine("Link URL Profile: " + objSearch_URL_TxtBox.GetAttribute("href").ToString());                    
                }
                else if (technology == "C Developer")
                {
                    fnEnterTecnologyCriteria(technology);

                    fnEnterTecnologyCriteriaEnter();
                    Console.WriteLine("****************New Member*****************");
                    Console.WriteLine("");
                    Console.WriteLine("Tecnology Information: " + technology);
                    Console.WriteLine("Name: " + objSearch_Name_TxtBox.Text.ToString());
                    Console.WriteLine("Role: " + objSearch_Role_TxtBox.Text.ToString());                    
                    Console.WriteLine("Link URL Profile: " + objSearch_URL_TxtBox.GetAttribute("href").ToString());                   
                }
                else if (technology == "Phyton Developer")
                {
                    fnEnterTecnologyCriteria(technology);

                    fnEnterTecnologyCriteriaEnter();
                    Console.WriteLine("****************New Member*****************");
                    Console.WriteLine("");
                    Console.WriteLine("Tecnology Information: " + technology);
                    Console.WriteLine("Name: " + objSearch_Name_TxtBox.Text.ToString());
                    Console.WriteLine("Role: " + objSearch_Role_TxtBox.Text.ToString());                    
                    Console.WriteLine("Link URL Profile: " + objSearch_URL_TxtBox.GetAttribute("href").ToString());                    
                }
                else if (technology == "Pega Developer")
                {
                    fnEnterTecnologyCriteria(technology);

                    fnEnterTecnologyCriteriaEnter();
                    Console.WriteLine("****************New Member*****************");
                    Console.WriteLine("");
                    Console.WriteLine("Tecnology Information: " + technology);
                    Console.WriteLine("Name: " + objSearch_Name_TxtBox.Text.ToString());
                    Console.WriteLine("Role: " + objSearch_Role_TxtBox.Text.ToString());                    
                    Console.WriteLine("Link URL Profile: " + objSearch_URL_TxtBox.GetAttribute("href").ToString());                    
                }
                else if (technology == "C# Developer")
                {
                    fnEnterTecnologyCriteria(technology);

                    fnEnterTecnologyCriteriaEnter();
                    Console.WriteLine("****************New Member*****************");
                    Console.WriteLine("");
                    Console.WriteLine("Tecnology Information: " + technology);
                    Console.WriteLine("Name: " + objSearch_Name_TxtBox.Text.ToString());
                    Console.WriteLine("Role: " + objSearch_Role_TxtBox.Text.ToString());                    
                    Console.WriteLine("Link URL Profile: " + objSearch_URL_TxtBox.GetAttribute("href").ToString());                   
                }
                else { }
               
            }

        }


    }
}

