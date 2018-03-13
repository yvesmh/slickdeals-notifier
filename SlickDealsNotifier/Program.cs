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

            using (var driver = new FirefoxDriver())
            {
                var dealFinder = new DealFinder(driver, dealParser);
                var deals =  dealFinder.FindDeals();

                var dealsWithMoreThan100Votes = deals
                    .Where(d => d.Votes >= 100);
                
                foreach(var deal in dealsWithMoreThan100Votes)
                {
                    Console.WriteLine($"Deal found." +
                                      $"Title: {deal.Title}" +
                                      $"Store: {deal.Store}" +
                                      $"Votes: {deal.Votes}");
                }
            }
        }
    }
}
