// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace Google.Analytics.SDK.Core.Helper
{
    public static class GoogleAnalyticsRequestType
    {
        public static readonly string Collect = "collect";
        public static readonly string Debug = "debug";
        public static readonly string Batch = "batch";
    }

    public static class HttpClientRequestType
    {
        public static readonly string Post = "POST";
        public static readonly string Get = "GET";
    }
}