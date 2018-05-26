using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Reflection;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.Analytics.SDK.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tracker = Tracker.BuildWebTracker("XXX-0000-XXX");


            var pageHit = new PageViewHit("X");

            var requset = tracker.CreateDebugRequest(pageHit);

            var results = requset.ExecuteAsync();  // todo get awaiter


            var x = new ScreenViewHit("test");
            var m = x.BuildPropertyString("ProtocolVersion");
            Assert.IsNotNull(x.ProtocolVersion);
        }
    }
}
