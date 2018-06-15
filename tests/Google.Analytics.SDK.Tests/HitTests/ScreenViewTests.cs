using System;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits.MobileHits;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class ScreenViewTests
    {
        private const string ScreenName = "Home";
        private const string HitType = HitTypes.Screenview;

        [Fact]
        public void Create_ScreenViewHit_All_Validate_Success()
        {
            var hit = new ScreenViewHit(ScreenName);
            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_PageViewHit_All_Validate_Values()
        {
            var hit = new ScreenViewHit(ScreenName);
            Assert.Equal(ScreenName, hit.ScreenName);
            Assert.Equal(HitType, hit.HitType, true);
        }

        [Fact]
        public void Create_ScreenViewHit_Validate_Fail()
        {
            var hit = new ScreenViewHit(ScreenName);
            hit.ScreenName = null;
            Assert.False(hit.Validate());
        }

        [Fact]
        public void Create_SocailHit_SocialNetwork_Null_throwsException()
        {
            Assert.Throws<ArgumentNullException>(() => new ScreenViewHit(string.Empty));
        }

    }
}