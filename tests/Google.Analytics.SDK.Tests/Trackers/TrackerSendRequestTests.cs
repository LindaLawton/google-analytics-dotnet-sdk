using Xunit;

namespace Google.Analytics.SDK.Tests.Trackers
{
    public class TrackerSendRequestTests
    {
        [Fact]
        public async void SendTest()
        {
            var tracker = new MockTracker();
            var hit = new MockHit();
            var request = new MockRequest(hit);
            var responseCollect = await request.ExecuteCollectAsync();
            var responseDebug = await request.ExecuteDebugAsync();
        }
    }
}