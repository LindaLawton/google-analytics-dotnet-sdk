using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Core.Hits
{
    public class EventHit : Hit
    {
        public EventHit(string eventcatagory, string eventAction) : base()
        {
            HitType = HitTypes.Event;
            EventCategory = eventcatagory;
            EventAction = eventAction;
        }

        public EventHit(string eventcatagory, string eventAction, string eventLabel) : this(eventcatagory, eventAction)
        {
            HitType = HitTypes.Event;
            EventLabel = eventLabel;
        }

        public EventHit(string eventcatagory, string eventAction, string eventLabel, long eventValue) : this(eventcatagory, eventAction, eventLabel)
        {
            HitType = HitTypes.Event;
            EventValue = eventValue.ToString();
        }

    }
}
