using Google.Analytics.SDK.Core;

namespace Google.Analytics.SDK.UnitTests.Common
{
    internal class MockHitResponse : IResponse
    {

        public static HitResponse NoResult()
        {
            return null;
        }


        public bool IsValid()
        {
            return true;
        }

        public bool IsError()
        {
            return false;
        }
    }

}
