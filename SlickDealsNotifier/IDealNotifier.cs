using System;
using System.Threading.Tasks;

namespace SlickDealsNotifier
{
    public interface IDealNotifier
    {
        Task NotifyAsync(Deal deal);
    }
}
