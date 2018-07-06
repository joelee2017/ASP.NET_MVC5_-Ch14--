using Microsoft.VisualStudio.TestTools.UnitTesting;
using Katalon.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace Katalon.Tests.Selenium
{
    [TestClass]
    public class LoginControllerTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        //private string baseURL;
        private bool acceptNextAlert = true;

        [TestInitialize]  
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            //baseURL = "http://localhost:5339/";
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void 登入測試()
        {
            driver.Navigate().GoToUrl("http://localhost:5339/Login/Index");
            driver.FindElement(By.Id("id")).Clear();
            driver.FindElement(By.Id("id")).SendKeys("joe");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("11");
            driver.FindElement(By.XPath("//input[@value='登入']")).Click();
            Assert.AreEqual("帳號或密碼有誤", driver.FindElement(By.Id("message")).Text);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
