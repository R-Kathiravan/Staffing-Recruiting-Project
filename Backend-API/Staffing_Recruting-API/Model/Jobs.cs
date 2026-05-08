namespace Staffing_Recruting_API.Model
{
    public class Jobs
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Recruiter_ID { get; set; }

        public decimal From_Salary { get; set; }

        public decimal To_Salary { get; set; }

        public string SalaryType { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class GetJobs
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Recruiter_ID { get; set; }

        public decimal From_Salary { get; set; }

        public decimal To_Salary { get; set; }

        public string SalaryType { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class AddJobsDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public decimal From_Salary { get; set; }

        public decimal To_Salary { get; set; }

        public string SalaryType { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}