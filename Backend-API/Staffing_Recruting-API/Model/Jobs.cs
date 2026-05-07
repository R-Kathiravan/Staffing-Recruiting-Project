namespace Staffing_Recruting_API.Model
{
    public class Jobs
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Company_ID { get; set; }

        public string Recruiter { get; set; }

        public decimal Salary { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class GetJobs
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Company_ID { get; set; }

        public string Recruiter { get; set; }

        public decimal Salary { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class AddJobsDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public required string Company_ID { get; set; }
        public required string Recruiter { get; set; }
        public required decimal Salary { get; set; }
        public required string Status { get; set; }
    }

}