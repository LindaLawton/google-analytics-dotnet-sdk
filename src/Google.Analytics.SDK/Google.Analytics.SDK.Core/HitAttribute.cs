using System;

namespace Google.Analytics.SDK.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HitAttribute : Attribute
    {
        public string Parm { get; set; }
        public bool Required { get; set; }
    }
}