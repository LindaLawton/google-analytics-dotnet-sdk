// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Google.Analytics.SDK.Core
{
    public static class TrackerExtensions{

        public static IRequest CreateHitRequest(this ITracker tracker, HitBase hit)
        {
            hit.ClientId = tracker.ClientId;
            hit.WebPropertyId = tracker.TrackingId;
            hit.ApplicationId = tracker.ApplicationId;
            hit.ApplicationName = tracker.ApplicationName;
            hit.ApplicationVersion = tracker.ApplicationVersion;
            var request = new Hitrequest(hit, tracker.Logger);
            tracker.Logger.LogInformation("Hit created for HitType={HitType}", hit.HitType);
            tracker.Logger.LogTrace("Parms {parms}", request.Parms);
            return request;
        }

        public static ITracker ConfigurLogging(this ITracker tracker, ILogger logger)
        {
            if (logger == null) return tracker;

            tracker.Logger = logger;
            tracker.Logger.LogInformation("Logger configured.");
            return tracker;
        }
    }
}