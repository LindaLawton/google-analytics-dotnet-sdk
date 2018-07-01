using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using System;
using System.Linq;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class CusotmPropertyTests
    {
        private const string DocumentLocationUrl = "https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C";
        private const string HitType = HitTypes.Pageview;
        private const int DimensionNumber = 1;
        private const string DimensionValue = "hello";

        private const int MetricNumber = 1;
        private const long MetricValue = 123;

        public HitBase MockHit()
        {
            return new PageViewHit(DocumentLocationUrl);
        }

        [Fact]
        public void Hit_Add_CustomDimension()
        {
            var hit = MockHit();
            hit.AddCustomDimension(DimensionNumber, DimensionValue);
            Assert.Equal(hit.CustomDimension?.FirstOrDefault(d => DimensionNumber.Equals(d.Number) && DimensionValue.Equals(d.Value))?.Number,DimensionNumber);
        }

        [Fact]
        public void Hit_Add_CustomDimension_duplicateFail()
        {
            var hit = MockHit();
            hit.AddCustomDimension(DimensionNumber, DimensionValue);
            Assert.Throws<ArgumentOutOfRangeException>(() => hit.AddCustomDimension(DimensionNumber, DimensionValue));
        }

        [Fact]
        public void Hit_Add_CustomMetric()
        {
            var hit = MockHit();
            hit.AddCustomMetric(MetricNumber, MetricValue);
            Assert.Equal(hit.CustomMetric?.FirstOrDefault(d => MetricNumber.Equals(d.Number) && MetricValue.Equals(d.Value))?.Number, MetricNumber);
        }

        [Fact]
        public void Hit_Add_CustomMetric_duplicateFail()
        {
            var hit = MockHit();
            ;
            hit.AddCustomMetric(MetricNumber, MetricValue);
            Assert.Throws<ArgumentOutOfRangeException>(() => hit.AddCustomMetric(MetricNumber, MetricValue));
        }

    }
}