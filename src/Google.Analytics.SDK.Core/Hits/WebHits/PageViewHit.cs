// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Services.Interfaces;

namespace Google.Analytics.SDK.Core.Hits.WebHits
{
    public class PageViewHit : Hit
    {
        public PageViewHit(ITracker tracker) : base(tracker)
        {
            HitType = HitTypes.Pageview;
            DocumentLocationURL = "(not set)";
        }

        public PageViewHit(ITracker tracker, string documentLocationUrl) : this(tracker)
        {
            DocumentLocationURL = documentLocationUrl;
        }

        public PageViewHit(ITracker tracker, string documentLocationUrl, string documentHostName) : this(tracker, documentLocationUrl)
        {
            DocumentHostName = documentHostName;
        }

        public PageViewHit(ITracker tracker, string documentLocationUrl, string documentHostName, string documentPath) : this(tracker, documentLocationUrl, documentHostName)
        {
            DocumentPath = documentPath;
        }

        public PageViewHit(ITracker tracker, string documentLocationUrl, string documentHostName, string documentPath, string documentTitle) : this(tracker, documentLocationUrl, documentHostName ,documentPath)
        {
            DocumentTitle = documentTitle;
        }

    }
}