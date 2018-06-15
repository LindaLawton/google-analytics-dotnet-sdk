using System;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.MobileHits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Xunit;

namespace Google.Analytics.SDK.Tests.Trackers
{
    public class MobileTrackerTests
    {
        const string WebPropertyId = "UA-11111-1";

        [Fact]
        public void Assert_BuildMobileTracker_Builds_MobileTracker()
        {
            var tracker = TrackerBuilder.BuildMobileTracker(WebPropertyId);
            Assert.Equal(tracker.Type, GaTrackerType.Mobile);
            Assert.NotNull(tracker.ApplicationName);
            Assert.NotNull(tracker.ClientId);
            Assert.Equal(tracker.TrackingId, WebPropertyId);
        }

        [Fact]
        public void BuildMobileTracker_Null_WebProperty_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => TrackerBuilder.BuildMobileTracker(null));
        }

        
        [Fact]
        public void BuildWebTracker()
        {
            var tracker = TrackerBuilder.BuildWebTracker("UA-0000-1");

            var pageHit = new PageViewHit("X");

            var requset = tracker.CreateHitRequest(pageHit);

            

            //var results = requset. .ExecuteAsync();  // todo get awaiter

            var x = new ScreenViewHit("test");
            var m = x.BuildPropertyString("ProtocolVersion");
            Assert.True(x.ProtocolVersion != null);
        }

        [Fact]
        public void Create_SocailHit_Validate_Success()
        {
            var socialHit = new SocialHit("Google+","plus", "https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C");

            Assert.True(socialHit.Validate());
        }

        [Fact]
        public void Create_SocailHit_Validate_Fail()
        {
            var socialHit =
                new SocialHit("Google+", "plus", "https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C")
                {
                    SocialActionTarget = null
                };
            Assert.False(socialHit.Validate());
        }

    }
}
