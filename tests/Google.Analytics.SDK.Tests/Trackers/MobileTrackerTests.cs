using System;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;
using Xunit;

namespace Google.Analytics.SDK.Tests.Trackers
{
    public class MobileTrackerTests
    {
        const string WebPropertyId = "UA-11111-1";

        [Fact]
        public void Assert_BuildMobileTracker_Builds_MobileTracker()
        {
            var tracker = Tracker.BuildMobileTracker(WebPropertyId);
            Assert.Equal(tracker.Type, GaTrackerType.Mobile);
        }

        [Fact]
        public void BuildMobileTracker_Null_WebProperty_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Tracker.BuildMobileTracker(null));
        }

        
        [Fact]
        public void BuildWebTracker()
        {
            var tracker = Tracker.BuildWebTracker("UA-0000-1");

            var pageHit = new PageViewHit(tracker, "X");

            var requset = tracker.CreateHitRequest(pageHit);

            

            //var results = requset. .ExecuteAsync();  // todo get awaiter

            var x = new ScreenViewHit(tracker, "test");
            var m = x.BuildPropertyString("ProtocolVersion");
            Assert.True(x.ProtocolVersion != null);
        }


    }
}
