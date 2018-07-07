using System;
using TechTalk.SpecFlow;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using 以重構計算運費的為例.Models;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Chrome;

namespace 以重構計算運費的為例.Tests
{
    [Binding]
    [Scope(Feature ="計算運費")]
    public class 計算運費Steps
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        //private string baseURL;
        //private bool acceptNextAlert = true;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            //baseURL = "http://localhost:4495/Product/Index";
            verificationErrors = new StringBuilder();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                driver.Quit();// quit does not close the window
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Given(@"計算運費頁面")]
        public void Given計算運費頁面()
        {
            driver.Navigate().GoToUrl("http://localhost:4495/Product/Index");
        }
        
        [When(@"商品規格為")]
        public void When商品規格為(Table table)
        {
            var productModels = table.CreateInstance<ProductModels>();

            driver.FindElement(By.Id("Name")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys(productModels.Name);
            driver.FindElement(By.Id("Length")).Click();
            driver.FindElement(By.Id("Length")).Clear();
            driver.FindElement(By.Id("Length")).SendKeys(productModels.Length.ToString());
            driver.FindElement(By.Id("Width")).Clear();
            driver.FindElement(By.Id("Width")).SendKeys(productModels.Width.ToString());
            driver.FindElement(By.Id("Height")).Clear();
            driver.FindElement(By.Id("Height")).SendKeys(productModels.Height.ToString());
            driver.FindElement(By.Id("Weight")).Clear();
            driver.FindElement(By.Id("Weight")).SendKeys(productModels.Weight.ToString());
            driver.FindElement(By.Id("Company")).Click();


        }
        
        [When(@"選擇(.*)")]
        public void When選擇(string shipperName)
        {
            new SelectElement(driver.FindElement(By.Id("Company"))).SelectByText(shipperName);
        }
        
        [When(@"點選計算運費")]
        public void When點選計算運費()
        {
            driver.FindElement(By.XPath("//input[@value='計算運費']")).Click();
        }
        
        [Then(@"運費結果應為 (.*)")]
        public void Then運費結果應為(double fee)
        {
           Assert.AreEqual(fee.ToString(), driver.FindElement(By.Id("fee")).Text);
        }
    }
}
