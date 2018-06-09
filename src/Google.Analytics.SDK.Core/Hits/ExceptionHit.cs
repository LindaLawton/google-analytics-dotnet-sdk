using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public class ExceptionHit : Hit
    {
        public ExceptionHit() : base()
        {
            HitType = HitTypes.Exception;
        }
    }
}