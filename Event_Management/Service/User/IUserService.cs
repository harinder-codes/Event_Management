using Event_Management.Models;

namespace Event_Management.Service.User
{
	public interface IUserService
	{
        UserEventResponse GetEventList();
        UserEventModel GetEventDetail(int EventID);
        CommonResult EnrollEvent(int EventID);
        CommonResult CancelEnrollment(int EventID);
    }
}