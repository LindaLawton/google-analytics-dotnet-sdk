using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.MobileHits;
using Google.Analytics.SDK.Core.Services.Interfaces;

namespace ConsoleApp
{
    class ScreenViewHitSender
    {

        public static bool Send(ITracker tracker)
        {
            var hit = new ScreenViewHit("Home")
            {
                UserId = "123456",
                DataSource = "app",
                GeographicalOverride = "US",
                IpOverride = "1.1.1.1",
                UserAgentOverride = "Opera/9.80 (Windows NT 6.0) Presto/2.12.388 Version/12.14",
                ScreenResolution = "100x100",
                ViewportSize = "50x50",
                DocumentEncoding = "UTF-8",
                ScreenColors = "24-bits",
                // System info
                UserLanguage = "de-CH",
                JavaEnabled = "1",
                FlashVersion = "10 1 r103"
            };

            var request = (HitRequestBase)tracker.CreateHitRequest(hit);

            var debugResponse = Task.Run(() => request.ExecuteDebugAsync());
            debugResponse.Wait();
            Console.Write(debugResponse.Result.RawResponse);

            var response = (DebugResult)debugResponse.Result;

            if (!response.Response.hitParsingResult.FirstOrDefault().valid) return false;

            Console.Write(response.Response.hitParsingResult.FirstOrDefault().valid);

            var collectRequest = Task.Run(() => request.ExecuteCollectAsync());
            collectRequest.Wait();
            Console.Write(collectRequest.Result.RawResponse);

            return true;
        }
    }
}
