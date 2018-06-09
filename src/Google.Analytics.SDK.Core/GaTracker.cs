// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Services.Interfaces;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Hits;
using Microsoft.Extensions.Logging;

namespace Google.Analytics.SDK.Core
{
    public class NoLogging : ILogger {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
          
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }

   

    public class GaTracker : ITracker
    {
        
        public string Type { get; private set; }
        public ILogger Logger { get; } = new NoLogging();
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

        public GaTracker(string type, string trackingId, ILogger logger = null)
        {
            Type = type;
            TrackingId = trackingId;
            ClientId = Guid.NewGuid().ToString();
            ConfigurApplication();
            Logger = logger ?? new NoLogging();
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