using Google.Analytics.SDK.Core.Extensions;
using Google.Analytics.SDK.Core.Hits.MobileHits;
using Google.Analytics.SDK.Core.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Hits.WebHits;

namespace QuickStart.WebAPI.Core
{
    class PageViewHitHelper
    {

        public static async Task<bool> SendAsync(ITracker tracker, string documentLocation)
        {
            var hit = new PageViewHit(documentLocation)
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
