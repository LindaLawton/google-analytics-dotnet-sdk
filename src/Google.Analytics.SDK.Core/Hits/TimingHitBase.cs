// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class TimingHitBase : HitBase
    {
        protected TimingHitBase(string userTimeingCatagory, string userTimeingVariableName, int userTimingTime)
        {
            if (string.IsNullOrWhiteSpace(userTimeingCatagory)) throw new ArgumentNullException(userTimeingCatagory);
            if (string.IsNullOrWhiteSpace(userTimeingVariableName)) throw new ArgumentNullException(userTimeingVariableName);
            

            UserTimingCatagory = userTimeingCatagory;
            UserTimingVariableName = userTimeingVariableName;
            UserTimingTime = userTimingTime.ToString();
            HitType = HitTypes.Timing;
        }
        protected override bool InternalValidate()
        {
            if (!string.IsNullOrWhiteSpace(UserTimingCatagory) && !string.IsNullOrWhiteSpace(UserTimingVariableName) && !string.IsNullOrWhiteSpace(UserTimingTime)) return true;

            Console.WriteLine($"Required paramater missing. UserTimingCatagory={UserTimingCatagory}, UserTimingVariableName={UserTimingVariableName}, UserTimingTime={UserTimingTime}");
            return false;
        }
    }
}