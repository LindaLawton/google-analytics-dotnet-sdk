// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Hits;
using Microsoft.Extensions.Logging;

namespace Google.Analytics.SDK.Core.Services.Interfaces
{
    public interface IRequest
    {
        ILogger Logger { get;  }
        Dictionary<string, string> Parms { get; }

        string QueryString { get; }
        HitBase RequestHit { get; }

        Task<string> ExecuteAsync(string type);

        void EnableLogging(ILogger logger);
        Task<IResult> ExecuteCollectAsync();
        Task<IResult> ExecuteDebugAsync();
        
    }
}