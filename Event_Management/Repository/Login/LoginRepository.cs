using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Event_Management.Models;

namespace Event_Management.Repository.Login
{
	public class LoginRepository : ILoginRepository
    {
        private readonly string _connectionString;
        private int DefaultDBTimeout = 1800;
        public LoginRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
        public UserLoginModel_Result Login(string Email)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@Email", Email);
                    var result =  conn.Query<UserLoginModel_Result>("Get_LoginUser", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int Signup(string FirstName, string LastName, string Email, string Password)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@FirstName", FirstName);
                    parm.Add("@LastName", LastName);
                    parm.Add("@Password", Password);
                    parm.Add("@Email", Email);
                    var result =  conn.Query<int>("AddNewUser", parm, commandType: CommandType.StoredProcedure, commandTimeout: DefaultDBTimeout);
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