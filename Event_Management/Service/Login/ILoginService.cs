using Event_Management.Models;
using System.Threading.Tasks;

namespace Event_Management.Service.Login
{
    public interface ILoginService
    {
        Task<UserLoginResponse> Login(string Email, string Password);
        CommonResult Signup(string FirstName, string LastName, string Email, string Password);
    }
}
