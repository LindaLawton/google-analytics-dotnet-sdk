namespace Google.Analytics.SDK.Core.Services.Interfaces
{
    public class CollectResult : IResult
    {
        public CollectResult(string result)
        {
            RawResponse = result;
        }

        public string RawResponse { get; }
    }
}