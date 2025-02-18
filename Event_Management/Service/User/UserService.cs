using Event_Management.Common;
using Event_Management.Models;
using Event_Management.Repository.User;
using System;
using System.Linq;


namespace Event_Management.Service.User
{
	public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserEventResponse GetEventList()
        {
            UserEventResponse serviceResponse = new UserEventResponse();
            try
            {
                var result = _userRepository.GetEventList();
                int? EventResult = result?.FirstOrDefault().Result;
                if (result != null && EventResult == 1)
                {
                    serviceResponse.EventList = result.Select(d => new UserEventModel
                    {
                        EventID = d.EventID,
                        EventDate = CommonFunction.ConvertDateTimeToDateString(d.EventDate) +" "+ CommonFunction.ConvertTimeSpanToTimeString(d.EventTime),
                        Title = d.Title,
                        EventDescription = d.EventDescription,
                        Location = d.Location,
                        TotalSeats = d.TotalSeats,
                        AvailableSeats = d.AvailableSeats,
                        EventEnrolled = d.EventEnrolled,
                    }).ToList();
                    serviceResponse.ReturnCode = 1;
                    serviceResponse.ReturnMessage = "Fetch Successfuly.";
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return serviceResponse;
        }
        public UserEventModel GetEventDetail(int EventID)
        {
          
            UserEventModel EventDetail = new UserEventModel();
            try
            {
                var result = _userRepository.GetEventDetail(EventID);
                int? EventResult = result?.Result;
                if (result != null && EventResult == 1)
                {
                    EventDetail.EventID = result.EventID;
                    EventDetail.EventDate = CommonFunction.ConvertDateTimeToDateString(result.EventDate);
                    EventDetail.EventTime = CommonFunction.ConvertTimeSpanToTimeString(result.EventTime);
                    EventDetail.Title = result.Title;
                    EventDetail.EventDescription = result.EventDescription;
                    EventDetail.Location = result.Location;
                    EventDetail.TotalSeats = result.TotalSeats;
                    EventDetail.AvailableSeats =result.AvailableSeats;
                    EventDetail.EventEnrolled =result.EventEnrolled;
                }
                return EventDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public CommonResult EnrollEvent(int EventID)
        {
            CommonResult Result = new CommonResult();
            try
            {
                var result = _userRepository.EnrollEvent(EventID);

                if (result == 1)
                {
                    Result.ReturnCode = result;
                    Result.Message = "Event Enrolled Successfully.";
                }
                else if (result == -2)
                {
                    Result.ReturnCode = -2;
                    Result.Message = "Event Already Enrolled";
                }
                else if (result == -1)
                {
                    Result.ReturnCode = -1;
                    Result.Message = "Technical error!";
                }
            }
            catch (Exception ex)
            {
                Result.ReturnCode = -1;
                Result.Message = "Technical error!";
            }
            return Result;
        }
        public CommonResult CancelEnrollment(int EventID)
        {
            CommonResult Result = new CommonResult();
            try
            {
                var result = _userRepository.CancelEnrollment(EventID);

                if (result == 1)
                {
                    Result.ReturnCode = result;
                    Result.Message = "Enrollment canceled successfully";
                }
                else if (result == -2)
                {
                    Result.ReturnCode = -2;
                    Result.Message = "Error: Unable to cancel enrollment.";
                }
                else if (result == -1)
                {
                    Result.ReturnCode = -1;
                    Result.Message = "Technical error!";
                }
            }
            catch (Exception ex)
            {
                Result.ReturnCode = -1;
                Result.Message = "Technical error!";
            }
            return Result;
        }

    }
}