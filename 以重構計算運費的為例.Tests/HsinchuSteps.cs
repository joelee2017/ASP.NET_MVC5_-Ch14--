using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using 以重構計算運費的為例.Models;

namespace 以重構計算運費的為例.Tests
{
    [Binding]
    [Scope(Feature = "Hsinchu")]
    public class HsinchuSteps
    {
        private Hsinchu target;

        [BeforeScenario]
        public void BeforeScenario()
        {
            this.target = new Hsinchu();
        }

        [Given(@"商品規格為")]
        public void Given商品規格為(Table table)
        {
            var product = table.CreateInstance<ProductModels>();
            ScenarioContext.Current.Set<ProductModels>(product);
        }

        [When(@"呼叫計算運費")]
        public void When呼叫計算運費()
        {
            var product = ScenarioContext.Current.Get<ProductModels>();
            var actual = this.target.CalculateFee(product);

            ScenarioContext.Current.Set<double>(actual, "fee");
        }

        [Then(@"運費結果應為 (.*)")]
        public void Then運費結果應為(double fee)
        {
            var actual = ScenarioContext.Current.Get<double>("fee");

            Assert.AreEqual(fee, actual);
        }
    }
}
