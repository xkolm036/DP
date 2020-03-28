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
        public string homeURL;

        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }

        [SetUp]
        public void SetupTest()
        {
            homeURL = "https://kolarikdp.azurewebsites.net/";
            driver = new FirefoxDriver("D:\\OneDrive\\Desktop\\CarPoll\\CarPool\\WebDriver");
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));


            driver.Navigate().GoToUrl(homeURL);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submit")));
        }
        //login users and verify wrong inputs
        public void Login()
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

            emailInput.SendKeys("test@test.cz");
            driver.FindElement(By.Id("Input_Password")).SendKeys("test1234");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Přihlásit se']"))).Click();


            Assert.True(driver.FindElement(By.XPath("//a[text()='test@test.cz!']")).Displayed);

        }

    }

}
