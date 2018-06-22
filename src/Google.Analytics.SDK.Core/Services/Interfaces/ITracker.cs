// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Google.Analytics.SDK.Core.Services.Interfaces
{


    public interface ITracker
    {
        ILogger Logger { get; set; }
        string TrackingId { get; }
        string ClientId { get; }

        string ApplicationName { get; }
        string ApplicationId { get; }
        string ApplicationVersion { get;}
        
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
