using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Staffing_Recruting_API.Model;
using Staffing_Recruting_API.Services.CandidateProfileServices;
using Staffing_Recruting_API.Services.JobApplicationServices;
using Staffing_Recruting_API.Services.JobsServices;

namespace Staffing_Recruting_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CandidateController : Controller
    {
        private ICandidateProfile _candidateProfile;
        private IJobApplicationServices _jobApplicationServices;
        private IJobServices _jobServices;

        public CandidateController(ICandidateProfile candidateProfile, IJobApplicationServices jobApplicationServices, IJobServices jobServices)
        {
            _candidateProfile = candidateProfile;
            _jobApplicationServices = jobApplicationServices;
            _jobServices = jobServices;
        }

        [HttpPost("CreateCandidateProfile")]
        [Authorize(Roles = "Candidate")]
        public async Task<ActionResult<bool>> CreateCandidateProfile(AddCandidateProfile addCandidateProfile)
        {
            try
            {
                var candidateID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _candidateProfile.CreateCandidateProfile(addCandidateProfile, Convert.ToInt32(candidateID));
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

        [HttpGet("GetCandidateProfile")]
        [Authorize(Roles = "Candidate")]

        public async Task<ActionResult<GetCandidateProfile>> GetCandidateProfile()
        {
            try
            {
                var candidateID = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var result = await _candidateProfile.GetCandidateProfile(Convert.ToInt16(candidateID));
                if (result == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            catch
            {
                throw;

            }
        }
        [HttpPost("UploadResume")]
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> UploadResume([FromForm] FileUpload fileUpload)
        {
            try
            {
                var file = fileUpload.file;
                var oldFilePath = fileUpload.oldFilePath;
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file was uploaded.");
                }

                var folderName = Path.Combine("wwwroot", "uploads", "resumes");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }

                if (!string.IsNullOrEmpty(oldFilePath))
                {
                    var oldFileName = Path.GetFileName(oldFilePath);
                    var oldPhysicalPath = Path.Combine(pathToSave, oldFileName);

                    if (System.IO.File.Exists(oldPhysicalPath))
                    {
                        System.IO.File.Delete(oldPhysicalPath);
                    }
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine(pathToSave, uniqueFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var dbPath = $"/uploads/resumes/{uniqueFileName}";
                return Ok(new { Url = dbPath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
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

        [HttpGet("GetCandidateResume")]
        [Authorize(Roles = "Candidate")]
        public async Task<ActionResult> GetCandidateResume()
        {
            try
            {
                var candidateID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _candidateProfile.GetCandidateResume(Convert.ToInt16(candidateID));
                if (result == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetJobApplyDetails/{id}")]
        [Authorize(Roles = "Candidate")]

        public async Task<ActionResult<GetCandidateProfile>> GetJobApplyDetails(int id)
        {
            try
            {
                var result = await _jobServices.GetJobDetails(id);
                if (result == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}