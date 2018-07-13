using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core;
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


        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var tracker = TrackerBuilder.BuildWebTracker(DemoDataWebApplicationWebProplerty);
            PageViewHItSender.Send(tracker);
            EventHitSender.Send(tracker);

            var trackerMobile = TrackerBuilder.BuildMobileTracker(DemoDataApplicationWebProplerty);
            ScreenViewHitSender.Send(trackerMobile);
            EventHitSender.Send(trackerMobile);

            Console.WriteLine("Hello World!");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                .AddTransient<Program>();
        }
    }
}
