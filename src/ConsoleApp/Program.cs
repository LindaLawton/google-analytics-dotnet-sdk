using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Google.Analytics.SDK.Core.Services.Interfaces;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tracker = TrackerBuilder.BuildWebTracker("UA-59183475-1");
            PageViewHItSender.Send(tracker);
            EventHitSender.Send(tracker);

            var trackerMobile = TrackerBuilder.BuildMobileTracker("UA-59183475-3");
            ScreenViewHitSender.Send(trackerMobile);
            EventHitSender.Send(trackerMobile);


           




            Console.WriteLine("Hello World!");
        }
    }
}
