using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public class SocialHit : Hit
    {
        public SocialHit() : base()
        {
            HitType = HitTypes.Social;
        }
    }
}