using Microsoft.EntityFrameworkCore;
using Staffing_Recruting_API.Data;
using Staffing_Recruting_API.Model;

namespace Staffing_Recruting_API.Services.AuthServices
{
    public class AuthServices : IAuthServices
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;

        public AuthServices(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }

        public async Task<string> Login(CheckUserDTO checkUserDTO)
        {
            // 1. Use Async to prevent blocking the server
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u =>
                u.UserName == checkUserDTO.UserName &&
                u.Password == checkUserDTO.Password &&
                u.Role == checkUserDTO.Role);

            if (user == null)
            {
                return null; // Invalid credentials
            }

            // 2. Generate JWT token
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                // 3. CORRECTLY map the claims so [Authorize] and your ID logic works!
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.UserName),
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.Email),
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, user.Role),
            
            // This is the magical line that makes User.FindFirstValue(ClaimTypes.NameIdentifier) work!
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.ID.ToString())
        }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
