using System;
using System.Collections.Generic;
using System.Text;
using Google.Analytics.SDK.Core.Helper;

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
