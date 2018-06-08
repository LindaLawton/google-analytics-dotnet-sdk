using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core
{
    public class PageViewHit : Hit
    {
        public PageViewHit() : base()
        {
            HitType = HitTypes.Pageview;
            
            DocumentLocationURL = "(not set)";
        }

        public PageViewHit(string documentLocationUrl) : this()
        {
            DocumentLocationURL = documentLocationUrl;
        }

        public PageViewHit(string documentLocationUrl, string documentHostName) : this(documentLocationUrl)
        {
            DocumentHostName = documentHostName;
        }

        public PageViewHit(string documentLocationUrl, string documentHostName, string documentPath) : this(documentLocationUrl, documentHostName)
        {
            DocumentPath = documentPath;
        }

        public PageViewHit(string documentLocationUrl, string documentHostName, string documentPath, string documentTitle) : this(documentLocationUrl, documentHostName ,documentPath)
        {
            DocumentTitle = documentTitle;
        }

    }
}