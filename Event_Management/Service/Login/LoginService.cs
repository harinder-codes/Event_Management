using Event_Management.Common;
using Event_Management.Models;
using Event_Management.Repository.Login;
using Event_Management.Service.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Event_Management.Service
{
	public class LoginService : ILoginService

    {
        private readonly ILoginRepository _loginRepository;
     
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<UserLoginResponse> Login(string Email, string Password)
        {
            UserLoginResponse service = new UserLoginResponse();
            UserModel adminModel = new UserModel();
            service.adminModel = adminModel;
            try
            {
                var result =  _loginRepository.Login(Email);
                if (result != null)
                {
                    if (result.Result == 1)
                    {

                        var DecryptPassword = EncryptDecrypt.Decrypt(result.Password);
                        if (DecryptPassword != Password)
                        {
                            service.adminModel = new UserModel();
                            service.ReturnCode = -2;
                            service.Message = "Please enter Correct Password";
                            return service;
                        }
                        adminModel.UserID = result.UserID;
                        adminModel.FirstName = result.FirstName;
                        adminModel.LastName = result.LastName;
                        adminModel.Username = result.Username;
                        adminModel.UserRole = result.UserRole;
                        adminModel.Email = result.Email;
                        service.ReturnCode = result.Result;
                        service.Message = "Logged in Successfully.";
                        service.adminModel = adminModel;
                    }

                    if (adminModel?.Active == 0)
                    {

                        service.ReturnCode = -2;
                        service.Message = "Account is In-Active please contact to Administrator.";
                        service.adminModel = new UserModel();
                        return service;
                    }
                    else if (result.Result == -2)
                    {
                        service.ReturnCode = -2;
                        service.Message = "Email not exists";
                        service.adminModel = new UserModel();
                        return service;
                    }
                    else if (result.Result == -1)
                    {
                        service.ReturnCode = -1;
                        service.Message = "Technical error!";
                        service.adminModel = new UserModel();
                        return service;
                    }

                }

            }
            catch (Exception ex)
            {
                service.ReturnCode = -1;
                service.Message = "Technical error!";
            }
            return service;
        }
        public CommonResult Signup(string FirstName, string LastName, string Email, string Password)
        {
            CommonResult Result = new CommonResult();
            try
            {
                var EncryptPassword = EncryptDecrypt.Encrypt(Password);
                var result = _loginRepository.Signup(FirstName, LastName, Email, EncryptPassword);

                if (result == 1)
                {
                    Result.ReturnCode = result;
                    Result.Message = "Account Created Successfully.";
                }
                else if (result == -2)
                {
                    Result.ReturnCode = -2;
                    Result.Message = "Email already exists";
                }
                else if (result == -1)
                {
                    Result.ReturnCode = -1;
                    Result.Message = "Technical error!";
                }
            }
            catch (Exception ex)
            {
                Result.ReturnCode = -1;
                Result.Message = "Technical error!";
            }
            return Result;
        }
    }
}