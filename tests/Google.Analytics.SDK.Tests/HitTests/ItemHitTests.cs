using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class ItemHitTests
    {
        private const string TransactionId = "123";
        private const string ItemName = "Rubik\'s Cube";
        private const string HitType = HitTypes.Item;
        
        [Fact]
        public void Create_ItemHit_All_Validate_Success()
        {
            var hit = new ItemHit(TransactionId, ItemName);
            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_ItemHit_All_Validate_Values()
        {
            var hit = new ItemHit(TransactionId, ItemName);
            Assert.Equal(TransactionId, hit.TransactionId);
            Assert.Equal(ItemName, hit.ItemName);
            Assert.Equal(HitType, hit.HitType, true);
        }
        

        [Fact]
        public void Create_ItemHit_NullItemName_Fail()
        {
            var hit = new ItemHit(TransactionId, ItemName);
            hit.ItemName = null;
            Assert.False(hit.Validate());
        }

        [Fact]
        public void Create_ItemHit_Null_TransactionId_Fail()
        {
            var hit = new ItemHit(TransactionId, ItemName);
            hit.TransactionId = null;
            Assert.False(hit.Validate());
        }
    }
}