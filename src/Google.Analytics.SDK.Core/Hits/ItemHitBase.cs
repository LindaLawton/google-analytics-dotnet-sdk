// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class ItemHitBase : HitBase
    {
        protected ItemHitBase(string transactionId, string itemName)
        {
            if (string.IsNullOrWhiteSpace(transactionId)) throw new ArgumentNullException(transactionId);
            if (string.IsNullOrWhiteSpace(itemName)) throw new ArgumentNullException(itemName);

            HitType = HitTypes.Item;
            TransactionId = transactionId;
            ItemName = itemName;
        }

        protected override bool InternalValidate()
        {
            if (!string.IsNullOrWhiteSpace(TransactionId) && !string.IsNullOrWhiteSpace(ItemName)) return true;

            Console.WriteLine($"Required paramater missing. TransactionId={TransactionId}, ItemName={ItemName}");
            return false;
        }
    }
}