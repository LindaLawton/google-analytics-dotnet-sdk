using System;
using Google.Analytics.SDK.Core.Extensions;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core
{
    public class Tracker
    {
        public static GaTracker BuildMobileTracker(string webPropertyId)
        {
            if(string.IsNullOrWhiteSpace(webPropertyId)) throw new ArgumentNullException("webPropertyId required.");
            return BuildTracker(GaTrackerType.Mobile, webPropertyId);
        }

        public static GaTracker BuildWebTracker(string webPropertyId)
        {
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
