using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Staffing_Recruting_API.Model;
using Staffing_Recruting_API.Services.CandidateProfileServices;

namespace Staffing_Recruting_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateProfileController : Controller
    {
        private ICandidateProfile _candidateProfile;

        public CandidateProfileController(ICandidateProfile candidateProfile)
        {
            _candidateProfile = candidateProfile;
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
            catch (Exception ex)
            {
                throw ex;
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
    }
}