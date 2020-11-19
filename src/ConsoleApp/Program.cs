using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Ga4;
using Google.Analytics.SDK.Core.Ga4.Request;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Google.Analytics.SDK.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    class Program
    {
        private const string DemoDataApplicationWebProplerty = "UA-53766825-1";
        private const string DemoDataWebApplicationWebProplerty = "UA-53766825-2";


        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var tracker = TrackerBuilder.BuildWebTracker(DemoDataWebApplicationWebProplerty);
            PageViewHItSender.Send(tracker);
            EventHitSender.Send(tracker);

            var trackerMobile = TrackerBuilder.BuildMobileTracker(DemoDataApplicationWebProplerty);
            ScreenViewHitSender.Send(trackerMobile);
            EventHitSender.Send(trackerMobile);
            
            
            // GA4
            var client = new HttpClient();
            var settings = new Ga4Settings()
            {
                MeasurmentId = "secret",
                ApiSecret = "Secret",
                ClientId = "123456"
            };

            var items = new Dictionary<string, string> ()
            {
                {"car", "Test Car"},
                {"house", "test house"}
            };

            var logger = new Logger<GA4Tracker>(new LoggerFactory()); 
            
            var userId = "123654";
            var trackerGa4 = new GA4Tracker(client, settings, logger, userId);
            
            List<Ga4Event> events = new List<Ga4Event>()
            {
                Ga4EventBuilder.Login("Logging in"),
                Ga4EventBuilder.Refund("T1","1","DKK","1","1",items),
                Ga4EventBuilder.Search("Find something"),
                Ga4EventBuilder.Share("test","test"),
                Ga4EventBuilder.JoinGroup("group test"),
                Ga4EventBuilder.PresentOffer("test","test","test"),
                Ga4EventBuilder.SelectContent("ContentType","ItemId1"),
                Ga4EventBuilder.SignUp("signup"),
                Ga4EventBuilder.TutorialBegin(),
                Ga4EventBuilder.TutorialComplete(),
                Ga4EventBuilder.EarnVirtualCurrency("DKK","123"),
                Ga4EventBuilder.SpendVirtualCurrency("dkk","234","ItemName")};

            var debug = true;
            await trackerGa4.SendAsync(events, debug);

            Console.WriteLine("Hello World!");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                .AddTransient<Program>();
        }
    }
}
