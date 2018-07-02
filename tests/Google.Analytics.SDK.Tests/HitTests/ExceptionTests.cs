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
        private const string ExceptionIsFatal = "0";

        [Fact]
        public void Create_ExceptionHit_All_Validate_Success()
        {
            var hit = new ExceptionHit(ExecptionDescription, ExecptionIsFatal);
            Assert.True(hit.Validate());
        }

        [Fact]
        public void Create_ExceptionHit_All_Validate_Values()
        {
            var hit = new ExceptionHit(ExecptionDescription, ExecptionIsFatal);
            Assert.Equal(ExecptionDescription, hit.ExceptionDescription);
            Assert.Equal(hit.ExceptionIsFatal, ExceptionIsFatal);
            Assert.Equal(HitType, hit.HitType, true);
        }

        [Fact]
        public void Create_Exception_invalid_throwsException()
        {
            var hit = new ExceptionHit(ExecptionDescription, ExecptionIsFatal);
            hit.ExceptionIsFatal = "goboom";

            Assert.Throws<ArgumentOutOfRangeException>(() => hit.Validate());
        }

    }
}