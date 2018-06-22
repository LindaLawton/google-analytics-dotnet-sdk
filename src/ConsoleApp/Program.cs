using Google.Analytics.SDK.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace ConsoleApp
{
    public class MyTracker 
    {
        private static GaTracker _tracker;

        public static void Initialize()
        {
            _tracker = GaTrackerBuilder.BuildWebTracker("UA-59183475-1");
            
        }
    }

    class Program
    {



        static void Main(string[] args)
        {
            MyTracker.Initialize();
            var tracker = GaTrackerBuilder.BuildWebTracker("UA-59183475-1");
            
            var serviceProvider = new ServiceCollection()
                    .AddLogging(configure => configure.AddConsole())
                    .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Trace)
                    .AddTransient<Program>()
                .AddSingleton(GaTrackerBuilder.BuildWebTracker("UA-59183475-1"))
                .AddTransient<MyTracker>()
                .BuildServiceProvider();
            tracker.ConfigurLogging(serviceProvider.GetService<ILogger<GaTracker>>());
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();


            logger.LogCritical("Critical error");
            logger.LogTrace("trace info");


            PageViewHItSender.Send(tracker);
           // EventHitSender.Send(tracker);

            //var trackerMobile = GaTrackerBuilder.BuildMobileTracker("UA-59183475-3");
            //ScreenViewHitSender.Send(trackerMobile);
            //EventHitSender.Send(trackerMobile);

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
