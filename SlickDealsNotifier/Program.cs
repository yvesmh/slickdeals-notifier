using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SlickDealsNotifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Slick Deals Notifier started...");
            var dealParser = new WebElementDealParser();
            var dealNotifier = new DealNotifier();

            using (var driver = new FirefoxDriver())
            {
                var dealFinder = new DealFinder(driver, dealParser);
                var deals =  dealFinder.FindDeals();

                var dealsWithMoreThan100Votes = deals
                    .Where(d => d.Votes >= 100);

                using (var db = new SlickDealsNotifierContext())
                {
                    foreach(var deal in dealsWithMoreThan100Votes)
                    {
                        var alreadyNotified = db.Deals.FirstOrDefault(d =>
                                                            d.Url == deal.Url);

                        if(!alreadyNotified)
                        {
                            dealNotifier.Notify(deal);
                        }
                    }
                }

            }
        }
    }
}
