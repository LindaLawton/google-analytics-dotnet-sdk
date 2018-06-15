using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using System;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class SocialTests
    {
        [Fact]
        public void Create_SocailHit_Validate_Success()
        {
            var socialHit = new SocialHit("Google+", "plus", "https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C");

            Assert.True(socialHit.Validate());
        }

        [Fact]
        public void Create_SocailHit_Validate_Fail()
        {
            var socialHit = new SocialHit("Google+", "plus", "https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C");

            socialHit.SocialActionTarget = null;

            Assert.False(socialHit.Validate());
        }

        [Fact]
        public void Create_SocailHit_SocialNetwork_Null_throwsException()
        {
            Assert.Throws<ArgumentNullException>(() => new SocialHit("", "plus", "https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C"));
        }

        [Fact]
        public void Create_SocailHit_SocailAction_Null_throwsException()
        {
            Assert.Throws<ArgumentNullException>(() => new SocialHit("Google+", "", "https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C"));
        }

        [Fact]
        public void Create_SocailHit_SocialActionTargit_Null_throwsException()
        {
            Assert.Throws<ArgumentNullException>(() => new SocialHit("Google+", "plus", ""));
        }

        [Fact]
        public void Create_SocailHit_HitType_NotNull()
        {
            var socialHit = new SocialHit("Google+", "plus", "https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C");
            Assert.Equal(socialHit.HitType, HitTypes.Social, ignoreCase: true);
        }
    }
}
