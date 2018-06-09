using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public class ItemHit : Hit
    {
        public ItemHit(string transactionId) : base()
        {
            HitType = HitTypes.Item;
            TransactionId = transactionId;
        }
    }
}