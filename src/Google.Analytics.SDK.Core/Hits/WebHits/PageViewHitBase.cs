// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits.WebHits
{
    public abstract class PageViewHitBase : HitBase
    {
        protected PageViewHitBase() 
        {
            HitType = HitTypes.Pageview;
            // Google analytics does not require any special paramaters to be sent for a pageview hit.
            // Personally I think documentLocationUrl should be set always.
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

        protected override bool InternalValidate()
        {
            if (!string.IsNullOrWhiteSpace(DocumentLocationURL)) return true;

            Console.WriteLine($"Required paramater missing. DocumentLocationURL={DocumentLocationURL}");
            return false;
        }

    }
}