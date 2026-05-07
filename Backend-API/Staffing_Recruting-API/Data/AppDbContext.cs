using Microsoft.EntityFrameworkCore;
using Staffing_Recruting_API.Model;

namespace Staffing_Recruting_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        public DbSet<Jobs> Jobs { get; set; }

    }
}
