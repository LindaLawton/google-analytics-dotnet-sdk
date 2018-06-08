namespace Google.Analytics.SDK.Core.Helper
{
    public static class GoogleAnalyticsEndpoints
    {
        public const string Host = "https://www.google-analytics.com";
        public static readonly string Collect = "/collect";
        public static readonly string Debug = "/debug/collect";
        public static readonly string Batch = "/batch";
    }
}