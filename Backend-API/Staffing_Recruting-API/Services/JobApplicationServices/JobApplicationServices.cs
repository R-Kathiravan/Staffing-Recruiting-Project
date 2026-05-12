using Staffing_Recruting_API.Data;
using Staffing_Recruting_API.Model;
using Staffing_Recruting_API.Services.JobApplicationServices;

namespace Staffing_Recruting_API.Services.JobApplication
{
    public class JobApplicationServices : IJobApplicationServices
    {
        private AppDbContext _appDbContext;

        public JobApplicationServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> ApplyToJob(AddJobApplicationDTO addJobApplicationDTO, string candidateID)
        {
            try
            {
                var insertedData = new JobApplications
                {
                    JobID = addJobApplicationDTO.JobID,
                    CandidateID = Convert.ToInt16(candidateID),
                    FirstName = addJobApplicationDTO.FirstName,
                    LastName = addJobApplicationDTO.LastName,
                    Email = addJobApplicationDTO.Email,
                    Phone = addJobApplicationDTO.Phone,
                    ResumeURL = addJobApplicationDTO.ResumeURL,
                    CoverLetterURL = addJobApplicationDTO.CoverLetterURL,
                    Status = "Applied",
                    AppliedAt = DateTime.UtcNow,
                    ApplicationUpdateDate = DateTime.UtcNow
                };
                _appDbContext.JobApplications.Add(insertedData);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
