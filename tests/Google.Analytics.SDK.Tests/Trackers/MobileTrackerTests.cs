using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits.MobileHits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using System;
using Xunit;

namespace Google.Analytics.SDK.Tests.Trackers
{
    public class MobileTrackerTests
    {
        const string WebPropertyId = "UA-11111-1";

        [Fact]
        public void Assert_BuildMobileTracker_Builds_MobileTracker()
        {
            var tracker = GaTrackerBuilder.BuildMobileTracker(WebPropertyId);
            Assert.Equal(tracker.Type, GaTrackerType.Mobile);
            Assert.NotNull(tracker.ApplicationName);
            Assert.NotNull(tracker.ClientId);
            Assert.Equal(tracker.TrackingId, WebPropertyId);
        }

        [Fact]
        public void BuildMobileTracker_Null_WebProperty_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GaTrackerBuilder.BuildMobileTracker(null));
        }

        
        [Fact]
        public void BuildWebTracker()
        {
            var tracker = GaTrackerBuilder.BuildWebTracker("UA-0000-1");

            var pageHit = new PageViewHit("X");

            var requset = tracker.CreateHitRequest(pageHit);

            

            //var results = requset. .ExecuteAsync();  // todo get awaiter

            var x = new ScreenViewHit("test");
            var m = x.BuildPropertyString("ProtocolVersion");
            Assert.True(x.ProtocolVersion != null);
        }

    }
}
