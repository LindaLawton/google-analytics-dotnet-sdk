using System;
using System.Linq;
using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Extensions;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Google.Analytics.SDK.Core.Services.Interfaces;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class CustomMetricTests
    {
        private const string DocumentLocationUrl = "https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C";
        private const int CustomPropertyNumber = 1;
        private const int CustomPropertyNumberInvalid = -1;
        private const long CustomPropertyValue = 123456;
        private const string WebPropertyId = "UA-1111-1";
        private const string GACustomPropertyName = "cm";

        public HitBase MockHit()
        {
            return new PageViewHit(DocumentLocationUrl);
        }

        public GaTracker MockTracker()
        {
            return TrackerBuilder.BuildWebTracker(WebPropertyId);
        }

        public string MockCustomProperty()
        {
            return $"{GACustomPropertyName}{CustomPropertyNumber}={CustomPropertyValue}";
        }

        [Fact]
        public void CreateHitRequest_with_CustomProperty()
        {
            var tracker = MockTracker();
            var hit = MockHit();
            hit.AddCustomMetric(CustomPropertyNumber, CustomPropertyValue);
            var request = (HitRequestBase)tracker.CreateHitRequest(hit);
            Assert.Contains(MockCustomProperty(), request.QueryString, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Hit_Add_CustomProperty_Test_Property_String_Build()
        {
            var hit = MockHit();
            hit.AddCustomMetric(CustomPropertyNumber, CustomPropertyValue);
            Assert.Equal(hit.CustomMetric?.FirstOrDefault(d => CustomPropertyNumber.Equals(d.Number) && CustomPropertyValue.Equals(d.Value))?.Number, CustomPropertyNumber);
        }

        [Fact]
        public void Hit_Add_CustomProperty_Duplicate_Number_Fail()
        {
            var hit = MockHit();
            hit.AddCustomMetric(CustomPropertyNumber, CustomPropertyValue);
            Assert.Throws<ArgumentOutOfRangeException>(() => hit.AddCustomMetric(CustomPropertyNumber, CustomPropertyValue));
        }

        [Fact]
        public void Hit_Add_CustomProperty_NegitveNumber_Fail()
        {
            var hit = MockHit();
            Assert.Throws<ArgumentOutOfRangeException>(() => hit.AddCustomMetric(CustomPropertyNumberInvalid, CustomPropertyValue));
        }
    }
}