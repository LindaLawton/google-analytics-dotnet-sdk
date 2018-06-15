// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class SocialHitBase : HitBase
    {
        protected SocialHitBase() 
        {
            HitType = HitTypes.Social;
        }

        protected override bool InternaValidate()
        {
            return false;
        }
    }
}