using Dapper;
using Event_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using Event_Management.Common;

namespace Event_Management.Repository.User
{
	public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        private int DefaultDBTimeout = 1800;
        public UserRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
        public List<UserEventResult> GetEventList()
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@UserID", CommonFunction.UserID);
                    var result = conn.Query<UserEventResult>("User_GetEvents", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public UserEventResult GetEventDetail(int EventID)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@EventID", EventID);
                    parm.Add("@UserID", CommonFunction.UserID);
                    var result = conn.Query<UserEventResult>("User_GetEventDetail", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int EnrollEvent(int EventID)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@EventID", EventID);
                    parm.Add("@UserID", CommonFunction.UserID);
                    var result = conn.Query<int>("User_InsertEventEnrollment", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public int CancelEnrollment(int EventID)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@EventID", EventID);
                    parm.Add("@UserID", CommonFunction.UserID);
                    var result = conn.Query<int>("User_CancelEventEnrollment", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
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