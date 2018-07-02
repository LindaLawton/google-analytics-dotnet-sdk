using System;

namespace Google.Analytics.SDK.Core.Hits.CustomProperties
{
    public class CustomParmBase
    {
        public int Number { get; set; }
        public CustomParmBase(int number)
        {
            if (number < 1 || number > 200) throw  new ArgumentOutOfRangeException(nameof(number), "Number must be between 1 - 200");
            Number = number;
        }
    }
}