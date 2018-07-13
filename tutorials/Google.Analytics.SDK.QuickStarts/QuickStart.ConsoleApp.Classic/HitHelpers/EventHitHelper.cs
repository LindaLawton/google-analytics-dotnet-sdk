using System;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Extensions;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Services.Interfaces;

namespace QuickStart.ConsoleApp.Classic.HitHelpers
{
    class EventHitHelper
    {
        public static async Task<bool> SendAsync(ITracker tracker, string eventCatagory, string eventAction, string eventLabel)
        {
            var hit = new EventHit(eventCatagory, eventAction, eventLabel)
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
