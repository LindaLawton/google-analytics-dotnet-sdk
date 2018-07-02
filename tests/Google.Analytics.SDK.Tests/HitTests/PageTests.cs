using System.Runtime.CompilerServices;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Xunit;

[assembly: InternalsVisibleTo("Google.Analytics.SDK.Tests")]
namespace Google.Analytics.SDK.Tests.HitTests
{


    public class PageTests
    {
        private const string DocumentLocationUrl = "https://plus.google.com/u/0/+LindaLawton/posts/7oxAdszKB9C";
        private const string DocumentHostName = "https://plus.google.com";
        private const string DocumentPath = "/u/0/+LindaLawton/posts/7oxAdszKB9C";
        private const string DocumentTitle = "Welcome to my Developing with Google Collection";
        private const string HitType = HitTypes.Pageview;

        [Fact]
        public void Create_PageViewHit_All_Validate_Success()
        {
            var hit = new PageViewHit(DocumentLocationUrl, DocumentHostName, DocumentPath, DocumentTitle);
            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_PageViewHit_All_Validate_Values()
        {
            var hit = new PageViewHit(DocumentLocationUrl, DocumentHostName, DocumentPath, DocumentTitle);
            Assert.Equal(DocumentLocationUrl, hit.DocumentLocationURL);
            Assert.Equal(DocumentHostName, hit.DocumentHostName);
            Assert.Equal(DocumentPath, hit.DocumentPath);
            Assert.Equal(DocumentTitle, hit.DocumentTitle);
            Assert.Equal(HitType, hit.HitType, true);
        }


        [Fact]
        public void Create_PageViewHit_NoTitle_Validate_Success()
        {
            var hit = new PageViewHit(DocumentLocationUrl, DocumentHostName, DocumentPath);

            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_PageViewHit_NoDocumentPath_Validate_Success()
        {
            var hit = new PageViewHit(DocumentLocationUrl, DocumentHostName);

            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_PageViewHit_No_DocumentHostName_Validate_Success()
        {
            var hit = new PageViewHit(DocumentLocationUrl);

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

        [Fact]
        public void Create_PageviewHit_HitType_NotNull()
        {
            var hit = new PageViewHit(DocumentLocationUrl);
            Assert.Equal(hit.HitType, HitTypes.Pageview, ignoreCase: true);
        }

    }
}