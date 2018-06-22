// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Helper;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Hits;
using Microsoft.Extensions.Logging;

namespace Google.Analytics.SDK.Core.Services.Interfaces
{
    public class Hitrequest : MustInitialize<HitBase>, IRequest
    {
        public HttpClient Client { get; }
        public string Parms { get; }
        public HitBase RequestHit { get; }
        public string RequestType { get; private set; }

        private ILogger _logger;

        public Hitrequest(HitBase requestHit, ILogger logger) : base(requestHit)
        {
            RequestHit = requestHit;
            Client = HttpClientFactory.CreateClient();
            RequestType = HttpClientRequestType.Get;
            Parms = requestHit.GetRequest();
            _logger = logger;
            _logger.LogInformation("Hit request created for hit type {type}", requestHit.HitType);
        }

        public async Task<IResult> ExecuteCollectAsync()
        {
            _logger.LogInformation("Sending collect for hit type {type}", RequestHit.HitType);
            RequestType = HttpClientRequestType.Post;
            var results = await ExecuteAsync(GoogleAnalyticsEndpoints.Collect);
        
            return new CollectResult(results);
        }

        public async Task<IResult> ExecuteDebugAsync()
        {
            _logger.LogInformation("Sending debug for hit type {type}", RequestHit.HitType);
            RequestType = HttpClientRequestType.Get;
            var results =  await ExecuteAsync(GoogleAnalyticsEndpoints.Debug);

            return new DebugResult(results);
        }

        private async Task<string> ExecuteAsync(string type)
        {
            if (HttpClientRequestType.Post.Equals(RequestType))
            {
                _logger.LogTrace("Collect Hit: ");
                var stringContent = new StringContent(Parms);
                _logger.LogTrace("Parms: {parms}", stringContent);
                var response =  await Client.PostAsync(type, stringContent);
                _logger.LogTrace("response {response}", response);
                var content = await response.Content.ReadAsStringAsync();
                _logger.LogTrace("content {content}", content);
                return content;
            }
            try
            {
                _logger.LogTrace("Debug Hit: ");
                var hold = GoogleAnalyticsEndpoints.Host + type + "?" + Parms;
                _logger.LogTrace("Get: {url} ", hold);
                return  await Client.GetStringAsync(type + "?" + Parms);
            }
            catch (Exception e)
            {
               _logger.LogError("Send failed {exception}",e);
                throw;
            }
        }

        async Task<string> IRequest.ExecuteAsync(string type)
        {
            var response = string.Empty;
            if (GoogleAnalyticsRequestType.Collect.Equals(type, StringComparison.OrdinalIgnoreCase))
                response = await Client.GetStringAsync(GoogleAnalyticsEndpoints.Collect);
            if (GoogleAnalyticsRequestType.Batch.Equals(type, StringComparison.OrdinalIgnoreCase))
                response = await Client.GetStringAsync(GoogleAnalyticsEndpoints.Batch);
            if (GoogleAnalyticsRequestType.Debug.Equals(type, StringComparison.OrdinalIgnoreCase))
                response = await Client.GetStringAsync(GoogleAnalyticsEndpoints.Debug);

            return response;
        }
      
    }
}