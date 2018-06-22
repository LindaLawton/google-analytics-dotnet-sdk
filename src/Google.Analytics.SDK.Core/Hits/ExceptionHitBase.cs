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


        protected override ValidateResponse InternalValidate()
        {
            LastValidateResponse = (string.IsNullOrWhiteSpace(ExceptionIsFatal) || ExceptionIsFatal == "1" ||
                                    ExceptionIsFatal == "0")
                ? ValidateResponse.Builder(true, string.Empty)
                : ValidateResponse.Builder(false, $"ExceptionIsFatal must be 1 or 0. ExceptionIsFatal={ExceptionIsFatal}");
            return LastValidateResponse;
        }
    }
}