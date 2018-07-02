namespace Google.Analytics.SDK.Core.Hits.CustomProperties
{
    public class CustomMetric : CustomParmBase
    {
        public long Value { get; set; }
        public CustomMetric(int number, long value) : base(number)
        {
            Value = value;
        }
    }
}