namespace Staffing_Recruting_API.Model
{
    public class Jobs
    {
        public int id { get; set; }

        public string JobName { get; set; }
        public string JobDescription { get; set; }

        public DateTime UploadedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string UploadedBy { get; set; }

        public decimal Salary { get; set; }

    }
}
