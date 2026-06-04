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

        public async Task<IEnumerable<GetJobs>> GetJobs(string recruiterId)
        {
            var jobs = await _appDbContext.Jobs.Where(job => job.Recruiter_ID == recruiterId)
                                               .OrderByDescending(job => job.CreatedAt)
                                               .Select(job => new GetJobs
                                               {
                                                   Id = job.Id,
                                                   Title = job.Title,
                                                   Description = job.Description,
                                                   Location = job.Location,
                                                   From_Salary = job.From_Salary,
                                                   To_Salary = job.To_Salary,
                                                   SalaryType = job.SalaryType,
                                                   RequiredExperience = job.RequiredExperience,
                                                   Status = job.Status,
                                                   CreatedAt = job.CreatedAt,
                                                   ApplicationCount = job.Applications.Count()
                                               })
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
                    RequiredExperience = addjob.RequiredExperience,
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

        public async Task<bool> UpdateJobs(UpdateJobsDTO updateJobsDTO)
        {
            try
            {
                var job = await _appDbContext.Jobs.FindAsync(updateJobsDTO.ID);
                if (job == null)
                {
                    return false;
                }
                job.Title = updateJobsDTO.Title;
                job.Description = updateJobsDTO.Description;
                job.Location = updateJobsDTO.Location;
                job.From_Salary = updateJobsDTO.From_Salary;
                job.To_Salary = updateJobsDTO.To_Salary;
                job.SalaryType = updateJobsDTO.SalaryType;
                job.Status = updateJobsDTO.Status;
                _appDbContext.Jobs.Update(job);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("Error while updating data", ex);
            }
        }

        public async Task<IEnumerable<GetJobs>> GetAllJobs()
        {
            try
            {
                var jobs = await _appDbContext.Jobs.Select(job => new GetJobs
                {
                    Id = job.Id,
                    Title = job.Title,
                    Description = job.Description,
                    Location = job.Location,
                    Recruiter_ID = job.Recruiter_ID,
                    From_Salary = job.From_Salary,
                    To_Salary = job.To_Salary,
                    RequiredExperience = job.RequiredExperience,
                    SalaryType = job.SalaryType,
                    Status = job.Status,
                    CreatedAt = job.CreatedAt
                }).ToListAsync();

                return jobs;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving data", ex);
            }
        }

        public async Task<IEnumerable<JobApply>> GetJobDetails(int id)
        {
            try
            {
                var jobDetails = await _appDbContext.Jobs.Where(j => j.Id == id).Select(j => new JobApply
                {
                    Title = j.Title,
                    Description = j.Description,
                    CreatedAt = j.CreatedAt,
                    Location = j.Location,
                    ApplicationCount = _appDbContext.JobApplication.Count(ja => ja.JobID == j.Id)
                }).ToListAsync();

                return jobDetails;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving data", ex);
            }
        }

    }
}