// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Extensions;
using Google.Analytics.SDK.Core.Helper;
using Microsoft.Extensions.Logging;
using System;
using System.Text.RegularExpressions;

namespace Google.Analytics.SDK.Core
{
    /// <summary>
    /// Used for building Google analytics trackers.
    /// </summary>
    public class GaTrackerBuilder
    {
        /// <summary>
        /// Builds a mobile Google Analytics tracker. Used for tracking screenviews, and other mobile tracking hit types
        /// </summary>
        /// <param name="webPropertyId">The tracking ID / web property ID. The format is UA-XXXX-Y. All collected data is associated by this ID.</param>
        /// <param name="applicationName">Specifies the application name. This field is required for any hit that has app related data (i.e., app version, app ID, or app installer ID).</param>
        /// <param name="applicationVersion">Specifies the application version.</param>
        /// <param name="applicationId">Application identifier.</param>
        /// <returns></returns>
        public static GaTracker BuildMobileTracker(string webPropertyId, string applicationName = "", string applicationVersion = "", string applicationId = "")
        {
            if (string.IsNullOrWhiteSpace(webPropertyId)) throw new ArgumentNullException(nameof(webPropertyId));
            var tracker = BuildTracker(GaTrackerType.Mobile, webPropertyId);
            tracker.ConfigurApplication(applicationName, applicationVersion, applicationId);
            return tracker;
        }

        
        /// <summary>
        /// Builds a mobile Google Analytics tracker. Used for tracking screenviews, and other mobile tracking hit types
        /// </summary>
        /// <param name="webPropertyId">The tracking ID / web property ID. The format is UA-XXXX-Y. All collected data is associated by this ID.</param>
        /// <param name="logger">Enables logging.</param>
        /// <param name="applicationName">Specifies the application name. This field is required for any hit that has app related data (i.e., app version, app ID, or app installer ID).</param>
        /// <param name="applicationVersion">Specifies the application version.</param>
        /// <param name="applicationId">Application identifier.</param>
        /// <returns></returns>
        public static GaTracker BuildMobileTracker(string webPropertyId, ILogger logger, string applicationName = "", string applicationVersion = "", string applicationId = "")
        {
            if (string.IsNullOrWhiteSpace(webPropertyId)) throw new ArgumentNullException(nameof(webPropertyId));
            var tracker = BuildTracker(GaTrackerType.Mobile, webPropertyId);
            tracker.ConfigurApplication(applicationName, applicationVersion, applicationId);
            return tracker;
        }

        /// <summary>
        /// Builds a web Google Analytics tracker.  Used for tracking pageviews, and other web tracking hit types.
        /// </summary>
        /// <param name="webPropertyId">The tracking ID / web property ID. The format is UA-XXXX-Y. All collected data is associated by this ID.</param>
        /// <param name="logger">Enables logging.</param>
        /// <returns></returns>
        public static GaTracker BuildWebTracker(string webPropertyId, ILogger logger = null)
        {
            var regex = new Regex("^UA-[0-9]*-[0-9]", RegexOptions.IgnoreCase);
            if (!regex.Match(webPropertyId).Success) throw new ArgumentException("Invalid Webpropry format.");

            if(string.IsNullOrWhiteSpace(webPropertyId))
            {
                logger.LogError("webPropertyId not set.");
                throw new ArgumentNullException(nameof(webPropertyId));
            }
            var tracker =  BuildTracker(GaTrackerType.Web, webPropertyId, logger);
            return tracker;
        }

        private static GaTracker BuildTracker(string type, string webPropertyId, ILogger logger = null)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                logger.LogError("Type not set.");
                throw new ArgumentNullException(nameof(type));
            }
            if (string.IsNullOrWhiteSpace(webPropertyId))
            {
                logger.LogError("webPropertyId not set.");
                throw new ArgumentNullException(nameof(webPropertyId));
            }
            if (!type.IsGaTrackerType()) return null;
            
            var tracker = new GaTracker(type, webPropertyId);
            tracker = (GaTracker)tracker.ConfigurLogging(logger);  
            tracker.Logger.LogInformation("Tracker Created Type:{type}",tracker.Type);
            return tracker;
        }
    }
}
