namespace Staffing_Recruting_API.Model
{
    public class Company
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Industry_Type { get; set; }

        public string Location { get; set; }

        public string Website { get; set; }
    }

    public class AddCompanyDTO
    {
        public string Name { get; set; }
        public string Industry_Type { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
    }

    public class GetCompanyDTO
    {
        public string Name { get; set; }
        public string Industry_Type { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
    }
}

