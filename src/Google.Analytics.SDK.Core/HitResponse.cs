using System;

namespace Google.Analytics.SDK.Core
{
    public class HitResponse : IResponse
    {
        public static HitResponse NoResult()
        {
            return null;
        }


        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public bool IsError()
        {
            throw new NotImplementedException();
        }
    }
}