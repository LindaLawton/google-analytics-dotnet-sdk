using System.Collections.Generic;
using System.Linq;
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

        public Dictionary<string, string> Parms { get; }

        public string QueryString => BuildQueryString();
        public HitBase RequestHit { get; }

        private string BuildQueryString()
        {
            return Parms.Count == 0 ? string.Empty : string.Join("&", Parms.Select(p => $"{p.Key}={p.Value}"));
        }

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