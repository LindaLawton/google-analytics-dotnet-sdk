namespace Google.Analytics.SDK.Core.Helper
{
    public static class GoogleAnalyticsRequestType
    {
        public static readonly string Collect = "collect";
        public static readonly string Debug = "debug";
        public static readonly string Batch = "batch";
    }

    public static class HttpClientRequestType
    {
        public static readonly string Post = "POST";
        public static readonly string Get = "GET";
    }
}