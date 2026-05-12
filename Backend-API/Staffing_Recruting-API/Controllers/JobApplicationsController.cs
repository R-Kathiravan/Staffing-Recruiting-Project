using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Staffing_Recruting_API.Model;
using Staffing_Recruting_API.Services.JobApplicationServices;

namespace Staffing_Recruting_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobApplicationsController : Controller
    {
        public readonly IJobApplicationServices _jobApplicationServices;

        public JobApplicationsController(IJobApplicationServices jobApplicationServices)
        {
            _jobApplicationServices = jobApplicationServices;
        }

        [HttpPost("ApplyJob")]
        [Authorize(Roles = "Candidate")]

        public async Task<ActionResult<bool>> ApplyJob(AddJobApplicationDTO addJobApplicationDTO)
        {
            try
            {
                var candidateID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _jobApplicationServices.ApplyToJob(addJobApplicationDTO, candidateID);
                if (result == false)
                {
                    return BadRequest();
                }
                else
                {
                    return Created();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
