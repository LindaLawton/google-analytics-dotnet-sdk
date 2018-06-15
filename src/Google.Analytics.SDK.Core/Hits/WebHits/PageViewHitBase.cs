// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits.WebHits
{
    public abstract class PageViewHitBase : HitBase
    {
        protected PageViewHitBase() 
        {
            HitType = HitTypes.Pageview;
            DocumentLocationURL = "(not set)";
        }

        protected PageViewHitBase(string documentLocationUrl) : this()
        {
            DocumentLocationURL = documentLocationUrl;
        }

        protected PageViewHitBase(string documentLocationUrl, string documentHostName) : this( documentLocationUrl)
        {
            DocumentHostName = documentHostName;
        }

        protected PageViewHitBase(string documentLocationUrl, string documentHostName, string documentPath) : this(documentLocationUrl, documentHostName)
        {
            DocumentPath = documentPath;
        }

        protected PageViewHitBase(string documentLocationUrl, string documentHostName, string documentPath, string documentTitle) : this( documentLocationUrl, documentHostName ,documentPath)
        {
            DocumentTitle = documentTitle;
        }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
        public bool Validate()
        {
            throw new System.NotImplementedException();
        }

    }
}