
namespace Event_Management.Models
{
	
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class SignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class UserModel

    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int UserRole { get; set; }
        public int? Active { get; set; }
    }
    public class UserLoginResponse
    {
        public int ReturnCode { get; set; } //-1:Error/0:missing or validation /1:success
        public string Message { get; set; } // error message/any return messaage
        public UserModel adminModel { get; set; }
    }
    public class UserLoginModel_Result
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Result { get; set; }
        public int UserRole { get; set; }
    }
}