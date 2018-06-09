// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Services.Interfaces;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Hits;

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

        
        

        public Task IsValid()
        {
            throw new NotImplementedException();
        }
    }

    public static class TrackerExtensions{

        public static IRequest CreateHitRequest(this ITracker tracker, Hit hit)
        {
            hit.CientId = tracker.ClientId;
            hit.WebPropertyId = tracker.TrackingId;
            hit.ApplicationId = tracker.ApplicationId;
            hit.ApplicationName = tracker.ApplicationName;
            hit.ApplicationVersion = tracker.ApplicationVersion;
            var request = new Hitrequest(hit);
            

            return request;
        }
    }

}