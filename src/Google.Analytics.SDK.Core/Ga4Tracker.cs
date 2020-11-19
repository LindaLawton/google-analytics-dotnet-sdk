using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Ga4;
using Google.Analytics.SDK.Core.Ga4.Request;
using Google.Analytics.SDK.Core.Ga4.Response;
using Microsoft.Extensions.Logging;

namespace Google.Analytics.SDK.Core
{
    public class GA4Tracker
    {
        private readonly HttpClient _client;
        private readonly Ga4Settings _ga4Settings;
        private readonly ILogger<GA4Tracker> _logger;
        private readonly string _userId;

        public GA4Tracker(HttpClient client, Ga4Settings ga4Settings, ILogger<GA4Tracker> logger, string userId = null)
        {
            _client = client;
            _ga4Settings = ga4Settings;
            _logger = logger;
            _userId = userId;
        }

        public async Task SendAsync(List<Ga4Event> events, bool debug = false)
        {
            var ga4Request = new Ga4Request()
            {
                ClientId = _ga4Settings.ClientId,
                UserId = _userId
            };
            foreach (var ga4Event in events)
            {
                ga4Request.AddEvent(ga4Event);
            }

            var options = new JsonSerializerOptions {IgnoreNullValues = true};

            var jsonRequest = JsonSerializer.Serialize(ga4Request, options).CleanItemsJson();

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var responseMessage = await _client.PostAsync(GetUri(debug), content, CancellationToken.None);

            if (debug)
            {
                responseMessage.EnsureSuccessStatusCode();
                var responseBody = await responseMessage.Content.ReadAsStringAsync();
                var debugResponse = JsonSerializer.Deserialize<DebugResponse>(responseBody);
                foreach (var debugResponseValidationMessage in debugResponse.validationMessages)
                {
                    _logger.LogDebug(debugResponseValidationMessage.Description);
                }
            }
        }

        private Uri GetUri(bool debug)
        {
            var baseUrl = "https://www.google-analytics.com/mp/collect";
            if (debug)
            {
                _logger.LogDebug("Debug is set, sending hit for validation only.");
                baseUrl = "https://www.google-analytics.com/debug/mp/collect";
            }

            if (string.IsNullOrWhiteSpace(_ga4Settings.ApiSecret))
            {
                throw new ArgumentNullException(nameof(Ga4Settings.ApiSecret));
            }

            if (string.IsNullOrWhiteSpace(_ga4Settings.MeasurmentId))
            {
                throw new ArgumentNullException(nameof(Ga4Settings.MeasurmentId));
            }

            if (!string.IsNullOrWhiteSpace(_ga4Settings.FirebaseAppId))
            {
                baseUrl = $"{baseUrl}?firebase_app_id={_ga4Settings.FirebaseAppId}";
            }

            return new Uri($"{baseUrl}?measurement_id={_ga4Settings.MeasurmentId}&api_secret={_ga4Settings.ApiSecret}");
        }
    }
}