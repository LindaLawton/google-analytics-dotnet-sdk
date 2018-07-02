using System;

namespace Google.Analytics.SDK.Core.Hits.CustomProperties
{
    public class CustomDimenison : CustomParmBase
    {
        public CustomDimenison(int number, string value) : base(number)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentOutOfRangeException(nameof(value), "Value must be set.");
            Value = value;
        }

        public string Value { get; set; }
    }
}