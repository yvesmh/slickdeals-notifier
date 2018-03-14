using System;
using OpenQA.Selenium;

namespace SlickDealsNotifier
{
    public class WebElementDealParser : IWebElementDealParser
    {
        public Deal Parse(IWebElement containerElement)
        {
            var titleElement = containerElement
                .FindElement(By.ClassName("itemTitle"));
            
            var title = titleElement.Text;
            var price = containerElement
                .FindElement(By.ClassName("itemPrice"))
                .Text;
            var store = containerElement
                .FindElement(By.ClassName("itemStore"))
                .Text;
            var votesString = containerElement
                .FindElement(By.ClassName("count"))
                .Text;
            int votes;
            int.TryParse(votesString, out votes);
            var isFire = containerElement
                .FindElements(By.CssSelector("fire.icon.icon-fire"))
                .Count > 0;

            var url = titleElement.GetAttribute("href");

            return new Deal
            {
                Title = title,
                Price = price,
                Store = store,
                Votes = votes,
                IsFire = isFire,
                Url = url
            };

        }
    }
}
