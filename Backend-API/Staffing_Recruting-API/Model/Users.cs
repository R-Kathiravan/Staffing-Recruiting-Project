namespace Staffing_Recruting_API.Model
{
    public class Users
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }

    }


    public class GetUserDTO
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }

    public class AddUserDTO
    {

        public required string UserName { get; set; }

        public required string FullName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string Role { get; set; }
    }

    public class CheckUserDTO
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }

    }
}