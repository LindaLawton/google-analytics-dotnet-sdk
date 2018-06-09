// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Helper;
using System;

namespace Google.Analytics.SDK.Core.Extensions
{
    public static class GaTrackerTypeExtension
    {
        public static string HitType(this string type)
        {
            if (!type.IsGaTrackerType()) return null;

            return type.Equals(GaTrackerType.Mobile, StringComparison.OrdinalIgnoreCase)  ? HitTypes.Screenview : HitTypes.Pageview;
        }

        public static bool IsGaTrackerType(this string type)
        {
            return type.Equals(GaTrackerType.Mobile, StringComparison.OrdinalIgnoreCase) ||
                   type.Equals(GaTrackerType.Web, StringComparison.OrdinalIgnoreCase);
        }

    }
}
