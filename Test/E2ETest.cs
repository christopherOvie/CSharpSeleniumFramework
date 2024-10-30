using CSharpSeleniumFramework.PageObjects;
using CSharpSeleniumFramework.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpSeleniumFramework
{
    public class E2ETest : Base

    {


      //  [Test, TestCaseSource("AddTestDataConfig")]
        // [TestCaseSource("AddTestDataConfig")]
        [TestCase("rahulshettyacademy", "learning")]   //for 1 or 2 parameters
       // [TestCase("rahulshetty", "learning2")]

        public void EndToEndFlow(String user, String pwd)
            
        {
            //login page
            //documenrt request -?
            //
            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];

            // driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            LoginPage loginPage = new LoginPage(getDriver());
            //loginPage.getUsername().SendKeys("rahulshettyacademy");

            /* driver.FindElement(By.Id("password")).SendKeys("learning");
             driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
             // .form-group>.text-info>span input
             driver.FindElement(By.Id("signInBtn")).Click();*/
         ProductPage productPage =   loginPage.validLogin(user, pwd);
            productPage.waitForCheckoutPageDisplay();

                       WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //         wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            //  IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            IList<IWebElement> products = productPage.getCards();
            foreach (IWebElement product in products)
            {
                // Assert.IsNotNull(product);
                // TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
               // if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                    if(expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text))
                {

                    product.FindElement(productPage.addToCartButton()).Click();
                }
            }
            //  driver.FindElement(By.PartialLinkText("Checkout")).Click();
         CheckoutPage checkoutPage =  productPage.checkout();

          //  IList<IWebElement> checkoutCard = driver.FindElements(By.CssSelector("h4 a"));
            IList<IWebElement> checkoutCard = checkoutPage.getCards();
            for (int i = 0; i < checkoutCard.Count; i++)
            {
                actualProducts[i] = checkoutCard[i].Text;

            }
           Assert.AreEqual(expectedProducts, actualProducts);
            checkoutPage.checkOut();   
            //driver.FindElement(By.CssSelector("button.btn-success")).Click();



            driver.FindElement(By.Id("country")).SendKeys("ind");


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".input-field input")));
            driver.FindElement(By.LinkText("India")).Click();

            driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();

            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();

            String confirmationText = driver.FindElement(By.CssSelector("div.alert-dismissible")).Text;

            StringAssert.Contains("Success", confirmationText, "mismatch");



        }


     /*   public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
           yield return new TestCaseData(getDataParser().extractData("user"), getDataParser().extractData("pwd"));
         yield return new TestCaseData(getDataParser().extractData("user"), getDataParser().extractData("pwd"));
            yield return new TestCaseData(getDataParser().extractData("user_wrong"), getDataParser().extractData("pwd_wrong")); ;
        }*/
    }
}//getDataParser