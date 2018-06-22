using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Google.Analytics.SDK.Core.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    class PageViewHItSender
    {
        public static bool Send(ITracker tracker)
        {
            var hit = new PageViewHit("location", "hostname", "path", "title")
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

            var request = (Hitrequest)tracker.CreateHitRequest(hit);
            tracker.Logger.LogTrace("Request Parms:{parms}", request.Parms);

            var debugResponse = Task.Run(() => request.ExecuteDebugAsync());
            debugResponse.Wait();

            tracker.Logger.LogDebug("Raw Response {response}", debugResponse.Result.RawResponse);

            var response = (DebugResult)debugResponse.Result;

            if (response.Response.hitParsingResult.FirstOrDefault() == null ||
                !response.Response.hitParsingResult.FirstOrDefault().valid)
            {
                tracker.Logger.LogError("Request is not valid {response}", debugResponse.Result.RawResponse);
                return false;
            }

            tracker.Logger.LogInformation("Request is valid {response}", debugResponse.Result.RawResponse);

            var collectRequest = Task.Run(() => request.ExecuteCollectAsync());
            collectRequest.Wait();
            tracker.Logger.LogDebug("Raw Response {response}", debugResponse.Result.RawResponse);

            return true;

        }

    }
}
