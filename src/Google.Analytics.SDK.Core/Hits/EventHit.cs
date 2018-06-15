// Copyright (c) Linda Lawton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
namespace Google.Analytics.SDK.Core.Hits
{
    public class EventHit : EventHitBase
    {
        public EventHit(string eventcatagory, string eventAction) : base(eventcatagory, eventAction)
        {

        }

        public EventHit(string eventcatagory, string eventAction, string eventLabel) : this(eventcatagory, eventAction)
        {
            
        }

        public EventHit(string eventcatagory, string eventAction, string eventLabel, long eventValue) : this(eventcatagory, eventAction, eventLabel)
        {
            
        }
    }
}
