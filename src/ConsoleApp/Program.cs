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

            var trackerMobile = TrackerBuilder.BuildMobileTracker("UA-59183475-3");
            var hit = new ScreenViewHit("Home");
            hit.UserId = "123456";
            hit.DataSource = "app";
            hit.UserLanguage = "de-CH";
            hit.GeographicalOverride = "US";
            hit.IpOverride = "1.1.1.1";
            hit.UserAgentOverride = "Opera/9.80 (Windows NT 6.0) Presto/2.12.388 Version/12.14";

            // System info
            hit.ScreenResolution = "100x100";
            hit.ViewportSize = "50x50";
            hit.DocumentEncoding = "UTF-8";
            hit.ScreenColors = "24-bits";
            hit.UserLanguage = "de-CH";
            hit.JavaEnabled = "1";
            hit.FlashVersion = "10 1 r103";

            var request = (Hitrequest)trackerMobile.CreateHitRequest(hit);

            var debugRequest = Task.Run(() => request.ExecuteDebugAsync());
            debugRequest.Wait();
            Console.Write(debugRequest.Result.RawResponse);

            var response = (DebugResult)debugRequest.Result;

            Console.Write(response.Response.hitParsingResult.FirstOrDefault().valid);


            var collectRequest = Task.Run(() => request.ExecuteCollectAsync());
            collectRequest.Wait();
            Console.Write(collectRequest.Result.RawResponse);
           




            Console.WriteLine("Hello World!");
        }
    }
}
