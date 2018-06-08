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
        
        public string Type { get; private set; }
        public string TrackingId { get; }
        public string ClientId { get; }

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
            ClientId = Guid.NewGuid().ToString();
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