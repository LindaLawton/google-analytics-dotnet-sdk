using System;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class TimingHitTests
    {
        

        private const string UserTimeingCatagory = "Catagory";
        private const string UserTimeingVariableName = "Lookup";
        private const int UserTimingTime = 1;
        
        private const string HitType = HitTypes.Timing;

        [Fact]
        public void Create_PageViewHit_All_Validate_Success()
        {
            var hit = new TimingHit(UserTimeingCatagory, UserTimeingVariableName, UserTimingTime);
            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_TimingHit_All_Validate_Values()
        {
            var hit = new TimingHit(UserTimeingCatagory, UserTimeingVariableName, UserTimingTime);
            Assert.Equal(UserTimeingCatagory, hit.UserTimingCatagory);
            Assert.Equal(UserTimeingVariableName, hit.UserTimingVariableName);
            Assert.Equal(UserTimingTime.ToString(), hit.UserTimingTime);
            Assert.Equal(HitType, hit.HitType, true);
        }

        [Fact]
        public void Create_EventHit_Catagory_Null_throwsException()
        {
            Assert.Throws<ArgumentNullException>(() => new TimingHit(string.Empty, UserTimeingVariableName, UserTimingTime));
        }

        [Fact]
        public void Create_EventHit_Name_Null_throwsException()
        {
            Assert.Throws<ArgumentNullException>(() => new TimingHit(UserTimeingCatagory, string.Empty, UserTimingTime));
        }

    }
}