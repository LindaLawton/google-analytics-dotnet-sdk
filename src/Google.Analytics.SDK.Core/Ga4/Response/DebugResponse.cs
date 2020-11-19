using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Google.Analytics.SDK.Core.Ga4.Response
{
    public class DebugResponse
    {
        public List<Message> validationMessages { get; set; }

        public class Message
        {
            [JsonPropertyName("fieldPath")]
            public string FieldPath { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("validationCode")]
            public string ValidationCode { get; set; }
        }
    }
}