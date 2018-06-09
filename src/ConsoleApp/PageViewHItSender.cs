using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Google.Analytics.SDK.Core.Services.Interfaces;

namespace ConsoleApp
{
    class PageViewHItSender
    {
        public static bool Send(ITracker tracker)
        {
            var hit = new PageViewHit(tracker, "location", "hostname", "path", "title");
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

            var request = (Hitrequest)tracker.CreateHitRequest(hit);

            var debugRequest = Task.Run(() => request.ExecuteDebugAsync());
            debugRequest.Wait();
            Console.Write(debugRequest.Result.RawResponse);

            var x = (DebugResult)debugRequest.Result;
            if (x.Response?.hitParsingResult == null && !x.Response.hitParsingResult.FirstOrDefault().valid)
                return false;


            var collectRequest = Task.Run(() => request.ExecuteCollectAsync());
            collectRequest.Wait();
            Console.Write(collectRequest.Result.RawResponse);
            return true;



        }

    }
}
