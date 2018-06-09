// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Services.Interfaces;

namespace Google.Analytics.SDK.Core.Hits.WebHits
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

        public PageViewHit(string documentLocationUrl, string documentHostName) : this( documentLocationUrl)
        {
            DocumentHostName = documentHostName;
        }

        public PageViewHit(string documentLocationUrl, string documentHostName, string documentPath) : this(documentLocationUrl, documentHostName)
        {
            DocumentPath = documentPath;
        }

        public PageViewHit(string documentLocationUrl, string documentHostName, string documentPath, string documentTitle) : this( documentLocationUrl, documentHostName ,documentPath)
        {
            DocumentTitle = documentTitle;
        }

    }
}