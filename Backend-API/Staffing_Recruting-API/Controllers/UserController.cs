using Microsoft.AspNetCore.Mvc;
using Staffing_Recruting_API.Model;
using Staffing_Recruting_API.Services.UserServices;

namespace Staffing_Recruting_API.Controllers
{
    public class UserController : Controller
    {
        public readonly UserServices _userServices;
        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

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
        }
    }
}
