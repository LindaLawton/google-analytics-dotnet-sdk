// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Threading.Tasks;
using Google.Analytics.SDK.Core.Hits;

namespace Google.Analytics.SDK.Core.Services.Interfaces
{
    public interface IRequest
    {
        string Parms { get; }

        HitBase RequestHit { get; }

        Task<string> ExecuteAsync(string type);

    }
}