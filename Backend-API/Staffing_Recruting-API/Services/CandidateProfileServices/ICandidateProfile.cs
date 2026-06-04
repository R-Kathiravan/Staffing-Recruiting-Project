using Staffing_Recruting_API.Model;

namespace Staffing_Recruting_API.Services.CandidateProfileServices
{
    public interface ICandidateProfile
    {
        Task<bool> CreateCandidateProfile(AddCandidateProfile addCandidateProfile, int candidateID);

        //Task<bool> UpdateCandidateProfileAsync(AddCandidateProfile updateCandidateProfile);

        //Task<IEnumerable<CandidateProfile>> GetCandidateProfilesAsync(int num);
        Task<GetCandidateProfile> GetCandidateProfile(int candidateID);
        Task<GetCandidateResume> GetCandidateResume(int num);
    }
}
