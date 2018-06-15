// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits.MobileHits
{
    public abstract class ScreenViewHitBase : HitBase
    {
        protected ScreenViewHitBase(string screenName)
        {
            HitType = HitTypes.Screenview;
            ScreenName = screenName;
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