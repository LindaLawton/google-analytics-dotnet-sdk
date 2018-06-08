using Google.Analytics.SDK.Core;
using Google.Analytics.SDK.Core.Helper;

namespace Google.Analytics.SDK.Tests.Common
{
    public class MockWebTracker : GaTracker
    {

        public MockWebTracker() : base(GaTrackerType.Web, "XXX-XXX-XXX")
        {

        }
    }
}