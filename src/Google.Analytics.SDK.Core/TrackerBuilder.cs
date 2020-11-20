// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Extensions;
using Google.Analytics.SDK.Core.Helper;
using System;
using System.Text.RegularExpressions;

namespace Google.Analytics.SDK.Core
{
    public class TrackerBuilder
    {
        
        /// <summary>
        /// Obsolete: tracker for Google analytics mobile accounts.   Will be removed in Next version as Google no longer supports mobile accounts
        /// </summary>
        /// <param name="webPropertyId"></param>
        /// <param name="applicationName"></param>
        /// <param name="applicationVersion"></param>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [ObsoleteAttribute("This method is obsolete. Call BuildWebTracker instead.", false)]
        public static GaTracker BuildMobileTracker(string webPropertyId, string applicationName = "", string applicationVersion = "", string applicationId = "")
        {
            if (string.IsNullOrWhiteSpace(webPropertyId)) throw new ArgumentNullException(nameof(webPropertyId));
            var tracker = BuildTracker(GaTrackerType.Mobile, webPropertyId);
            tracker.ConfigurationMobileApplication(applicationName, applicationVersion, applicationId);
            return tracker;
        }

        /// <summary>
        /// Tracker for Google Analytics web based accounts.
        /// </summary>
        /// <param name="webPropertyId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static GaTracker BuildWebTracker(string webPropertyId)
        {
            if (string.IsNullOrWhiteSpace(webPropertyId))
            {
                throw new ArgumentNullException(nameof(webPropertyId));
            }
            
            if(!IsWebPropertyValid(webPropertyId))
            {
                throw new ArgumentOutOfRangeException($"Invalid format for {nameof(webPropertyId)}");
            }

            return BuildTracker(GaTrackerType.Web, webPropertyId);
        }

        #region Private helper methods

        private static bool IsWebPropertyValid(string webPropertyId)
        {
            var regex = new Regex("^UA-[0-9]*-[0-9]", RegexOptions.IgnoreCase);
            return regex.Match(webPropertyId).Success;
        }

        private static GaTracker BuildTracker(string type, string webPropertyId, string applicationName = null, string applicationVersion = null, string applicationId = null)
        {
            if (string.IsNullOrWhiteSpace(type)) throw new ArgumentNullException(nameof(type));
            if (string.IsNullOrWhiteSpace(webPropertyId)) throw new ArgumentNullException(nameof(webPropertyId));
            return type.IsGaTrackerType() ? new GaTracker(type, webPropertyId) : null;
        }
        
        

        #endregion
    }
}
