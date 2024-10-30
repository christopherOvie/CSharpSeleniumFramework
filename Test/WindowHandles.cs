using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace SeleniumLearning2024
{
    public class WindowHandles

    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            //   new WebDriverManager.DriverManager().SetUpDriver();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Url);
        }

        [Test]
        public void WindowHandleTest()
        {
driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.AreEqual(2,driver.WindowHandles.Count);

         String childWindow =    driver.WindowHandles[1];

            driver.SwitchTo().Window(childWindow);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);


        }     
    }
}
