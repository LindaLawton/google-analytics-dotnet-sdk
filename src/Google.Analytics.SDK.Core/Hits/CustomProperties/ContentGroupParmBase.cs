using System;

namespace Google.Analytics.SDK.Core.Hits.CustomProperties
{
    public class ContentGroupParmBase
    {
        public string Value { get; set; }
        public int Number { get; set; }
        public ContentGroupParmBase(int number)
        {
            if (number < 1 || number > 5) throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 1 - 5");
            Number = number;
        }
    }
}