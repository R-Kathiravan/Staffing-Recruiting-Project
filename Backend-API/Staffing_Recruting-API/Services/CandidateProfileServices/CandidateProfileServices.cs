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
                var existingProfile = await _appDbContext.CandidateProfile
          .FirstOrDefaultAsync(x => x.UserID == candidateID);
                if (existingProfile == null)
                {
                    var result = new CandidateProfile
                    {
                        UserID = candidateID,
                        FirstName = addCandidate.FirstName,
                        LastName = addCandidate.LastName,
                        ProfessionalTitle = addCandidate.ProfessionalTitle,
                        Bio = addCandidate.Bio,
                        Skills = addCandidate.Skills,
                        Experience = addCandidate.Experience,
                        Education = addCandidate.Education,
                        LinkedInUrl = addCandidate.LinkedInUrl,
                        GitHubUrl = addCandidate.GithubUrl,
                        ResumeUrl = addCandidate.ResumeUrl,
                        LastUpdatedAt = DateTime.Now
                    };

                    _appDbContext.CandidateProfile.Add(result);
                }
                else
                {
                    existingProfile.FirstName = addCandidate.FirstName;
                    existingProfile.LastName = addCandidate.LastName;
                    existingProfile.ProfessionalTitle = addCandidate.ProfessionalTitle;
                    existingProfile.Bio = addCandidate.Bio;
                    existingProfile.Skills = addCandidate.Skills;
                    existingProfile.Experience = addCandidate.Experience; // Typo fixed!
                    existingProfile.Education = addCandidate.Education;
                    existingProfile.LinkedInUrl = addCandidate.LinkedInUrl;
                    existingProfile.GitHubUrl = addCandidate.GithubUrl;
                    existingProfile.ResumeUrl = addCandidate.ResumeUrl;
                    existingProfile.LastUpdatedAt = DateTime.UtcNow;

                    _appDbContext.CandidateProfile.Update(existingProfile);
                }
                _appDbContext.SaveChanges();
                return true;

            }
            catch
            {
                return false;

            }
        }
        public async Task<GetCandidateProfile> GetCandidateProfile(int num)
        {
            try
            {
                var result = await (
                    from profile in _appDbContext.CandidateProfile

                    join user in _appDbContext.Users
                    on profile.UserID equals user.ID

                    where profile.UserID == num

                    select new GetCandidateProfile
                    {
                        ID = profile.ID,
                        UserID = profile.UserID,
                        FirstName = profile.FirstName,
                        LastName = profile.LastName,
                        ProfessionalTitle = profile.ProfessionalTitle,
                        Bio = profile.Bio,
                        Skills = profile.Skills,
                        Experience = profile.Experience,
                        Education = profile.Education,
                        LinkedInUrl = profile.LinkedInUrl,
                        GithubUrl = profile.GitHubUrl,
                        ResumeUrl = profile.ResumeUrl,
                        LastUpdatedAt = profile.LastUpdatedAt,

                        Email = user.Email,
                        UserName = user.UserName
                    }
                ).FirstOrDefaultAsync();

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<GetCandidateResume> GetCandidateResume(int num)
        {
            try
            {
                var result = await _appDbContext.CandidateProfile
                    .Where(x => x.UserID == num)
                    .Select(x => new GetCandidateResume
                    {
                        ResumeUrl = x.ResumeUrl
                    })
                    .FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}