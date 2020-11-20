// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace Google.Analytics.SDK.Core.Hits.MobileHits
{
    public class ScreenViewHit : ScreenViewHitBase
    {
        [Obsolete("This method is obsolete. Mobile google analytics accounts not supported.", false)]
        public ScreenViewHit(string screenName) : base(screenName)
        {
            
        }
    }
}