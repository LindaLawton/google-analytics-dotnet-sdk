using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Services.Interfaces;

namespace Google.Analytics.SDK.Core.Hits
{
    public class ScreenViewHit : Hit
    {
        public ScreenViewHit(ITracker tracker, string screenName) : base(tracker)
        {
            HitType = HitTypes.Screenview;
            ScreenName = screenName;
        }
    }
}