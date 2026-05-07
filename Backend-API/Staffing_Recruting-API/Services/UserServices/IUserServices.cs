using Staffing_Recruting_API.Model;

namespace Staffing_Recruting_API.Services.UserServices
{
    public interface IUserServices
    {
        Task<IEnumerable<Users>> GetUsers();

        Task<bool> AddUsers(AddUserDTO users);

        Task<bool> CheckUsers(CheckUserDTO checkUser);

    }
}
