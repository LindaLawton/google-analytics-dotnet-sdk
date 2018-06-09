using System;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;
using Xunit;

namespace Google.Analytics.SDK.Tests.Trackers
{
    public class TrackerTests
    {
        const string WebPropertyId = "UA-1111-1";

        [Fact]
        public void Assert_BuildMobileTracker_Builds_MobileTracker()
        {
            var tracker = Tracker.BuildMobileTracker(WebPropertyId);
            Assert.Equal(tracker.Type, GaTrackerType.Mobile);
            Assert.NotNull(tracker.ApplicationName);
            Assert.NotNull(tracker.ClientId);
            Assert.Equal(tracker.TrackingId, WebPropertyId);
        }

        [Fact]
        public void Assert_BuildWebTracker_Builds_WebTracker()
        {
            var tracker = Core.Tracker.BuildWebTracker("UA-11111-1");
            Assert.Equal(tracker.Type, GaTrackerType.Web);
        }

        [Fact]
        public void BuildMobileTracker_Null_WebProperty_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Core.Tracker.BuildMobileTracker(null));
        }

        [Fact]
        public void BuildWebTracker_Null_WebProperty_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Core.Tracker.BuildWebTracker(null));
        }

        [Fact]
        public void TestMethod1()
        {
            var tracker = Core.Tracker.BuildWebTracker("ua-0000-1");

            var pageHit = new PageViewHit(tracker, "X");

            var requset = tracker.CreateHitRequest(pageHit);

            //var results = requset.ExecuteAsync();  // todo get awaiter

            var x = new ScreenViewHit(tracker, "test");
            var m = x.BuildPropertyString("ProtocolVersion");
            Assert.True(x.ProtocolVersion != null);
        }


    }
}
