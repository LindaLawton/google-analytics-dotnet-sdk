using System;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Extensions;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Services.Interfaces;

namespace QuickStart.ConsoleApp.Classic.HitHelpers
{
    class ExceptionHitHelper
    {
        public static async Task<bool> SendAsync(ITracker tracker, string exceptionDescription, bool fatal)
        {
            var hit = new ExceptionHit(exceptionDescription, fatal)
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