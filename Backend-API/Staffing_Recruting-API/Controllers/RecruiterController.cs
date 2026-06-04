using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Staffing_Recruting_API.Model;
using Staffing_Recruting_API.Services.JobApplicationServices;
using Staffing_Recruting_API.Services.JobsServices;

namespace Staffing_Recruting_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecruiterController : Controller
    {
        public readonly IJobServices _jobServices;
        public readonly IJobApplicationServices _jobApplicationServices;
        public RecruiterController(IJobServices jobServices, IJobApplicationServices jobApplicationServices)
        {
            _jobServices = jobServices;
            _jobApplicationServices = jobApplicationServices;
        }
        [HttpGet("GetJobs")]

        [Authorize(Roles = "Recruiter")]

        public async Task<ActionResult<IEnumerable<GetJobs>>> GetJobs()
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
            catch
            {
                throw;
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
            catch
            {
                throw;
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
            catch
            {
                throw;
            }
        }

        [HttpGet("GetApplicantsPerJob/{id}")]
        [Authorize(Roles = "Recruiter")]
        public async Task<ActionResult<IEnumerable<ApplicantProfileDTO>>> GetApplicantsPerJob(int id)
        {
            try
            {
                var jobDetails = await _jobApplicationServices.GetApplicantsForJob(id);
                if (jobDetails == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(jobDetails);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}