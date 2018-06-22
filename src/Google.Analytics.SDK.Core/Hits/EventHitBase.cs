// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public abstract class EventHitBase : HitBase
    {
        protected EventHitBase(string eventcatagory, string eventAction)
        {
            if (string.IsNullOrWhiteSpace(eventcatagory)) throw new ArgumentNullException(eventcatagory);
            if (string.IsNullOrWhiteSpace(eventAction)) throw new ArgumentNullException(eventAction);

            HitType = HitTypes.Event;
            EventCategory = eventcatagory;
            EventAction = eventAction;
        }

        protected EventHitBase(string eventcatagory, string eventAction, string eventLabel) : this(eventcatagory, eventAction)
        {
            HitType = HitTypes.Event;
            EventLabel = eventLabel;
        }

        protected EventHitBase(string eventcatagory, string eventAction, string eventLabel, long eventValue) : this(eventcatagory, eventAction, eventLabel)
        {
            HitType = HitTypes.Event;
            EventValue = eventValue.ToString();
        }

        protected override ValidateResponse InternalValidate()
        {
            LastValidateResponse = (!string.IsNullOrWhiteSpace(EventCategory) && !string.IsNullOrWhiteSpace(EventAction)) 
                ? ValidateResponse.Builder(true, string.Empty)
                : ValidateResponse.Builder(false, $"Required paramater missing. EventCategory={EventCategory}, EventAction={EventAction}");

            return LastValidateResponse;
        }
    }
}