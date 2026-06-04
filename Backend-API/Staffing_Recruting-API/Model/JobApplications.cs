using System.ComponentModel.DataAnnotations.Schema;

namespace Staffing_Recruting_API.Model
{
    public class JobApplication
    {
        public int ID { get; set; }
        public required int JobID { get; set; }
        public required int CandidateID { get; set; }
        public string? CoverLetterURL { get; set; }
        public required string Status { get; set; }
        public DateTime AppliedAt { get; set; }
        public DateTime ApplicationUpdateDate { get; set; }
        [ForeignKey("JobID")]
        public virtual Jobs Job { get; set; }


        [ForeignKey("CandidateID")]
        public virtual CandidateProfile CandidateProfile { get; set; }

    }
    public class AddJobApplicationDTO
    {
        public int JobID { get; set; }
        public string? CoverLetterURL { get; set; }
    }

    public class ApplicantProfileDTO
    {
        public int JobID { get; set; }
        public int UserID { get; set; }

        public int ApplicationID { get; set; }
        public required string FullName { get; set; }
        public string? Email { get; set; }
        public required string ProfessionalTitle { get; set; }
        public required string Bio { get; set; }
        public required string Skills { get; set; }
        public required string Experience { get; set; }
        public required string Education { get; set; }
        public required string LinkedInUrl { get; set; }
        public string? GithubUrl { get; set; }
        public string? ResumeUrl { get; set; }
        public DateTime AppliedAt { get; set; }
        public string? CoverLetter { get; set; }

        public string Status { get; set; }
    }
}
