using Dapper;
using Event_Management.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Event_Management.Common;

namespace Event_Management.Repository.Admin
{
	public class AdminRepository : IAdminRepository
    {
        private readonly string _connectionString;
        private int DefaultDBTimeout = 1800;
        public AdminRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
        public List<AdminEventResult> GetEventList()
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    var result = conn.Query<AdminEventResult>("Admin_GetEvents", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<UserLoginModel_Result> GetUserList()
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@UserID", CommonFunction.UserID);
                    var result = conn.Query<UserLoginModel_Result>("Admin_GetUsers", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<UserLoginModel_Result> GetEnrolledUserList(int EventID)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@EventID", EventID);
                    var result = conn.Query<UserLoginModel_Result>("Admin_GetEnrolledUserList", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int InsertEvent(string Title, string EventDescription, DateTime? EventDate, TimeSpan? EventTime, string Location, int TotalSeats)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@Title", Title);
                    parm.Add("@EventDescription", EventDescription);
                    parm.Add("@EventDate", EventDate);
                    parm.Add("@EventTime", EventTime);
                    parm.Add("@Location", Location);
                    parm.Add("@TotalSeats", TotalSeats);
                    var result = conn.Query<int>("Admin_CreateUserEvent", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public int EditUserRole(int UserID, int UserRole)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@UserID", UserID);
                    parm.Add("@UserRole", UserRole);
                    var result = conn.Query<int>("Admin_UpdateUserRole", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public int EditEvent(int EventID, string Title, string EventDescription, DateTime? EventDate, TimeSpan? EventTime, string Location, int TotalSeats)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@EventID", EventID);
                    parm.Add("@Title", Title);
                    parm.Add("@EventDescription", EventDescription);
                    parm.Add("@EventDate", EventDate);
                    parm.Add("@EventTime", EventTime);
                    parm.Add("@Location", Location);
                    parm.Add("@TotalSeats", TotalSeats);
                    var result = conn.Query<int>("Admin_EditUserEvent", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public int DeleteEvent(int EventID)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@EventID", EventID);
                    var result = conn.Query<int>("Admin_DeleteUserEvent", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public int SendEventNotifications(int EventID)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@EventID", EventID);
                    var result = conn.Query<int>("Admin_InsertEventNotifications", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}