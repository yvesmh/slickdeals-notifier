using System;
namespace SlickDealsNotifier
{
    public interface IDealNotifier
    {
        void Notify(Deal deal);
    }
}
