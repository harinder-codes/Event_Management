using Event_Management.Common;
using Event_Management.Models;
using Event_Management.Repository.Admin;
using Event_Management.Repository.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_Management.Service.Admin
{
	public class AdminService: IAdminService
    {

        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public AdminEventResponse GetEventList()
        {
            AdminEventResponse serviceResponse = new AdminEventResponse();
            try
            {
                var result =  _adminRepository.GetEventList();
                int? EventResult = result?.FirstOrDefault()?.Result;
                if (result != null && EventResult == 1)
                {
                    serviceResponse.EventList = result.Select(d => new AdminEventModel
                    {
                        EventID= d.EventID,
                        EventDate = CommonFunction.ConvertDateTimeToDateString(d.EventDate),
                        EventTime = CommonFunction.ConvertTimeSpanToTimeString (d.EventTime),
                        Title = d.Title,
                        EventDescription = d.EventDescription,
                        Location = d.Location,
                        TotalSeats = d.TotalSeats,
                        AvailableSeats = d.AvailableSeats,
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
        public AdminUserResponse GetUserList()
        {
            AdminUserResponse serviceResponse = new AdminUserResponse();
            try
            {
                var result =  _adminRepository.GetUserList();
                int? EventResult = result?.FirstOrDefault()?.Result;
                if (result != null && EventResult == 1)
                {
                    serviceResponse.UserList = result.Select(d => new UserModel
                    {
                        UserID= d.UserID,
                        UserRole = d.UserRole,
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        Email = d.Email,
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
        public List<UserModel> GetEnrolledUserList(int EventID)
        {
            List<UserModel> UserList = new List<UserModel>();
            try
            {
                var result =  _adminRepository.GetEnrolledUserList(EventID);
                int? EventResult = result?.FirstOrDefault()?.Result;
                if (result != null && EventResult == 1)
                {
                   UserList = result.Select(d => new UserModel
                    {
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        Email = d.Email,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return UserList;
        }
        public  CommonResult EditUserRole(int UserID, int UserRole)
        {
            CommonResult Result = new CommonResult();
            try
            {
                var result =  _adminRepository.EditUserRole(UserID,UserRole);

                if (result == 1)
                {
                    Result.ReturnCode = result;
                    Result.Message = "Role updated Successfully.";
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
        public  CommonResult AddNewEvent(string Title, string EventDescription, string EventDate, string EventTime, string Location, int TotalSeats)
        {
            CommonResult Result = new CommonResult();
            try
            {
                DateTime? eventDate = CommonFunction.ConvertStringToDate(EventDate);
                TimeSpan? eventTime = CommonFunction.ConvertStringToTimeSpan(EventTime);
                var result =  _adminRepository.InsertEvent(Title, EventDescription, eventDate, eventTime, Location, TotalSeats);

                if (result == 1)
                {
                    Result.ReturnCode = result;
                    Result.Message = "Event Added Successfully.";
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
        public  CommonResult EditEvent(int EventID, string Title, string EventDescription, string EventDate, string EventTime, string Location, int TotalSeats)
        {
            CommonResult Result = new CommonResult();
            try
            {
                DateTime? eventDate = CommonFunction.ConvertStringToDate(EventDate);
                TimeSpan? eventTime = CommonFunction.ConvertStringToTimeSpan(EventTime);
                var result =  _adminRepository.EditEvent(EventID,Title, EventDescription, eventDate, eventTime, Location, TotalSeats);

                if (result == 1)
                {
                    Result.ReturnCode = result;
                    Result.Message = "Event Updated Successfully.";
                }
                else if (result == -2)
                {
                    Result.ReturnCode = -2;
                    Result.Message = "Event not exists";
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
        public  CommonResult DeleteEvent(int EventID)
        {
            CommonResult Result = new CommonResult();
            try
            {
                var result =  _adminRepository.DeleteEvent(EventID);

                if (result == 1)
                {
                    Result.ReturnCode = result;
                    Result.Message = "Event Deleted Successfully.";
                }
                else if (result == -2)
                {
                    Result.ReturnCode = -2;
                    Result.Message = "Event not exists";
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
        public  CommonResult SendEventNotifications(int EventID)
        {
            CommonResult Result = new CommonResult();
            try
            {
                var result =  _adminRepository.SendEventNotifications(EventID);

                if (result == 1)
                {
                    Result.ReturnCode = result;
                    Result.Message = "Notification Sent Successfully.";
                }
                else if (result == -2)
                {
                    Result.ReturnCode = -2;
                    Result.Message = "Event not exists";
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