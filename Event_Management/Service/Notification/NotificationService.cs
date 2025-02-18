using Event_Management.Models;
using Event_Management.Repository.Admin;
using Event_Management.Repository.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event_Management.Service.Notification
{
	public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public List<UserNotificationModel> GetUnreadNotifications()
        {
            return _notificationRepository.GetUnreadNotifications();
        }
        public int ClearAllUserNotification()
        {
            return _notificationRepository.ClearAllUserNotification();
        }

       

    }
}