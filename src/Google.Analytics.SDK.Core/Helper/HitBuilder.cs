// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Linq;

namespace Google.Analytics.SDK.Core.Helper
{
    public static class HitBuilder
    {
        public static string BuildPropertyString(this IHit hit, string properyName)
        {
            var pInfo = typeof(Hit).GetProperty(properyName)?.GetCustomAttributes(typeof(HitAttribute), false).Cast<HitAttribute>().FirstOrDefault();
            
            var value = hit.GetType().GetProperty(properyName)?.GetValue(hit, null);

            return $"{pInfo.Parm}={value}";  
        }
    }
}
