using System;
using Google.Analytics.SDK.Core.Helper;
using Google.Analytics.SDK.Core.Hits;
using Xunit;

namespace Google.Analytics.SDK.Tests.HitTests
{
    public class ExceptionTests
    {
        private const string ExecptionDescription = "brain fart";
        private const bool ExecptionIsFatal = false;
        private const string HitType = HitTypes.Exception;

        [Fact]
        public void Create_ExceptionHit_All_Validate_Success()
        {
            var hit = new ExceptionHit(ExecptionDescription, ExecptionIsFatal);
            Assert.True(hit.Validate().Valid);
        }

        [Fact]
        public void Create_ExceptionHit_All_Validate_Values()
        {
            const string fatal = "0";

            var hit = new ExceptionHit(ExecptionDescription, ExecptionIsFatal);
            Assert.Equal(ExecptionDescription, hit.ExceptionDescription);
            Assert.Equal(hit.ExceptionIsFatal, fatal);
            Assert.Equal(HitType, hit.HitType, true);
        }

        [Fact]
        public void Create_Exception_invalid_throwsException()
        {
            var hit = new ExceptionHit(ExecptionDescription, ExecptionIsFatal);
            hit.ExceptionIsFatal = "goboom";

            Assert.False(hit.Validate().Valid);
        }

    }
}