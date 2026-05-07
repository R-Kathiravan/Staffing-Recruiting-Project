using Staffing_Recruting_API.Model;

namespace Staffing_Recruting_API.Services.AuthServices
{
    public interface IAuthServices
    {
        Task<string> Login(CheckUserDTO checkUserDTO);
    }
}
