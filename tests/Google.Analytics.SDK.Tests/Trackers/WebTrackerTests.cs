using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits.MobileHits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using System;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Google.Analytics.SDK.Tests.Trackers
{
    public class MockTracker : ITracker
    {
        public ILogger Logger { get; } = new NoLogging();
        public string TrackingId { get; } = "UA-1111-1";
        public string ClientId { get; } = "0000-0000-0000-0000";
        public string ApplicationName { get; } = "MockTracker";
        public string ApplicationId { get; } = "123456";
        public string ApplicationVersion { get; } = "1.0.0";
        public Task IsValid()
        {
            throw new NotImplementedException();
        }

        
    }

    public class MockRequest : IRequest
    {
        public MockRequest(HitBase requestHit) 
        {
        }

        public ILogger Logger { get; }
        public string Parms { get; }
        public HitBase RequestHit { get; }
        public Task<string> ExecuteAsync(string type)
        {
            return Task.FromResult<string>("Empty");
        }

        public void EnableLogging(ILogger logger)
        {
            
        }

        public Task<IResult> ExecuteCollectAsync()
        {
            return Task.FromResult<IResult>(new CollectResult("{}"));
        }

        public Task<IResult> ExecuteDebugAsync()
        {
            return Task.FromResult<IResult>(new DebugResult("{}"));
        }
    }

    public class MockHit : HitBase
    {
        public MockHit()
        {

        }
    }

    public class SendRequestTests
    {
        [Fact]
        public async void SendTest()
        {
            var tracker = new MockTracker();
            var hit = new MockHit();
            var request = new MockRequest(hit);
            var responseCollect = await request.ExecuteCollectAsync();
            var responseDebug = await request.ExecuteDebugAsync();
            int i = 1;

        }
    }

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
            Assert.Throws<ArgumentNullException>(() => TrackerBuilder.BuildMobileTracker(null));
        }

        [Fact]
        public void BuildWebTracker_Null_WebProperty_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => TrackerBuilder.BuildWebTracker(null));
        }

        [Fact]
        public void TestMethod1()
        {
            var tracker = TrackerBuilder.BuildWebTracker(WebPropertyId);
            var pageHit = new PageViewHit("X");
            var request = tracker.CreateHitRequest(pageHit);

            //var results = requset.ExecuteAsync();  // todo get awaiter

            var x = new ScreenViewHit("test");
            var m = x.BuildPropertyString("ProtocolVersion");
            Assert.True(x.ProtocolVersion != null);
        }


    }
}
