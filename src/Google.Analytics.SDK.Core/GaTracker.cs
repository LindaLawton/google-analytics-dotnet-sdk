using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

        public string ApplicationName { get; private set; }
        public string ApplicationId { get; private set; }
        public string ApplicationVersion { get; private set; }

        public void ConfigurApplication(string applicationName = "", string applicationVersion = "", string applicationId = "")
        {
            ApplicationName = string.IsNullOrWhiteSpace(applicationName)? AppDomain.CurrentDomain.FriendlyName : applicationName;
            ApplicationVersion = string.IsNullOrWhiteSpace(applicationName) ? Assembly.GetExecutingAssembly().GetName().Version.ToString() : applicationVersion;
            ApplicationId = string.IsNullOrWhiteSpace(applicationId) ? "1": applicationId;
        }

        public GaTracker(string type, string trackingId)
        {
            Type = type;
            TrackingId = trackingId;
            ConfigurApplication();
        }

        public IRequest CreateHitRequest(Hit hit)
        {
          return new Hitrequest(hit);
        }

        public Task IsValid()
        {
            throw new NotImplementedException();
        }
    }
}