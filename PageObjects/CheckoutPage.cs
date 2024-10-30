using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.PageObjects
{
    public class CheckoutPage
    {
        //
        //  IList<IWebElement> checkoutCard = driver.FindElements(By.CssSelector("h4 a"));
        private IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;
        //driver.FindElement(By.CssSelector("button.btn-success")).Click();

        [FindsBy(How = How.CssSelector, Using = "button.btn-success")]
        private IWebElement checkoutButton;
        public IList<IWebElement> getCards()
        {
            return checkoutCards;
        }

        public void checkOut()
        {
            checkoutButton.Click(); 
        }
    }
}