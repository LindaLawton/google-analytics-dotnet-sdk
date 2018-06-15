// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class TransactionHitBase : HitBase
    {
        protected TransactionHitBase(string transactionId) 
        {
            if (string.IsNullOrWhiteSpace(transactionId)) throw new ArgumentNullException(transactionId);
            HitType = HitTypes.Transaction;
            TransactionId = transactionId;
        }

        protected override bool InternalValidate()
        {
            if (!string.IsNullOrWhiteSpace(TransactionId)) return true;

            Console.WriteLine($"Required paramater missing. TransactionId={TransactionId}");
            return false;
        }

    }
}