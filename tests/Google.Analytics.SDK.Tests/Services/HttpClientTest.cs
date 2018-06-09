using System;
using System.Collections.Generic;
using System.Text;
using Google.Analytics.SDK.Core.Helper;
using Xunit;

namespace Google.Analytics.SDK.Tests.Services
{
    public class HttpClientTest
    {

        [Fact]
        public void CreateClient()
        {
            var tracker = Core.TrackerBuilder.BuildMobileTracker("x");
            Assert.Equal(tracker.Type, GaTrackerType.Mobile);
        }
    }
}
