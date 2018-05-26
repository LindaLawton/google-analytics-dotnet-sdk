using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Google.Analytics.SDK.Core.Services.Interfaces
{
    public interface ITracker
    {
        IRequest CreateHitRequest(Hit hit);

        IRequest CreateDebugRequest(Hit hit);

        Task IsValid();
    }

    public interface IRequest
    {
        string EndPoint { get; }

        string parms { get; }

        Hit RequestHit { get; }

        Task<IResult> ExecuteAsync();

    }

    public interface IResult
    {
    }

    public abstract class MustInitialize<T>
    {
        public MustInitialize(T parameters)
        {

        }
    }



    public class Hitrequest : MustInitialize<Hit>, IRequest
    {
        public string EndPoint { get; } = "https://www.google-analytics.com/collect";
        public string parms { get; }
        public Hit RequestHit { get; }
        public async Task<IResult> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Execute()
        {
            throw new NotImplementedException();
        }


       

        public Hitrequest(Hit requestHit) : base(requestHit)
        {
            RequestHit = requestHit;
        }
    }

    public class DebugRequest : MustInitialize<Hit>, IRequest
    {
        public string EndPoint { get; } = "https://www.google-analytics.com/debug/collect";
        public string parms { get; }
        public Hit RequestHit { get; }
        public async Task<IResult> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Hit Request { get;  }
       

        public DebugRequest(Hit requestHit) : base(requestHit)
        {
            RequestHit = requestHit;
        }
    }
}
