// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Google.Analytics.SDK.Core.Helper
{
    public static class GoogleAnalyticsEndpoints
    {
        public const string Host = "https://www.google-analytics.com";
        public static readonly string Collect = "/collect";
        public static readonly string Debug = "/debug/collect";
        public static readonly string Batch = "/batch";
    }
}