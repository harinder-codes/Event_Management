using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event_Management.Models
{
	
    public class AdminUserResponse
    {
        public int ReturnCode { get; set; } 
        public string ReturnMessage { get; set; } 
        public List<UserModel> UserList { get; set; }
    }
}