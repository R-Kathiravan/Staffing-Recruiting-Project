using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Staffing_Recruting_API.Model;
using Staffing_Recruting_API.Services.JobsServices;

namespace Staffing_Recruting_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : Controller
    {
        public readonly IJobServices _jobServices;
        public JobsController(IJobServices jobServices)
        {
            _jobServices = jobServices;
        }
        [HttpGet("GetJobs")]

        [Authorize(Roles = "canditate")]

        public async Task<ActionResult<IEnumerable<Jobs>>> GetJobs()
        {
            try
            {
                var jobs = await _jobServices.GetJobs();
                if (jobs == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(jobs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("InsertJobs")]

        public async Task<ActionResult<bool>> AddJobs(AddJobsDTO addJobsDTO)
        {
            try
            {
                var result = await _jobServices.AddJobs(addJobsDTO);
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
