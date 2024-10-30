using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace SeleniumLearning2024
{
    public class SortingWebTables
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
        
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void SortingFruitsInTables()

        {
            ArrayList a = new ArrayList();
           IWebElement select = driver.FindElement(By.Id("page-menu"));
            SelectElement dropdown = new SelectElement(select);

            dropdown.SelectByValue("20"); ;

            //pseudo code
            //1..get all vegetables into array list A
          IList<IWebElement> veggies =  driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
            }



            //step 2  sort this arraylist  -a
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }
            TestContext.Progress.WriteLine("after sorting");
            a.Sort();
            foreach(String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }
            //step 3  - go and  click column
            driver.FindElement(By.CssSelector("th[aria-label*='Veg/fruit']")).Click();

            //step 4  get all veggie name into array list B


            ArrayList b = new ArrayList();


            IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggie in sortedVeggies)
            {
                b.Add(veggie.Text);
            }

            //Arraylist are equal
            Assert.AreEqual(a, b,"do not match");
        }

        
    }
}
