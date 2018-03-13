using System;
using OpenQA.Selenium;

namespace SlickDealsNotifier
{
    public interface IWebElementDealParser
    {
        Deal Parse(IWebElement containerElement);
    }
}
