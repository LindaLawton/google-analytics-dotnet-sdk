using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Google.Analytics.SDK.Core.Extensions;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core
{
    public class Tracker
    {
        public static GaTracker BuildMobileTracker(string webPropertyId, string applicationName = "", string applicationVersion = "", string applicationId = "")
        {
            if (string.IsNullOrWhiteSpace(webPropertyId)) throw new ArgumentNullException("webPropertyId required.");
            var tracker = BuildTracker(GaTrackerType.Mobile, webPropertyId);
            tracker.ConfigurApplication(applicationName, applicationVersion, applicationId);
            return tracker;
        }

        public static GaTracker BuildWebTracker(string webPropertyId)
        {
            var regex = new Regex("^UA-[0-9]*-[0-9]", RegexOptions.IgnoreCase);
            if (!regex.Match(webPropertyId).Success) throw new ArgumentException("Invalid Webpropry format.");

            if (string.IsNullOrWhiteSpace(webPropertyId)) throw new ArgumentNullException("webPropertyId required.");
            return BuildTracker(GaTrackerType.Web, webPropertyId);
        }

        private static GaTracker BuildTracker(string type, string webPropertyId)
        {
            if (string.IsNullOrWhiteSpace(type)) throw new ArgumentNullException("type required.");
            if (string.IsNullOrWhiteSpace(webPropertyId)) throw new ArgumentNullException("webPropertyId required.");
            return type.IsGaTrackerType() ? new GaTracker(type, webPropertyId) : null;
        }
    }
}
