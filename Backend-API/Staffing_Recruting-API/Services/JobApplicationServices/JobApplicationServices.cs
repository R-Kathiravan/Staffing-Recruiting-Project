using Microsoft.EntityFrameworkCore;
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
                var insertedData = new Model.JobApplication
                {
                    JobID = addJobApplicationDTO.JobID,
                    CandidateID = Convert.ToInt16(candidateID),
                    CoverLetterURL = addJobApplicationDTO.CoverLetterURL,
                    Status = "Applied",
                    AppliedAt = DateTime.UtcNow,
                    ApplicationUpdateDate = DateTime.UtcNow
                };
                await _appDbContext.JobApplication.AddAsync(insertedData);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ApplicantProfileDTO>> GetApplicantsForJob(int id)
        {
            try
            {
                var query = from app in _appDbContext.JobApplication
                            where app.JobID == id

                            join profile in _appDbContext.CandidateProfile
                           on app.CandidateID equals profile.UserID

                            join user in _appDbContext.Users
                           on app.CandidateID equals user.ID

                            select new ApplicantProfileDTO
                            {
                                JobID = app.JobID,
                                UserID = user.ID,
                                ApplicationID = app.ID,
                                FullName = profile.FirstName + " " + profile.LastName,
                                Email = user.Email,
                                ProfessionalTitle = profile.ProfessionalTitle,
                                Bio = profile.Bio,
                                Skills = profile.Skills,
                                Experience = profile.Experience,
                                Education = profile.Education,
                                LinkedInUrl = profile.LinkedInUrl,
                                GithubUrl = profile.GitHubUrl,
                                ResumeUrl = profile.ResumeUrl,
                                AppliedAt = app.AppliedAt,
                                CoverLetter = app.CoverLetterURL,
                                Status = app.Status
                            };

                var result = await query.ToListAsync();
                return result;

            }
            catch (Exception ex)
            {
                // Throwing the exact exception so you can see it in your console
                throw;
            }
        }
    }


}
