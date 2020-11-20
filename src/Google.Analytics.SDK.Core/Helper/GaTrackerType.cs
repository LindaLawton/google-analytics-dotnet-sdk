// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace Google.Analytics.SDK.Core.Helper
{
    public class GaTrackerType
    {
        [Obsolete("This property is obsolete. Call web instead.", false)]
        public const string Mobile = "Mobile";
        public const string Web = "Web";
    }
}