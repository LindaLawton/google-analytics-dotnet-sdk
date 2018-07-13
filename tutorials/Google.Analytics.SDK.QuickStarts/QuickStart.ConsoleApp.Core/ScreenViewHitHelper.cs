using Google.Analytics.SDK.Core.Extensions;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Google.Analytics.SDK.Core.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Hits.MobileHits;

namespace QuickStart.ConsoleApp.Core
{
    class ScreenViewHitHelper
    {

        public static async Task<bool> SendAsync(ITracker tracker, string screenName)
        {
            var hit = new ScreenViewHit(screenName)
            {
                
                DataSource = "app",
            };

            var request = (HitRequestBase)tracker.CreateHitRequest(hit);

            var debugResponse = await request.ExecuteDebugAsync();
            Console.Write(debugResponse.RawResponse);

            var response = (DebugResult)debugResponse;

            if (!response.Response.hitParsingResult.FirstOrDefault().valid) return false;

            Console.Write(response.Response.hitParsingResult.FirstOrDefault().valid);

            var collectRequest = await request.ExecuteCollectAsync();
            Console.Write(collectRequest.RawResponse);

            return true;
        }
    }
}
