using Microsoft.EntityFrameworkCore;
using Staffing_Recruting_API.Data;
using Staffing_Recruting_API.Model;

namespace Staffing_Recruting_API.Services.UserServices
{
    public class UserServices : IUserServices
    {
        public readonly AppDbContext _appDbContext;

        public UserServices(AppDbContext appDb)
        {
            _appDbContext = appDb;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            try
            {
                var result = await _appDbContext.Users.ToListAsync();
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Error while retreiving data");

            }

        }

        public async Task<bool> AddUsers(AddUserDTO users)
        {
            try
            {
                var data = new Users
                {
                    UserName = users.UserName,
                    Email = users.Email,
                    FullName = users.FullName,
                    Password = users.Password,
                    Role = users.Role,
                    CreatedAt = DateTime.Now,
                };

                _appDbContext.Users.Add(data);
                _appDbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting data");
            }
        }
        public async Task<bool> CheckUsers(CheckUserDTO checkUser)
        {
            try
            {
                var result = await _appDbContext.Users.Where(u => u.UserName == checkUser.UserName && u.Password == checkUser.Password && u.Role == checkUser.Role).FirstOrDefaultAsync();
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while checking user");
            }
        }

    }
}