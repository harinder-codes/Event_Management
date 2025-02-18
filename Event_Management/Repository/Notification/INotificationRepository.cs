using Event_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Repository.Notification
{
    public interface INotificationRepository
    {
        List<UserNotificationModel> GetUnreadNotifications();
        int ClearAllUserNotification();
    }
}
