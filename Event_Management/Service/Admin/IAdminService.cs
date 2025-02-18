using Event_Management.Models;
using System.Collections.Generic;

namespace Event_Management.Service.Admin
{
    public interface IAdminService
    {
        AdminEventResponse GetEventList();
        CommonResult AddNewEvent(string Title, string EventDescription, string EventDate, string EventTime, string Location, int TotalSeats);
        CommonResult EditEvent(int EventID, string Title, string EventDescription, string EventDate, string EventTime, string Location, int TotalSeats);
        CommonResult DeleteEvent(int EventID);
        AdminUserResponse GetUserList();
        CommonResult EditUserRole(int UserID, int UserRole);
        CommonResult SendEventNotifications(int EventID);
        List<UserModel> GetEnrolledUserList(int EventID);
    }
}
