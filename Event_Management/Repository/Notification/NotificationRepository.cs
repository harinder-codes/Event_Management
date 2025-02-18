using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Event_Management.Models;
using Event_Management.Common;

namespace Event_Management.Repository.Notification
{
	public class NotificationRepository : INotificationRepository
    {
        private readonly string _connectionString;
        private int DefaultDBTimeout = 1800;
        public NotificationRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
        public List<UserNotificationModel> GetUnreadNotifications()
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@UserID", CommonFunction.UserID);

                    var result = conn.Query<UserNotificationModel>(
                        "Get_UnreadNotifications",
                        parm,
                        commandType: CommandType.StoredProcedure,
                        commandTimeout: DefaultDBTimeout
                    ).ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                return new List<UserNotificationModel>();
            }
        }
        public int ClearAllUserNotification()
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@UserID", CommonFunction.UserID);
                    var result = conn.Query<int>("User_ClearAllNotification", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
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