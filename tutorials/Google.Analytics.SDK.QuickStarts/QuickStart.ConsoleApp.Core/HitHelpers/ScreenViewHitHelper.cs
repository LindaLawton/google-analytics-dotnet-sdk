using Google.Analytics.SDK.Core.Extensions;
using Google.Analytics.SDK.Core.Hits.MobileHits;
using Google.Analytics.SDK.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace QuickStart.ConsoleApp.Core.HitHelpers
{
    class ScreenViewHitHelper
    {

        public static async Task<bool> SendAsync(ITracker tracker, string screenName)
        {
            var hit = new ScreenViewHit(screenName)
            {
                DataSource = "app",
                UserAgentOverride = @"Mozilla/5.0 (Linux; Android 4.0.4; Galaxy Nexus Build/IMM76B) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.133 Mobile Safari/535.19"
            };

            // create the hit request.
            var request = (HitRequestBase)tracker.CreateHitRequest(hit);

            // Run a debug check to ensure its valid.
            var debugResponse = await request.ExecuteDebugAsync();
            if (!((DebugResult)debugResponse).IsValid()) return false;
            
            // Send hit.
            var collectRequest = await request.ExecuteCollectAsync();
            Console.Write(collectRequest.RawResponse);

            return true;
        }
    }
}
