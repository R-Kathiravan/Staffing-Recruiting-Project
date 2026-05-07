using Microsoft.EntityFrameworkCore;
using Staffing_Recruting_API.Data;
using Staffing_Recruting_API.Model;

namespace Staffing_Recruting_API.Services.JobsServices
{
    public class JobServices : IJobServices
    {
        public readonly AppDbContext _appDbContext;
        public JobServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Jobs>> GetJobs()
        {
            var jobs = await _appDbContext.Jobs.ToListAsync();
            return jobs;
        }

        public async Task<bool> AddJobs(AddJobsDTO addjob)
        {
            try
            {
                var insertData = new Jobs
                {
                    Name = addjob.Name,
                    Description = addjob.Description,
                    Location = addjob.Location,
                    Company_ID = addjob.Company_ID,
                    Recruiter = addjob.Recruiter,
                    Salary = addjob.Salary,
                    Status = addjob.Status,
                    CreatedAt = DateTime.Now
                };
                _appDbContext.Jobs.Add(insertData);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("Error while inserting data", ex);
            }
        }
    }
}
