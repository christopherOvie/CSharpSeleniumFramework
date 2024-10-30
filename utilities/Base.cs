using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.utilities
{
    public class Base
    {
       public  IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
         String browserName =   ConfigurationManager.AppSettings["browser"];

            initBrowser(browserName);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public IWebDriver getDriver()
        {
            return driver;
        }
        public void initBrowser(String browserName)
        {

            //factory design pattern
            switch (browserName)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    driver = new EdgeDriver();
                    break;



            }
        }
        public static jsonreader getDataParser()
        {
            return new jsonreader();
        }

       // [TearDown]
       /* public void CloseBrowser()
        {
            driver.Quit();
        }*/

    }


}
