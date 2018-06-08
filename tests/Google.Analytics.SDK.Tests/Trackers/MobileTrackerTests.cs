using System;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;
using Xunit;

namespace Google.Analytics.SDK.Tests.Trackers
{
    public class MobileTrackerTests
    {
        const string WebPropertyId = "UA-XXXX-Y";

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
            var tracker = Tracker.BuildWebTracker("XXX-0000-XXX");

            var pageHit = new PageViewHit("X");

            var requset = tracker.CreateHitRequest(pageHit);

            

            //var results = requset. .ExecuteAsync();  // todo get awaiter

            var x = new ScreenViewHit("test");
            var m = x.BuildPropertyString("ProtocolVersion");
            Assert.True(x.ProtocolVersion != null);
        }


    }
}
