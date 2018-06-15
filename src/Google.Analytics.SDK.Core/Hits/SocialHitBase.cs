// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class SocialHitBase : HitBase
    {
        protected SocialHitBase(string socialNetwork, string socialAction, string socialActionTarget) 
        {
            HitType = HitTypes.Social;

            if (string.IsNullOrWhiteSpace(socialNetwork)) throw new ArgumentNullException(socialNetwork);
            if (string.IsNullOrWhiteSpace(socialAction)) throw new ArgumentNullException(SocialAction);
            if (string.IsNullOrWhiteSpace(socialActionTarget)) throw new ArgumentNullException(SocialActionTarget);
            SocialNetwork = socialNetwork;
            SocialAction = socialAction;
            SocialActionTarget = socialActionTarget;
        }

        protected override bool InternalValidate()
        {
            if(!string.IsNullOrWhiteSpace(SocialNetwork) && !string.IsNullOrWhiteSpace(SocialAction) && !string.IsNullOrWhiteSpace(SocialActionTarget)) return true;

            Console.WriteLine($"Required paramater missing. SocialNetwork={SocialNetwork}, SocialAction={SocialAction}, SocialActionTarget={SocialActionTarget}");
            return false;
        }
    }
}