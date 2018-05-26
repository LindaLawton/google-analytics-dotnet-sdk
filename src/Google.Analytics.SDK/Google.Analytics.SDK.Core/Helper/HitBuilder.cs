using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google.Analytics.SDK.Core.Helper
{
    public static class HitBuilder
    {

        public static string BuildPropertyString(this Hit hit, string properyName)
        {
            var pInfo = typeof(Hit).GetProperty(properyName)?.GetCustomAttributes(typeof(HitAttribute), false).Cast<HitAttribute>().FirstOrDefault();

            var value = hit.GetType().GetProperty(properyName).GetValue(hit, null);

            return $"{pInfo.Parm}={hit.ProtocolVersion}";   // TODO find a way of linking propery with the value.
        }
    }
}
