using Event_Management.Common;
using Event_Management.Service.Admin;
using Event_Management.Service.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event_Management.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet]
        public JsonResult GetUnread()
        {
            try
            {
                // Get the logged-in user's ID from the session
                int? userId = CommonFunction.UserID;
                if (userId == null)
                {
                    return Json(new { success = false, message = "User not authenticated" }, JsonRequestBehavior.AllowGet);
                }

                // Call the service to get unread notifications
                var notifications = _notificationService.GetUnreadNotifications();

                return Json(notifications, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult ClearAllUserNotification()
        {
            try
            {
                int? userId = CommonFunction.UserID;
                if (userId == null)
                {
                    return Json(new { success = false, message = "User not authenticated" }, JsonRequestBehavior.AllowGet);
                }

                // Call the service to get unread notifications
                var notifications = _notificationService.ClearAllUserNotification();

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}