using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Google.Analytics.SDK.Core.Ga4.Request
{
    public class Ga4Event
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        
        [JsonPropertyName("params")]
        public Dictionary<string, string> Params { get; set; }
    }
}