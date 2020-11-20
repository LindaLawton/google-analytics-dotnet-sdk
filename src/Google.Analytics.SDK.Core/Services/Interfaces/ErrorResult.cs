namespace Google.Analytics.SDK.Core.Services.Interfaces
{
    public class ErrorResult : IResult
    {
        public ErrorResult(string result)
        {
            RawResponse = result;
        }

        public string RawResponse { get; }
    }
}