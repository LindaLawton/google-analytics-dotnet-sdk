// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Google.Analytics.SDK.Core.Hits;

namespace Google.Analytics.SDK.Core.Helper
{
    public static class HitBuilder
    {
        public static string BuildPropertyString(this HitBase hit, string properyName)
        {
            try
            {
                var pInfo = typeof(HitBase).GetProperty(properyName)?.GetCustomAttributes(typeof(HitAttribute), false).Cast<HitAttribute>().FirstOrDefault();

                if (pInfo == null) return string.Empty;  // Ignore properties without custom attributes.

                var value = hit.GetType().GetProperty(properyName)?.GetValue(hit, null);

                return $"{pInfo.Parm}={value}";
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to build property string {e}");
                throw;
            }
        }

        public static KeyValuePair<string,string> GetPropertyString(this HitBase hit, string properyName)
        {
            try
            {
                var pInfo = typeof(HitBase).GetProperty(properyName)?.GetCustomAttributes(typeof(HitAttribute), false).Cast<HitAttribute>().FirstOrDefault();

                if (pInfo == null) return new KeyValuePair<string, string>(); // Ignore properties without custom attributes.

                var value = hit.GetType().GetProperty(properyName)?.GetValue(hit, null);

                return new KeyValuePair<string, string>(pInfo.Parm, value?.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to build property string {e}");
                throw;
            }
        }


    }
}
