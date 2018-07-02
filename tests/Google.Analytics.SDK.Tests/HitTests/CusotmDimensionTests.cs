using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Google.Analytics.SDK.Core.Services.Interfaces;
using System;
using System.Linq;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class CusotmDimensionTests
    {
        private const string DocumentLocationUrl = "https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C";
        private const int CustomPropertyNumber = 1;
        private const int CustomPropertyNumberInvalid = 400;
        private const string CustomPropertyValue = "hello";
        private const string CustomPropertyNullValue = null;
        private const string WebPropertyId = "UA-1111-1";
        private const string GACustomPropertyName = "cd";

        public HitBase MockHit()
        {
            return new PageViewHit(DocumentLocationUrl);
        }

        public GaTracker MockTracker()
        {
            return  TrackerBuilder.BuildWebTracker(WebPropertyId);
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
            hit.AddCustomDimension(CustomPropertyNumber, CustomPropertyValue);
            var request = (HitRequestBase)tracker.CreateHitRequest(hit);
            Assert.Contains(MockCustomProperty(), request.Parms, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Hit_Add_CustomProperty_Test_Property_String_Build()
        {
            var hit = MockHit();
            hit.AddCustomDimension(CustomPropertyNumber, CustomPropertyValue);
            Assert.Equal(hit.CustomDimension?.FirstOrDefault(d => CustomPropertyNumber.Equals(d.Number) && CustomPropertyValue.Equals(d.Value))?.Number,CustomPropertyNumber);
        }

        [Fact]
        public void Hit_Add_CustomProperty_Duplicate_Number_Fail()
        {
            var hit = MockHit();
            hit.AddCustomDimension(CustomPropertyNumber, CustomPropertyValue);
            Assert.Throws<ArgumentOutOfRangeException>(() => hit.AddCustomDimension(CustomPropertyNumber, CustomPropertyValue));
        }

        [Fact]
        public void Hit_Add_CustomProperty_NullValue_Fail()
        {
            var hit = MockHit();
            Assert.Throws<ArgumentOutOfRangeException>(() => hit.AddCustomDimension(CustomPropertyNumber, CustomPropertyNullValue));
        }

        [Fact]
        public void Hit_Add_CustomProperty_ToBigNumber_Fail()
        {
            var hit = MockHit();
            Assert.Throws<ArgumentOutOfRangeException>(() => hit.AddCustomDimension(CustomPropertyNumberInvalid, CustomPropertyValue));
        }
    }
}