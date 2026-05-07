using Staffing_Recruting_API.Model;

namespace Staffing_Recruting_API.Services.JobsServices
{
    public interface IJobServices
    {
        Task<IEnumerable<Jobs>> GetJobs();

        Task<bool> AddJobs(AddJobsDTO jobs);

        //Task<bool> UpdateJobs(AddJobsDTO jobs);
    }
}
