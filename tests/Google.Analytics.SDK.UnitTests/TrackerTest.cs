using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Google.Analytics.SDK.UnitTests
{
    [TestClass]
    public class TrackerTest
    {
        const string WebPropertyId = "UA-XXXX-Y";

        [TestMethod]
        public void Creates_New_Mobile_Tracker()
        {
            var tracker = Tracker.BuildMobileTracker(WebPropertyId);
            Assert.AreEqual(tracker.Type, GaTrackerType.Mobile, "Tracker is not mobile.");
            Assert.AreEqual(tracker.TrackingId,WebPropertyId, "Web properit id not set.");
            Assert.IsNotNull(tracker.Version, "tracker.Version != null");
        }

        [TestMethod]
        public void Creates_New_Web_Tracker()
        {
            var tracker = Tracker.BuildWebTracker("UA-XXXX-Y");
            Assert.AreEqual(tracker.Type, GaTrackerType.Web, "Tracker is not web.");
            Assert.AreEqual(tracker.TrackingId, WebPropertyId, "Web properit id not set.");
        }

        [TestMethod]
        public void Create_MobileTracker_WebPropertyId_Null_ShouldThrowArgumentNullException()
        {
            try
            {
                Tracker.BuildMobileTracker(null);
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "webPropertyId");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void Create_WebTracker_WebPropertyId_Null_ShouldThrowArgumentNullException()
        {
            try
            {
                Tracker.BuildWebTracker(null);
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "webPropertyId");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
    }
}
