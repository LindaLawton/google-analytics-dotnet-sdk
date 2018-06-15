// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class ExceptionHitBase : HitBase
    {
        protected ExceptionHitBase()
        {
            HitType = HitTypes.Exception;
        }

        protected ExceptionHitBase(string exceptionDescription) : this()
        {
            ExceptionDescription = exceptionDescription;
        }

        protected ExceptionHitBase(string exceptionDescription, bool exceptionIsFatal) : this(exceptionDescription)
        {
            ExceptionIsFatal = exceptionIsFatal ? "1" : "0";
        }


        protected override bool InternalValidate()
        {
            if (string.IsNullOrWhiteSpace(ExceptionIsFatal) || ExceptionIsFatal == "1" ||
                ExceptionIsFatal == "0") return true;

            throw new ArgumentOutOfRangeException("ExceptionIsFatal", "must be empty, 1 or 0");
        }
    }
}