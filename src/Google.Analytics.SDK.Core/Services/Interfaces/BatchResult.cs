namespace Google.Analytics.SDK.Core.Services.Interfaces
{
    public class BatchResult : IResult
    {
        public BatchResult(string result)
        {
            RawResponse = result;
        }

        public string RawResponse { get; }
    }
}