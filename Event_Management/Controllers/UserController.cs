using Event_Management.Models;
using Event_Management.Service.Login;
using Event_Management.Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event_Management.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [SessionExpireAttribute]
        public ActionResult EventList()
        {
            var result = _userService.GetEventList();
            return View(result);
        }
        public JsonResult GetEventDetails(int EventID)
        {
            var eventDetails = _userService.GetEventDetail(EventID); 

            if (eventDetails == null)
            {
                return Json(new { success = false, message = "Event not found" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                success = true,
                data = new
                {
                    eventId = eventDetails.EventID,
                    title = eventDetails.Title,
                    description = eventDetails.EventDescription,
                    location = eventDetails.Location,
                    totalSeats = eventDetails.TotalSeats,
                    eventDate = eventDetails.EventDate, 
                    eventTime = eventDetails.EventTime,
                    availableSeats = eventDetails.AvailableSeats,
                    eventEnrolled = eventDetails.EventEnrolled,

                }
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult EnrollEvent(int EventID)
        {
            int result = 0;
            string msg = "";
            CommonResult Result = new CommonResult();
            try
            {
                Result = _userService.EnrollEvent(EventID);
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
        public ActionResult CancelEnrollment(int EventID)
        {
            int result = 0;
            string msg = "";
            CommonResult Result = new CommonResult();
            try
            {
                Result = _userService.CancelEnrollment(EventID);
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