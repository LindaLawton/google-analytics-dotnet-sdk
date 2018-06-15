using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class SocialHitBase : HitBase
    {
        protected SocialHitBase() 
        {
            HitType = HitTypes.Social;
        }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }

        public bool Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public class SocialHit : SocialHitBase
    {
        public SocialHit() : base()
        {
            
        }
    }
}