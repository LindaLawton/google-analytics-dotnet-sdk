using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public class ItemHit : Hit
    {
        public ItemHit() : base()
        {
            HitType = HitTypes.Item;
        }
    }
}