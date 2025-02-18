using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event_Management.Models
{
	public class AdminEventModel
    {
        public int EventID { get; set; }
        public string Title { get; set; }
        public string EventDescription { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public string Location { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
    }
    public class AdminEventResult
    {
        public int EventID { get; set; }
        public string Title { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public string Location { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public int Result { get; set; }
    }
    public class AdminEventResponse
    {
        public int ReturnCode { get; set; } //-1:Error/0:missing or validation /1:success
        public string ReturnMessage { get; set; } // error message/any return messaage
        public List<AdminEventModel> EventList { get; set; }
    }
}