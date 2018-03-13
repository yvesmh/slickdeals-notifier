using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace SlickDealsNotifier
{
    public class DealFinder : IDealFinder
    {
        private readonly IWebDriver _driver;
        private readonly IWebElementDealParser _dealParser;

        public DealFinder(IWebDriver driver,
                          IWebElementDealParser dealParser)
        {
            _driver = driver;
            _dealParser = dealParser;
        }

        public IReadOnlyCollection<Deal> FindDeals()
        {
            _driver.Navigate()
                      .GoToUrl("https://slickdeals.net/");
            var dealsElements = _driver.FindElements(
                By.CssSelector(".fpGridBox.grid.frontpage"));
            var deals = new List<Deal>();
            foreach (var dealElement in dealsElements)
            {
                var deal = _dealParser.Parse(dealElement);
                deals.Add(deal);
            }
            return deals;
        }
    }
}
