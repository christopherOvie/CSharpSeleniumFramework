using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.PageObjects
{
    public class LoginPage
    {
        //  driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
        // driver.FindElement(By.Id("password")).SendKeys("learning");
        // driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
        //  By.Id("username"))
        //driver.FindElement(By.Id("signInBtn")).Click();
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }
        //pageFactory
        [FindsBy(How = How.Id, Using = "username")]
         private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkbox;

        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement signInButton;



        //public IWebElement getUsername()
        //{
        //    return username;
        //}

        //public IWebElement getPassword()
        //{
        //    return password;
        //}
        public ProductPage validLogin(String user, String pwd)      //making it reusable
        {
            username.SendKeys(user);
            password.SendKeys(pwd);
            checkbox.Click();
            signInButton.Click();
            return new  ProductPage(driver);
        }
    }
}

