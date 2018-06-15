using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class ItemHitBase : HitBase
    {
        protected ItemHitBase(string transactionId)
        {
            HitType = HitTypes.Item;
            TransactionId = transactionId;
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