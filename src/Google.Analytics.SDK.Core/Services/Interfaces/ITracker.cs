using System.Threading.Tasks;

namespace Google.Analytics.SDK.Core.Services.Interfaces
{
    public interface ITracker
    {
        string TrackingId { get; }
        string ClientId { get; }

        string ApplicationName { get; }
        string ApplicationId { get; }
        string ApplicationVersion { get;}


        IRequest CreateHitRequest(Hit hit);
        
        Task IsValid();
    }

    public class ErrorResult : IResult
    {
        public ErrorResult(string result)
        {
            RawResponse = result;
        }

        public string RawResponse { get; }
    }


    public abstract class MustInitialize<T>
    {
        public MustInitialize(T parameters)
        {

        }
    }
}
