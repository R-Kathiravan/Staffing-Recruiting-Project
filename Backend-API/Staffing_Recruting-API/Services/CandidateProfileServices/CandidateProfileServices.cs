using Microsoft.EntityFrameworkCore;
using Staffing_Recruting_API.Data;
using Staffing_Recruting_API.Model;

namespace Staffing_Recruting_API.Services.CandidateProfileServices
{
    public class CandidateProfileServices : ICandidateProfile
    {
        private AppDbContext _appDbContext;
        public CandidateProfileServices(AppDbContext appDbContext) { _appDbContext = appDbContext; }

        public async Task<bool> CreateCandidateProfile(AddCandidateProfile addCandidate, int candidateID)
        {
            try
            {
                var result = new CandidateProfile
                {
                    UserID = candidateID,
                    FirstName = addCandidate.FirstName,
                    LastName = addCandidate.LastName,
                    ProfessionalTitle = addCandidate.ProfessionalTitle,
                    Bio = addCandidate.Bio,
                    Skills = addCandidate.Skills,
                    Experience = addCandidate.Skills,
                    Education = addCandidate.Education,
                    LinkedInUrl = addCandidate.LinkedInUrl,
                    GitHubUrl = addCandidate.GitHubUrl,
                    ResumeUrl = addCandidate.ResumeUrl,
                    LastUpdatedAt = DateTime.Now
                };

                _appDbContext.CandidateProfile.Add(result);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;

            }
        }
        public async Task<GetCandidateProfile> GetCandidateProfile(int num)
        {
            try
            {
                var result = await _appDbContext.CandidateProfile
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(x => x.UserID == num);
                if (result != null)
                {
                    return new GetCandidateProfile
                    {
                        ID = result.ID,
                        UserID = result.UserID,
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        ProfessionalTitle = result.ProfessionalTitle,
                        Bio = result.Bio,
                        Skills = result.Skills,
                        Experience = result.Experience,
                        Education = result.Education,
                        LinkedInUrl = result.LinkedInUrl,
                        GitHubUrl = result.GitHubUrl,
                        ResumeUrl = result.ResumeUrl,
                        LastUpdatedAt = result.LastUpdatedAt
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}