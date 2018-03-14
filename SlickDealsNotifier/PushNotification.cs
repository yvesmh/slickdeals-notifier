using System;
namespace SlickDealsNotifier
{
    public class PushNotification
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
        public string ChannelTag { get; set; }
    }
}
