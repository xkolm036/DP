using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace AutomationTest
{
    public class FindAndJoinRoute:Config
    {
        protected void FindRoute(string startDest, string finalDest, string date, string Time)
        {
            //Pocatecni misto
            IWebElement startDestInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("startDestination")));
            startDestInput.SendKeys(startDest);
            var startDestDropdownContent = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='input-Sorce-Content']//a")));
            Assert.True(startDestDropdownContent.Count > 0);
            driver.FindElement(By.XPath("//h1")).Click();

            //datum
            IWebElement dateInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("date")));
            dateInput.Click();
            Assert.True(driver.FindElement(By.XPath("//div[contains(@class,'bootstrap-datetimepicker-widget')]")).Displayed);
            dateInput.SendKeys(Keys.Control + "a");
            dateInput.SendKeys(Keys.Delete);
            dateInput.SendKeys(date);

            //Koncové misto
            IWebElement finalDestImput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("finalDestination")));
            finalDestImput.SendKeys(finalDest);
            var finalDestDropdownContent = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='input-Destination-Content']//a")));
            Assert.True(finalDestDropdownContent.Count > 0);
            driver.FindElement(By.XPath("//h1")).Click();

            //cas
            IWebElement timeInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("time")));
            timeInput.Click();
            Assert.True(driver.FindElement(By.XPath("//div[contains(@class,'bootstrap-datetimepicker-widget')]")).Displayed);
            timeInput.SendKeys(Keys.Control + "a");
            timeInput.SendKeys(Keys.Delete);
            timeInput.SendKeys(Time);
            driver.FindElement(By.XPath("//h1")).Click();

            //click submit
            IWebElement submintButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='submit']")));
            submintButton.Click();

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//h1[text()='Nalezené jízdy']")));

        }

        protected void LoginRoute()
        {
            //join to existing route
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='09.09.9999']/..//a[text()='Pøipojit se']"))).Click();

            //show all registred routes
            driver.FindElement(By.XPath("//nav//a[text()='Pøihlášené jízdy']")).Click();

            var myRoutes = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//tr")));
            Assert.True(myRoutes.Count > 0);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[1]//a[text()='Odhlásit se']"))).Click();



        }





        [Test (Description ="Find route and logion to it")]
        public void FindRoute()
        {
            //login user
            Login("test@test.cz","test1234");

            //Find routes
            FindRoute("Kladno", "Praha", "9999/09/09", "12:24");

            LoginRoute();

     

        }


    }
}