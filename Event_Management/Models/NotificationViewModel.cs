using System;

namespace Event_Management.Models
{
    public class UserNotificationModel
    {
        public int NotificationID { get; set; }
        public int EventID { get; set; }
        public int NotificationType { get; set; }
        public int EventEnrolled { get; set; }
        public string Title { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public DateTime CreatedAt { get; set; }

        // Combine EventDate and EventTime correctly
        public DateTime EventDateTime => EventDate.Add(EventTime);

        // ✅ Return a correctly formatted string
        public string EventDateTimeFormatted => EventDateTime.ToString("yyyy-MM-ddTHH:mm:ss");
        public string CreatedAtFormatted => CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss");
    }

}