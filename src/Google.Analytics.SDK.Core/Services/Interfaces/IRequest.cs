using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Services.Interfaces
{
    public interface IRequest
    {
        string Parms { get; }

        Hit RequestHit { get; }

        Task<string> ExecuteAsync(string type);

    }
}