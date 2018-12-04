using Moq;
using POCAspCore.Business;
using Xunit;
using Microsoft.Extensions.Configuration;
using System;

namespace POCAspCoreUnitTest.Business
{
    public class InterestBoUnitTest
    {
        [Theory]
        [InlineData("a",  "2",  10)]
        [InlineData("500",  "b",  6)]
        [InlineData("300",  "8",  200)]
        [InlineData("300",  "8",  -1)]
        public void should_return_error_interest_calcultation(string valorinicial, string meses, int ratePercentage)
        {
            int hasException = 0;

            //Mock
            var mock = new Mock<IConfigurationRoot>();
            var interestBo = new InterestBO(mock.Object);

            //Action
            try
            {
                var result = interestBo.getCompoundInterestValue(valorinicial, meses, ratePercentage);
            }
            catch (Exception)
            {
                hasException = 1;
            }
            Assert.Equal(1, hasException);
        }

        [Theory]
        [InlineData("100", "5", 1)]
        public void should_return_interest_calcultation(string valorinicial, string meses, int ratePercentage)
        {
            int hasException = 0;

            //Mock
            var mock = new Mock<IConfigurationRoot>();
            var interestBo = new InterestBO(mock.Object);

            //Action
            try
            {
                var result = interestBo.getCompoundInterestValue(valorinicial, meses, ratePercentage);
                Assert.Equal("105,10", result);
            }
            catch (Exception)
            {
                hasException = 1;
            }
            Assert.Equal(0, hasException);
        }
    }
}
