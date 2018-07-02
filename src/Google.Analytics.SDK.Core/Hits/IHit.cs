// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.Extensions.Logging;

namespace Google.Analytics.SDK.Core.Hits
{
    public interface IHit
    {
        ILogger Logger { get; set; }
        bool Validate();
        void AddCustomDimension(int id, string value);
        void AddCustomMetric(int id, long value);

        void EnableLogging(ILogger logger);
    }
}