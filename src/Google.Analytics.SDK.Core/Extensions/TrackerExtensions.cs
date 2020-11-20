using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Services.Interfaces;

namespace Google.Analytics.SDK.Core.Extensions
{
    public static class TrackerExtensions{
        
        public static IRequest CreateHitRequest(this ITracker tracker, HitBase hit)
        {
            hit.ClientId = tracker.ClientId;
            hit.WebPropertyId = tracker.TrackingId;
            return new HitRequestBase(hit);
        }
    }
}