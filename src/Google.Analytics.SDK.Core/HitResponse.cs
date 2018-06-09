// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace Google.Analytics.SDK.Core
{
    public class HitResponse : IResponse
    {
        public static HitResponse NoResult()
        {
            return null;
        }


        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public bool IsError()
        {
            throw new NotImplementedException();
        }
    }
}