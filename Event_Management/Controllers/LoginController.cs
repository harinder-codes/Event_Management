using Event_Management.Models;
using Event_Management.Repository.Login;
using Event_Management.Service.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event_Management.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(LoginRequest request)
        {

            var Result = _loginService.Login(request.Email, request.Password).Result;
            if (Result.ReturnCode != 1)
            {
                TempData["ReturnCode"] = Result.ReturnCode;
                TempData["Message"] = Result.Message;
                return View();
            }
            else if (Result.ReturnCode == 1)
            {
                Session["UserID"] = Result.adminModel.UserID;
                Session["UserRole"] = Result.adminModel.UserRole;
                Session["FirstName"] = Result.adminModel.FirstName;
                Session["LastName"] = Result.adminModel.LastName;
                Session["Email"] = Result.adminModel.Email;
                if (Result?.adminModel?.UserRole==1)
                { 
                    return RedirectToAction("EventList", "Admin");
                }
                else
                {
                    return RedirectToAction("EventList", "User");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(SignupRequest request)
        {
              var Result = _loginService.Signup(request.FirstName,request.LastName,request.Email, request.Password);

            return Json(new { ReturnCode = Result.ReturnCode });
        }
    }
}