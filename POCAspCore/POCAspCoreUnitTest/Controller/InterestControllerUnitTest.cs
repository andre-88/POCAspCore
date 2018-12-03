using Moq;
using POCAspCore.Business;
using POCAspCore.Controllers;
using Xunit;
using System;

namespace POCAspCoreUnitTest.Controller
{
    public class InterestControllerUnitTest
    {
        [Fact]
        public void should_return_GitHubURL()
        {
            //Mock
            var mock = new Mock<IInterestBO>();
            mock.Setup(p => p.getGitHubRepository()).Returns("abc");
            InterestController controller = new InterestController(mock.Object);

            //Action
            var result = controller.GetShowMeTheCode();

            //Check
            Assert.Equal("abc", result.Value);
        }

        [Fact]
        public void should_return_error_GitHubURL()
        {
            //Mock
            var mock = new Mock<IInterestBO>();
            mock.Setup(p => p.getGitHubRepository()).Throws<Exception>();
            var controller = new InterestController(mock.Object);

            //Action
            var result = controller.GetShowMeTheCode();

            //Check
            Assert.Equal(500, ((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).StatusCode);
        }


        [Fact]
        public void should_return_interest_rate()
        {
            //Mock
            var mock = new Mock<IInterestBO>();
            mock.Setup(p => p.getCompoundInterestValue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns("12.5");
            var controller = new InterestController(mock.Object);

            //Action
            var result = controller.GetCompoundInterest("100", "2");

            //Check
            Assert.Equal("12.5", result.Value);
        }

        [Fact]
        public void should_return_error_interest_parameter_cast()
        {
            //Mock
            var mock = new Mock<IInterestBO>();
            mock.Setup(p => p.getCompoundInterestValue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Throws<InvalidCastException>();
            var controller = new InterestController(mock.Object);

            //Action
            var result = controller.GetCompoundInterest("100","2");

            //Check
            Assert.Equal(500, ((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).StatusCode);
            Assert.Equal("Error: Specified cast is not valid.", 
                ((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).Value);
        }

    }
}
