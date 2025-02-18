using Event_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Repository.User
{
    public interface IUserRepository
    {
        List<UserEventResult> GetEventList();
        UserEventResult GetEventDetail(int EventID);
        int EnrollEvent(int EventID);
        int CancelEnrollment(int EventID);
    }
}
