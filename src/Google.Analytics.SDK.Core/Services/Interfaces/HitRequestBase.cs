// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Hits;
using Microsoft.Extensions.Logging;

namespace Google.Analytics.SDK.Core.Services.Interfaces
{
    public class HitRequestBase : MustInitialize<HitBase>, IRequest
    {
        public HttpClient Client { get; }
        public ILogger Logger { get; set; } = new NoLogging();
        public Dictionary<string, string> Parms { get; }
        public HitBase RequestHit { get; }
        public string RequestType { get; private set; }

        public string QueryString => BuildQueryString();

        private string BuildQueryString()
        {
            return Parms.Count == 0 ? string.Empty : string.Join("&", Parms.Select(p => $"{p.Key}={p.Value}"));
        }

        public HitRequestBase(HitBase requestHit) : base(requestHit)
    {
        RequestHit = requestHit;
        Client = HttpClientFactory.CreateClient();
        RequestType = HttpClientRequestType.Get;
        Parms = requestHit.GetRequestParamaters();

    }

    public async Task<IResult> ExecuteCollectAsync()
    {
        RequestType = HttpClientRequestType.Post;
        var results = await ExecuteAsync(GoogleAnalyticsEndpoints.Collect);

        return new CollectResult(results);
    }

    public async Task<IResult> ExecuteDebugAsync()
    {
        RequestType = HttpClientRequestType.Get;
        var results = await ExecuteAsync(GoogleAnalyticsEndpoints.Debug);

        return new DebugResult(results);
    }

    private async Task<string> ExecuteAsync(string type)
    {
        try
        {
            if (!HttpClientRequestType.Post.Equals(RequestType))
                return await Client.GetStringAsync(type + "?" + QueryString);

            var stringContent = new StringContent(QueryString);
            var response = await Client.PostAsync(type, stringContent);
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception e)
        {
            Logger.LogError($"Execute Failed {e.Message}", e.Message, e);
            throw;
        }
    }

    public void EnableLogging(ILogger logger)
    {
        Logger = logger;
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