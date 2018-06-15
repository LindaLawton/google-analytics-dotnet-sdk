using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class TransactionHitTests
    {
        private const string TransactionId = "123";

        [Fact]
        public void Create_TransactionHit_All_Validate_Success()
        {
            var hit = new TransactionHit(TransactionId);
            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_TransactionHit_All_Validate_Values()
        {
            var hit = new TransactionHit(TransactionId);
            Assert.Equal(TransactionId, hit.TransactionId);
        }

        [Fact]
        public void Create_TransactionHit_NoTransactionId_Fail()
        {
            var hit = new TransactionHit(TransactionId);
            hit.TransactionId = null;
            Assert.False(hit.Validate());
        }

        [Fact]
        public void Create_TransactionHit_HitType_Transaction_Sucess()
        {
            var hit = new TransactionHit(TransactionId);
            Assert.Equal(hit.HitType, HitTypes.Transaction, ignoreCase: true);
        }

    }
}