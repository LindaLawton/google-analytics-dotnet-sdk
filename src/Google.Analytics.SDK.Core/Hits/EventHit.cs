// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
namespace Google.Analytics.SDK.Core.Hits
{
    public class EventHit : EventHitBase
    {
        public EventHit(string eventcatagory, string eventAction) : base(eventcatagory, eventAction)
        {

        }

        public EventHit(string eventcatagory, string eventAction, string eventLabel) : base(eventcatagory, eventAction, eventLabel)
        {
            
        }

        public EventHit(string eventcatagory, string eventAction, string eventLabel, long eventValue) : base(eventcatagory, eventAction, eventLabel, eventValue)
        {
            
        }
    }
}
