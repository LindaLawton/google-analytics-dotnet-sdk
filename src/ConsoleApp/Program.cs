using System;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Google.Analytics.SDK.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger.LogCritical("test");

            var tracker = TrackerBuilder.BuildWebTracker("UA-59183475-1");
            tracker.ConfigurLogging(serviceProvider.GetService<ILogger<GaTracker>>());

            PageViewHItSender.Send(tracker);
            EventHitSender.Send(tracker);

            var trackerMobile = TrackerBuilder.BuildMobileTracker("UA-59183475-3");
            ScreenViewHitSender.Send(trackerMobile);
            EventHitSender.Send(trackerMobile);

            //https://www.blinkingcaret.com/2018/02/14/net-core-console-logging/

            Console.WriteLine("Hello World!");
        }


        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information)
                .AddTransient<Program>();
        }
    }
}
