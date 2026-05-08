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

        public async Task<IEnumerable<Jobs>> GetJobs(string recruiterId)
        {
            string recID = recruiterId;
            var jobs = await _appDbContext.Jobs.Where(job => job.Recruiter_ID == recruiterId)
                                                .OrderByDescending(job => job.CreatedAt)
                                                .ToListAsync();
            return jobs;
        }

        public async Task<bool> AddJobs(AddJobsDTO addjob, string recruiterId)
        {
            try
            {
                var insertData = new Jobs
                {
                    Title = addjob.Title,
                    Description = addjob.Description,
                    Location = addjob.Location,
                    Recruiter_ID = recruiterId,
                    From_Salary = addjob.From_Salary,
                    To_Salary = addjob.To_Salary,
                    SalaryType = addjob.SalaryType,
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
