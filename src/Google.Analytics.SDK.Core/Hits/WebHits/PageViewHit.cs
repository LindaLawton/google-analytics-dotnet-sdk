// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Google.Analytics.SDK.Core.Hits.WebHits
{
    public class PageViewHit : PageViewHitBase
    {
        public PageViewHit() : base()
        {
            
        }

        public PageViewHit(string documentLocationUrl) : base(documentLocationUrl)
        {
            
        }

        public PageViewHit(string documentLocationUrl, string documentHostName) : base(documentLocationUrl, documentHostName)
        {
            
        }

        public PageViewHit(string documentLocationUrl, string documentHostName, string documentPath) : base(documentLocationUrl, documentHostName, documentPath)
        {
            
        }

        public PageViewHit(string documentLocationUrl, string documentHostName, string documentPath, string documentTitle) : base(documentLocationUrl, documentHostName, documentPath, documentTitle)
        {
            
        }

    }
}