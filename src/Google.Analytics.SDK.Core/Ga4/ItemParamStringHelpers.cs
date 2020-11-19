using System.Collections.Generic;
using System.Linq;

namespace Google.Analytics.SDK.Core.Ga4
{
    public static class ItemParamStringHelpers
    {
        public static string ToJsonString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return "[ {" + string.Join(",", dictionary.Select(kv => $"\"{kv.Key}\" : \"{kv.Value}\"").ToArray()) + "} ]";
        }

        public static string CleanItemsJson(this string data)
        {
            return data.Replace("\\u0022", "\"").Replace("\"[", "[").Replace("]\"", "]");
        }
    }
}