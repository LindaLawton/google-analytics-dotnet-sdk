// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Extensions;
using Google.Analytics.SDK.Core.Helper;
using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace Google.Analytics.SDK.Core
{
    public class TrackerBuilder
    {
        public static GaTracker BuildMobileTracker(string webPropertyId, string applicationName = "", string applicationVersion = "", string applicationId = "")
        {
            if (string.IsNullOrWhiteSpace(webPropertyId)) throw new ArgumentNullException(nameof(webPropertyId));
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
