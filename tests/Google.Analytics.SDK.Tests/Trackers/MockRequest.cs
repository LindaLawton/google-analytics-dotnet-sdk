using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Google.Analytics.SDK.Tests.Trackers
{
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
}