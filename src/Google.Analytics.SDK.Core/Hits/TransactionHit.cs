using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public class TransactionHit : Hit
    {
        public TransactionHit(string transactionId) : base()
        {
            HitType = HitTypes.Transaction;
            TransactionId = transactionId;
        }
    }
}