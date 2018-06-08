using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Services
{
    public static class HttpClientFactory 
    {
        public static HttpClient CreateClient()
        {
            var client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30),
                BaseAddress = new Uri(GoogleAnalyticsEndpoints.Host)
            };
            return client;
        }
    }


}
