// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

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