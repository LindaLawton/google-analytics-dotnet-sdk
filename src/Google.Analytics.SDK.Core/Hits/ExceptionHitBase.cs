using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public class ExceptionHitBase : HitBase
    {
        protected ExceptionHitBase()
        {
            HitType = HitTypes.Exception;
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
}