using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public class TimingHit : Hit
    {
        public TimingHit() : base()
        {
            HitType = HitTypes.Timing;
        }
    }
}