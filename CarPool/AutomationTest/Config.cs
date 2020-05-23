using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationTest
{


    [TestFixture]
    public class Config
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public void SetupTest()
        {
      
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://kolarikdp.azurewebsites.net/");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submit")));
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }

        //login users and verify wrong inputs
        public void Login(string email, string password)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Login']"))).Click();
            IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Přihlásit se']")));

            IWebElement emailInput = driver.FindElement(By.Id("Input_Email"));
            emailInput.SendKeys("ww");
            driver.FindElement(By.XPath("//h1")).Click();

            loginButton.Click();

            Assert.True(driver.FindElement(By.Id("Input_Email-error")).Displayed);
            Assert.True(driver.FindElement(By.Id("Input_Password-error")).Displayed);


            emailInput.SendKeys(Keys.Control + "a");
            emailInput.SendKeys(Keys.Delete);

            emailInput.SendKeys(email);
            driver.FindElement(By.Id("Input_Password")).SendKeys(password);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Přihlásit se']"))).Click();


            Assert.True(driver.FindElement(By.XPath("//a[text()='test@test.cz!']")).Displayed);

        }

    }

}
