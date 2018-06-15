using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class TransactionHitBase : HitBase
    {
        protected TransactionHitBase(string transactionId) 
        {
            HitType = HitTypes.Transaction;
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

    public class TransactionHit : TransactionHitBase
    {
        public TransactionHit(string transactionId) : base(transactionId)
        {
            
        }
    }
}