using System;
using System.Collections.Generic;

namespace SlickDealsNotifier
{
    public interface IDealFinder
    {
        IReadOnlyCollection<Deal> FindDeals();
    }
}
