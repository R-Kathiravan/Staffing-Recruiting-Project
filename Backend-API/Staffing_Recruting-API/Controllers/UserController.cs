using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Staffing_Recruting_API.Model;
using Staffing_Recruting_API.Services.AuthServices;
using Staffing_Recruting_API.Services.UserServices;

namespace Staffing_Recruting_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public readonly IUserServices _userServices;
        private readonly IAuthServices _authServices;
        public UserController(IUserServices userServices, IAuthServices authServices)
        {
            _userServices = userServices;
            _authServices = authServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            try
            {
                var users = await _userServices.GetUsers();

                if (users == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost("InsertUsers")]

        public async Task<ActionResult> AddUsers(AddUserDTO addUserDTO)
        {
            try
            {
                var result = await _userServices.AddUsers(addUserDTO);

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
        [HttpPost("CheckUsers")]
        public async Task<ActionResult<bool>> checkUser(CheckUserDTO checkUserDTO)
        {
            try
            {
                string token = await _authServices.Login(checkUserDTO);

                if (token == null)
                {
                    return Unauthorized("Invalid Username or Password");
                }

                return Ok(new { token = token });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetUserDetails")]
        [Authorize(Roles = "Candidate, Recruiter")]
        public async Task<ActionResult<GetUserDetailsDTO>> UserDetails()
        {
            try
            {
                var candidateID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userDetails = await _userServices.GetUserDetails(Convert.ToInt32(candidateID));
                if (userDetails == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(userDetails);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}