// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Helper;
using System;
using System.Net.Http;

namespace Google.Analytics.SDK.Core.Services
{
    public static class HttpClientFactory 
    {
        public static HttpClient CreateClient()
        {
            return new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30),
                BaseAddress = new Uri(GoogleAnalyticsEndpoints.Host)
            };
        }
    }


}
