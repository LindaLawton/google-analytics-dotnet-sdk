using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using System;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Hits.MobileHits;
using Xunit;

namespace Google.Analytics.SDK.Tests.Trackers
{
    public class WebTrackerTests
    {
        private const string WebPropertyId = "UA-1111-1";

        [Fact]
        public void Assert_BuildWebTracker_Builds_WebTracker()
        {
            var tracker = Core.TrackerBuilder.BuildWebTracker(WebPropertyId);
            Assert.Equal(tracker.Type, GaTrackerType.Web);
            Assert.NotNull(tracker.ClientId);
            Assert.Equal(tracker.TrackingId, WebPropertyId);
        }

        [Fact]
        public void BuildMobileTracker_Null_WebProperty_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Core.TrackerBuilder.BuildMobileTracker(null));
        }

        [Fact]
        public void BuildWebTracker_Null_WebProperty_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Core.TrackerBuilder.BuildWebTracker(null));
        }

        [Fact]
        public void TestMethod1()
        {
            var tracker = Core.TrackerBuilder.BuildWebTracker(WebPropertyId);

            var pageHit = new PageViewHit("X");

            var requset = tracker.CreateHitRequest(pageHit);

            //var results = requset.ExecuteAsync();  // todo get awaiter

            var x = new ScreenViewHit("test");
            var m = x.BuildPropertyString("ProtocolVersion");
            Assert.True(x.ProtocolVersion != null);
        }


    }
}
