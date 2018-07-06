using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;
using TechTalk.SpecFlow;

namespace KatalonTests1
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        //private string baseURL;
        private bool acceptNextAlert = true;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new FirefoxDriver();
            //baseURL = "http://localhost:5339/";
            verificationErrors = new StringBuilder();
        }

        [AfterScenario]
        public void AfterScenario()
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


        [Given(@"Login 的頁面")]
        public void GivenLogin的頁面()
        {
            driver.Navigate().GoToUrl("http://localhost:5339/Login/Index");
        }
        
        [Given(@"在帳號輸入""(.*)""")]
        public void Given在帳號輸入(string id)
        {
            driver.FindElement(By.Id("id")).Clear();
            driver.FindElement(By.Id("id")).SendKeys("joe");
        }
        
        [Given(@"在密碼輸入""(.*)""")]
        public void Given在密碼輸入(int password)
        {
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("11");
        }
        
        [When(@"按下登入")]
        public void When按下登入()
        {
            driver.FindElement(By.XPath("//input[@value='登入']")).Click();
        }
        
        [Then(@"顯示""(.*)""")]
        public void Then顯示(string message)
        {
            Assert.AreEqual(message, driver.FindElement(By.Id("message")).Text);
        }
    }
}
