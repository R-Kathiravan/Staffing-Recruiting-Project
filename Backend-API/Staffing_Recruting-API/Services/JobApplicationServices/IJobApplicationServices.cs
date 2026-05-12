using Staffing_Recruting_API.Model;
namespace Staffing_Recruting_API.Services.JobApplicationServices
{
    public interface IJobApplicationServices
    {
        //Task<IEnumerable<JobApplications>> GetJobApplications();

        Task<bool> ApplyToJob(AddJobApplicationDTO jobApplication, string candidateID);
    }
}
