// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
namespace Google.Analytics.SDK.Core.Hits
{
    public class ExceptionHit : ExceptionHitBase
    {
        public ExceptionHit() : base()
        {

        }

        public ExceptionHit(string exceptionDescription) : base(exceptionDescription)
        {

        }

        public ExceptionHit(string exceptionDescription, bool exceptionIsFatal) : base(exceptionDescription, exceptionIsFatal)
        {

        }

    }
}