using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Google.Analytics.SDK.Core.Ga4.Request
{
    public class Ga4Request
    {
        private static int _maxNumberOfEvents = 25;

        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }
        
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("nonPersonalizedAds")]
        public bool NonPersonalizedAds { get; set; }

        [JsonPropertyName("events")]
        public List<Ga4Event> Events { get; set; }

        public Ga4Request()
        {
            NonPersonalizedAds = false;
            _maxNumberOfEvents = 25;
            Events = new List<Ga4Event>();
        }

        public void AddEvent(Ga4Event ga4Event)
        {
            if (Events.Count >= _maxNumberOfEvents)
            {
                throw new IndexOutOfRangeException(
                    $"Failed request has the maximum num of ({_maxNumberOfEvents}) events.");
            }

            Events.Add(ga4Event);
        }
    }
}