using Event_Management.Models;
using Event_Management.Service.Admin;
using System;
using System.Web.Mvc;

namespace Event_Management.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [SessionExpireAttribute]
        public ActionResult EventList()
        {
            var result = _adminService.GetEventList();
            return View(result);
        }
        [SessionExpireAttribute]
        public ActionResult UserList()
        {
            var result = _adminService.GetUserList();
            return View(result);
        }
        [HttpPost]
        public ActionResult EditUserRole(int UserID, int UserRole)
        {
            int result = 0;
            string msg = "";
            CommonResult Result = new CommonResult();
            try
            {
                Result = _adminService.EditUserRole(UserID,UserRole);
                result = Result.ReturnCode;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                Result.ReturnCode = -1;
            }
            return Json(new { data = Result.ReturnCode, Message = Result.Message });
        }
        [HttpGet]
        public ActionResult GetEnrolledUserList(int EventID)
        {
            try
            {
                var Result = _adminService.GetEnrolledUserList(EventID);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult AddNewEvent(string Title, string Description, string Location, int TotalSeats, string EventDate, string EventTime)
        {
            int result = 0;
            string msg = "";
            CommonResult Result = new CommonResult();
            try
            {
                Result = _adminService.AddNewEvent(Title,Description,EventDate,EventTime,Location,TotalSeats);
                result = Result.ReturnCode;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                Result.ReturnCode = -1;
            }
            return Json(new { data = Result.ReturnCode, Message = Result.Message });
        }
        [HttpPost]
        public ActionResult EditEvent(int EventID,string Title, string Description, string Location, int TotalSeats, string EventDate, string EventTime)
        {
            int result = 0;
            string msg = "";
            CommonResult Result = new CommonResult();
            try
            {
                Result = _adminService.EditEvent(EventID,Title, Description,EventDate,EventTime,Location,TotalSeats);
                result = Result.ReturnCode;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                Result.ReturnCode = -1;
            }
            return Json(new { data = Result.ReturnCode, Message = Result.Message });
        }
        [HttpPost]
        public ActionResult DeleteEvent(int EventID)
        {
            int result = 0;
            string msg = "";
            CommonResult Result = new CommonResult();
            try
            {
                Result = _adminService.DeleteEvent(EventID);
                result = Result.ReturnCode;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                Result.ReturnCode = -1;
            }
            return Json(new { data = Result.ReturnCode, Message = Result.Message });
        }
        [HttpPost]
        public ActionResult SendEventNotifications(int EventID)
        {
            int result = 0;
            string msg = "";
            CommonResult Result = new CommonResult();
            try
            {
                Result = _adminService.SendEventNotifications(EventID);
                result = Result.ReturnCode;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                Result.ReturnCode = -1;
            }
            return Json(new { data = Result.ReturnCode, Message = Result.Message });
        }
    }
}