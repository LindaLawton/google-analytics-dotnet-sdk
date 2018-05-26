using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Services.Interfaces;

namespace Google.Analytics.SDK.Core
{
    public class GaTracker : ITracker
    {
        /// <summary>
        /// Web or mobile Google analytics account used for deciding to send screen view or page view hits.
        /// </summary>
        public string Type { get; private set; }
        
        /// <summary>
        /// The tracking ID / web property ID. The format is UA-XXXX-Y. All collected data is associated by this ID.
        /// </summary>
        public string TrackingId { get; private set; }
        
        public GaTracker(string type, string trackingId)
        {
            Type = type;
            TrackingId = trackingId;
        }

        public IRequest SendHit(Hit hit)
        {
            var x = new DebugRequest(hit);

            return x;

        }

        public IRequest CreateHitRequest(Hit hit)
        {
          return new Hitrequest(hit);
        }

        public IRequest CreateDebugRequest(Hit hit)
        {
            return new DebugRequest(hit);
        }

        public Task IsValid()
        {
            throw new NotImplementedException();
        }
    }
}