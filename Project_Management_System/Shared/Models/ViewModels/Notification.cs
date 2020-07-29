using Project_Management_System.Shared.Models.UserModel;
using System;

namespace Project_Management_System.Shared.Models.ViewModels
{
    public class Notification
    {
        public Guid Id { get; set; }

        public string NotificationMessage { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public Guid Url { get; set; }

        public bool ReadStatus { get; set; }

        public string AppUserId { get; set; }
        
        public AppUser AppUser { get; set; }
    }
}