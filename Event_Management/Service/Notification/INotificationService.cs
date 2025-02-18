using Event_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Service.Notification
{
   public interface INotificationService
    {
        List<UserNotificationModel> GetUnreadNotifications();
        int ClearAllUserNotification();
    }
}
