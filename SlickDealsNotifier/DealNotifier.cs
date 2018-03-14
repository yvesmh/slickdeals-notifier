using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SlickDealsNotifier
{
    public class DealNotifier : IDealNotifier
    {
        public DealNotifier()
        {
        }

        public async Task NotifyAsync(Deal deal)
        {
            var client = new HttpClient();
            const string accessToken = "ReadFromConfig!";
            var uri = "https://api.pushbullet.com/v2/pushes";
            var notification = new PushNotification
            {
                Title = deal.Title,
                Type = "link",
                Body = $"{deal.Price} at {deal.Store} with {deal.Votes}",
                Url = deal.Url,
                ChannelTag = "slickdeals-100-likes" //TODO move to config
            };
            var httpContent = new JsonContent(notification);
            //TODO move to config
            httpContent.Headers.Add("Access-Token", accessToken);
            var result = await client.PostAsync(uri, httpContent);
            Console.WriteLine($"result: {result.Content.ToString()}");
        }
    }
}
