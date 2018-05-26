namespace Google.Analytics.SDK.Core
{
    public interface IResponse
    {
        bool IsValid();
        bool IsError();
    }
}