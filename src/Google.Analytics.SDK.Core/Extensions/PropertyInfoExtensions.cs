using Google.Analytics.SDK.Core.Hits.CustomProperties;
using System.Collections.Generic;
using System.Reflection;

namespace Google.Analytics.SDK.Core.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static bool IsParseableDatatype(this PropertyInfo property)
        {
            return property.PropertyType == typeof(IList<CustomDimenison>) ||
                   property.PropertyType == typeof(IList<CustomMetric>) ||
                   property.PropertyType == typeof(IList<ContentGroup>) ||
                   property.PropertyType == typeof(string) ||
                   property.PropertyType == typeof(int) ||
                   property.PropertyType == typeof(long) ||
                   property.PropertyType == typeof(bool);
        }
    }
}