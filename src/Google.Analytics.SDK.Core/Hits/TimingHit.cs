using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class TimingHitBase : HitBase
    {
        protected TimingHitBase()
        {
            HitType = HitTypes.Timing;
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

    public class TimingHit : TimingHitBase
    {
        public TimingHit() : base()
        {
            
        }
    }
}