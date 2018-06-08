using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Tests.Common
{
    public class MockMobileTracker : GaTracker
    {

        public MockMobileTracker() : base(GaTrackerType.Mobile, "XXX-XXX-XXX")
        {
            
        }
    }
}
