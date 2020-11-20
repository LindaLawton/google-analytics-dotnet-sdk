// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits.MobileHits
{
    public abstract class ScreenViewHitBase : HitBase
    {
        [Obsolete("This method is obsolete. Mobile google analytics accounts not supported.", false)]
        protected ScreenViewHitBase(string screenName)
        {
            if (string.IsNullOrWhiteSpace(screenName)) throw new ArgumentNullException(screenName);
            HitType = HitTypes.Screenview;
            ScreenName = screenName;
        }

        protected override bool InternalValidate()
        {
            if (!string.IsNullOrWhiteSpace(ScreenName)) return true;

            Console.WriteLine($"Required paramater missing. ScreenName={ScreenName}");
            return false;
        }
    }
}