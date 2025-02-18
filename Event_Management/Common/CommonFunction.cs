

using System;
using System.Web;

namespace Event_Management.Common
{
	public static class CommonFunction
	{

        public static string ConvertDateTimeToDateString(DateTime? dateTime)
        {
            if (dateTime == null)
                return "N/A"; 

            return dateTime.Value.ToString("yyyy-MM-dd"); 
        }
        public static string ConvertTimeSpanToTimeString(TimeSpan? timeSpan)
        {
            if (timeSpan == null)
                return "N/A"; // Handle null values

            // Convert TimeSpan to DateTime (base date doesn't matter)
            DateTime time = DateTime.Today.Add(timeSpan.Value);

            return time.ToString("hh:mm tt"); // Format: 12-hour with AM/PM
        }
        public static DateTime? ConvertStringToDate(string dateString)
        {
            if (string.IsNullOrWhiteSpace(dateString))
                return null; // Handle empty input by returning null

            string[] formats = { "MM/dd/yyyy", "dd-MM-yyyy", "yyyy-MM-dd", "dd/MM/yyyy" };

            if (DateTime.TryParseExact(dateString, formats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime parsedDate))
            {
                return parsedDate; // Return DateTime object
            }

            return null; // Return null if conversion fails
        }
        public static TimeSpan? ConvertStringToTimeSpan(string timeString)
        {
            if (string.IsNullOrWhiteSpace(timeString))
                return null; // Handle empty input by returning null

            if (DateTime.TryParseExact(timeString, "hh:mm tt",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime parsedTime))
            {
                return parsedTime.TimeOfDay; // Convert DateTime to TimeSpan
            }

            return null; // Return null if conversion fails
        }
        public static string FirstName
        {
            get { return (HttpContext.Current.Session["FirstName"] != null ? HttpContext.Current.Session["FirstName"].ToString() : ""); }
        }
        public static string LastName
        {
            get { return (HttpContext.Current.Session["LastName"] != null ? HttpContext.Current.Session["LastName"].ToString() : ""); }
        }
        public static string Email
        {
            get { return (HttpContext.Current.Session["Email"] != null ? HttpContext.Current.Session["Email"].ToString() : ""); }
        }
        public static int UserRole
        {
            get { return (HttpContext.Current.Session["UserRole"] != null ? Convert.ToInt16(HttpContext.Current.Session["UserRole"].ToString()) : 0); }
        }
        public static int UserID
        {
            get { return (HttpContext.Current.Session["UserID"] != null ? Convert.ToInt16(HttpContext.Current.Session["UserID"].ToString()) : 0); }
        }

    }
}