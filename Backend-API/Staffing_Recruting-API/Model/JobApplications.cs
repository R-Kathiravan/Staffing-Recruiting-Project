namespace Staffing_Recruting_API.Model
{
    public class JobApplications
    {
        public int ID { get; set; }
        public int JobID { get; set; }
        public int CandidateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ResumeURL { get; set; }
        public string CoverLetterURL { get; set; }
        public string Status { get; set; }
        public DateTime AppliedAt { get; set; }
        public DateTime ApplicationUpdateDate { get; set; }

    }
    public class AddJobApplicationDTO
    {
        public int ID { get; set; }
        public int JobID { get; set; }
        public int CandidateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ResumeURL { get; set; }
        public string CoverLetterURL { get; set; }
        public string Status { get; set; }
    }
}
