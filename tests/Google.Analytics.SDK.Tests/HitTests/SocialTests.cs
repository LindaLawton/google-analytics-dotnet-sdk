using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using System;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class SocialTests
    {
        private const string SocialNetworkName = "Google+";
        private const string SocialAction = "1+";
        private const string SocialActionTargit = "https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C";

        private const string HitType = HitTypes.Social;

        [Fact]
        public void Create_SocailHit_Validate_Success()
        {
            var hit = new SocialHit(SocialNetworkName, SocialAction, SocialActionTargit);
            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_SocailHit_All_Validate_Values()
        {
            var hit = new SocialHit(SocialNetworkName, SocialAction, SocialActionTargit);
            Assert.Equal(SocialNetworkName, hit.SocialNetwork);
            Assert.Equal(SocialAction, hit.SocialAction);
            Assert.Equal(SocialActionTargit, hit.SocialActionTarget);
            Assert.Equal(HitType, hit.HitType, true);
        }


        [Fact]
        public void Create_SocailHit_Validate_Fail()
        {
            var hit = new SocialHit(SocialNetworkName, SocialAction, SocialActionTargit);
            hit.SocialActionTarget = null;
            Assert.False(hit.Validate());
        }

        [Fact]
        public void Create_SocailHit_SocialNetwork_Null_throwsException()
        {
            Assert.Throws<ArgumentNullException>(() => new SocialHit(string.Empty, SocialAction, SocialActionTargit));
        }

        [Fact]
        public void Create_SocailHit_SocailAction_Null_throwsException()
        {
            Assert.Throws<ArgumentNullException>(() => new SocialHit(SocialNetworkName, string.Empty, SocialActionTargit));
        }

        [Fact]
        public void Create_SocailHit_SocialActionTargit_Null_throwsException()
        {
            Assert.Throws<ArgumentNullException>(() => new SocialHit(SocialNetworkName, SocialAction, string.Empty));
        }
        
    }
}
