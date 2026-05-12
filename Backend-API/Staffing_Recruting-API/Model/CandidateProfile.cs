namespace Staffing_Recruting_API.Model
{
    public class CandidateProfile
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public virtual Users User { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfessionalTitle { get; set; }
        public string Bio { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string ResumeUrl { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
    public class AddCandidateProfile
    {
        public int UserID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string ProfessionalTitle { get; set; }
        public required string Bio { get; set; }
        public required string Skills { get; set; }
        public string? Experience { get; set; }
        public required string Education { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public string? ResumeUrl { get; set; }
    }

    public class GetCandidateProfile
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfessionalTitle { get; set; }
        public string Bio { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string ResumeUrl { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }

}
