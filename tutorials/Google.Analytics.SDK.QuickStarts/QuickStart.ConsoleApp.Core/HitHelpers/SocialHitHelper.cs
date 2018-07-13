using Google.Analytics.SDK.Core.Extensions;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace QuickStart.ConsoleApp.Core.HitHelpers
{
    class SocialHitHelper
    {
        public static async Task<bool> SendAsync(ITracker tracker, string socialNetwork, string socialAction, string socialActionTarget)
        {
            var hit = new SocialHit(socialNetwork, socialAction, socialActionTarget)
            {
                DataSource = "app"
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
