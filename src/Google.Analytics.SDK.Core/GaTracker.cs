// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Services.Interfaces;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Google.Analytics.SDK.Core
{
    public class GaTracker : ITracker
    {
        public string Type { get;  }
        public ILogger Logger { get; } = new NoLogging();
        public string TrackingId { get; }
        public string ClientId { get; }
        public string ApplicationName { get; private set; }
        public string ApplicationId { get; private set; }
        public string ApplicationVersion { get; private set; }

        public void ConfigurationMobileApplication(string applicationName = null, string applicationVersion = null, string applicationId = null)
        {
            ApplicationName = string.IsNullOrWhiteSpace(applicationName)? AppDomain.CurrentDomain.FriendlyName : applicationName;
            ApplicationVersion = string.IsNullOrWhiteSpace(applicationVersion) ? Assembly.GetExecutingAssembly().GetName().Version.ToString() : applicationVersion;
            ApplicationId = string.IsNullOrWhiteSpace(applicationId) ? "1": applicationId;
        }

        public GaTracker(string type, string trackingId, ILogger logger = null)
        {
            Type = type;
            TrackingId = trackingId;
            ClientId = Guid.NewGuid().ToString();
            ConfigurationMobileApplication();
            Logger = logger ?? new NoLogging();
        }
        public Task IsValid()
        {
            throw new NotImplementedException();
        }
    }
}