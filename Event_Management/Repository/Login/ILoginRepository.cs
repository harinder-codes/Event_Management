using Event_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Repository.Login
{
    public interface ILoginRepository
    {
        UserLoginModel_Result Login(string Email);
        int Signup(string FirstName, string LastName, string Email, string Password);
    }
}
