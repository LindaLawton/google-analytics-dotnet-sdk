using System;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using Google.Analytics.SDK.Core.Hits.WebHits;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class EventHitTests
    {
        private const string EventCategory = "Catagory";
        private const string EventAction = "Action";
        private const string EventLabel = "Label";
        private const long EventValue = 1;


        [Fact]
        public void Create_EventHit_All_Validate_Success()
        {
            var hit = new EventHit(EventCategory, EventAction, EventLabel, EventValue);
            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_EventHit_All_Validate_Values()
        {

            var hit = new EventHit(EventCategory, EventAction, EventLabel, EventValue);
            Assert.Equal(EventCategory, hit.EventCategory);
            Assert.Equal(EventAction, hit.EventAction);
            Assert.Equal(EventLabel, hit.EventLabel);
            Assert.Equal(EventValue.ToString(), hit.EventValue);
        }


        [Fact]
        public void Create_EventHit_NoValue_Validate_Success()
        {
            var hit = new EventHit(EventCategory, EventAction, EventLabel);
            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_EventHit_NoLabel_Validate_Success()
        {
            var hit = new EventHit(EventCategory, EventAction);
            Assert.True(hit.Validate());
        }


        [Fact]
        public void Create_EventHit_NoCatagory_Fail()
        {
            var hit = new EventHit(EventCategory, EventAction);
            hit.EventCategory = null;
            Assert.False(hit.Validate());
        }

        [Fact]
        public void Create_EventHit_NoAction_Fail()
        {
            var hit = new EventHit(EventCategory, EventAction);
            hit.EventAction = null;
            Assert.False(hit.Validate());
        }

        [Fact]
        public void Create_EventHit_Catagory_Null_throwsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EventHit(string.Empty, EventAction));
        }

        [Fact]
        public void Create_EventHit_Action_Null_throwsException()
        {
            Assert.Throws<ArgumentNullException>(() => new EventHit(EventCategory, string.Empty));
        }


        [Fact]
        public void Create_PageviewHit_HitType_NotNull()
        {
            var hit = new PageViewHit("home");
            Assert.Equal(hit.HitType, HitTypes.Pageview, ignoreCase: true);
        }

    }
}