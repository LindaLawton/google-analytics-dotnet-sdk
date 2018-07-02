using System;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Services.Interfaces;
using Microsoft.Extensions.Logging;

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
}