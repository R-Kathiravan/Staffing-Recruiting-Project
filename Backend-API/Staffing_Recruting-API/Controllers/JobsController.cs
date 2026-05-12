using System.Security.Claims;
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

        [Authorize(Roles = "Recruiter")]

        public async Task<ActionResult<IEnumerable<Jobs>>> GetJobs()
        {
            try
            {
                var recruiterId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var jobs = await _jobServices.GetJobs(recruiterId);
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
        [Authorize(Roles = "Recruiter")]
        public async Task<ActionResult<bool>> AddJobs(AddJobsDTO addJobsDTO)
        {
            try
            {
                var recruiterId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _jobServices.AddJobs(addJobsDTO, recruiterId);
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

        [HttpPut("UpdateJobs")]
        [Authorize(Roles = "Recruiter")]

        public async Task<ActionResult<bool>> UpdateJobs(UpdateJobsDTO updateJobsDTO)
        {
            try
            {
                var result = await _jobServices.UpdateJobs(updateJobsDTO);
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

        [HttpGet("GetAllJobs")]
        [Authorize(Roles = "Candidate")]
        public async Task<ActionResult<GetJobs>> GetAllJobs()
        {
            try
            {
                var jobs = await _jobServices.GetAllJobs();
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

    }
}
