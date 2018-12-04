using System;
using Microsoft.AspNetCore.Mvc;
using POCAspCore.Business;

namespace POCAspCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly IInterestBO interestBo;

        public InterestController(IInterestBO businessref)
        {
            interestBo = businessref;
        }

        [HttpGet]
        public ActionResult<string> Index()
        {
            return ">>> Loaded!\n api/interest/showmethecode \n api/interest/calculajuros?valorinicial=100&meses=5";
        }

        [HttpGet]
        [Route("showmethecode")]
        public ActionResult<string> GetShowMeTheCode()
        {
            try
            {
                var result = interestBo.getGitHubRepository();
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }

        /// calculajuros?valorinicial=100&meses=5
        [HttpGet]
        [Route("calculajuros")]
        public ActionResult<string> GetCompoundInterest(
            [FromQuery(Name = "valorinicial")] string valorinicial,
            [FromQuery(Name = "meses")] string meses
            )
        {
            try
            {
                var ratePercentage = 1; 
                var result = interestBo.getCompoundInterestValue(valorinicial, meses, ratePercentage);

                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }
    }
}
