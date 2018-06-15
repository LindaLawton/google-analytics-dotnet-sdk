﻿// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class ItemHitBase : HitBase
    {
        protected ItemHitBase(string transactionId)
        {
            HitType = HitTypes.Item;
            TransactionId = transactionId;
        }

        protected override bool InternaValidate()
        {
            return false;
        }
    }
}