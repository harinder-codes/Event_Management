using Event_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Repository.Admin
{
   public interface IAdminRepository
    {
        List<AdminEventResult> GetEventList();
        int InsertEvent(string Title, string EventDescription, DateTime? EventDate, TimeSpan? EventTime, string Location, int TotalSeats);
        int EditEvent(int EventID, string Title, string EventDescription, DateTime? EventDate, TimeSpan? EventTime, string Location, int TotalSeats);
        int DeleteEvent(int EventID);
        List<UserLoginModel_Result> GetUserList();
        int EditUserRole(int UserID, int UserRole);
        int SendEventNotifications(int EventID);
        List<UserLoginModel_Result> GetEnrolledUserList(int EventID);
    }
}
