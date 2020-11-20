// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Hits;
using Microsoft.Extensions.Logging;

namespace Google.Analytics.SDK.Core.Services.Interfaces
{
    

    public interface ITracker
    {
        ILogger Logger { get; }
        string TrackingId { get; }
        string ClientId { get; }
    }

    public abstract class MustInitialize<T>
    {
        public MustInitialize(T parameters)
        {

        }
    }
}
