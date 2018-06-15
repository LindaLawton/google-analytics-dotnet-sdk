﻿// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class ExceptionHitBase : HitBase
    {
        protected ExceptionHitBase()
        {
            HitType = HitTypes.Exception;
        }
        protected override bool InternalValidate()
        {
            return false;
        }
    }
}