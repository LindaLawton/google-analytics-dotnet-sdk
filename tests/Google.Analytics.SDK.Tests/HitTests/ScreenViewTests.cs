using System;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits.MobileHits;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class ScreenViewTests
    {
        [Fact]
        public void Create_ScreenViewHit_All_Validate_Success()
        {
            var hit = new ScreenViewHit("Home");
            Assert.True(hit.Validate());
        }
        [Fact]
        public void Create_ScreenViewHit_Validate_Fail()
        {
            var hit = new ScreenViewHit("Home");
            hit.ScreenName = null;
            Assert.False(hit.Validate());
        }

        [Fact]
        public void Create_SocailHit_SocialNetwork_Null_throwsException()
        {
            Assert.Throws<ArgumentNullException>(() => new ScreenViewHit(""));
        }


        [Fact]
        public void Create_ScreenViewHit_HitType_NotNull()
        {
            var hit = new ScreenViewHit("home");
            Assert.Equal(hit.HitType, HitTypes.Screenview, ignoreCase: true);
        }

    }
}