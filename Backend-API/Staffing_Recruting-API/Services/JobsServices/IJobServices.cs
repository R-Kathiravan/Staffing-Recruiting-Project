using Staffing_Recruting_API.Model;

namespace Staffing_Recruting_API.Services.JobsServices
{
    public interface IJobServices
    {
        Task<IEnumerable<Jobs>> GetJobs(string recId);

        Task<bool> AddJobs(AddJobsDTO jobs, string recId);

        //Task<bool> UpdateJobs(AddJobsDTO jobs);

        Task<IEnumerable<GetJobs>> GetAllJobs();

        Task<bool> UpdateJobs(UpdateJobsDTO jobs);
    }
}
