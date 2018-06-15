using Google.Analytics.SDK.Core.Hits.WebHits;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class PageTests
    {
        [Fact]
        public void Create_PageViewHit_All_Validate_Success()
        {
            var hit = new PageViewHit("https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C", "https://plus.google.com", "/u/0/+LindaLawton/posts/7oxAdszKB9C", "Welcome to my Developing with Google Collection");

            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_PageViewHit_NoTitle_Validate_Success()
        {
            var hit = new PageViewHit("https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C", "https://plus.google.com", "/u/0/+LindaLawton/posts/7oxAdszKB9C");

            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_PageViewHit_NoDocumentPath_Validate_Success()
        {
            var hit = new PageViewHit("https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C", "https://plus.google.com");

            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_PageViewHit_No_DocumentHostName_Validate_Success()
        {
            var hit = new PageViewHit("https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C");

            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_PageViewHit_No_DocumentURL_Validate_Success()
        {
            var hit = new PageViewHit();

            Assert.True(hit.Validate());
        }


        [Fact]
        public void Create_PageviewHit_Validate_Fail()
        {
            var hit = new PageViewHit();
            hit.DocumentLocationURL = null;
            Assert.False(hit.Validate());
        }

    }
}