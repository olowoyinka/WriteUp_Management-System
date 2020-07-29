using EndPoint.Response.UserResponse;
using System;

namespace EndPoint.Response.ViewModelResponse
{
    public class NotificationResponse
    {
        public Guid Id { get; set; }

        public string NotificationMessage { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public Guid Url { get; set; }

        public bool ReadStatus { get; set; }

        public SingleUsernameResponse SingleUsernameResponse { get; set; }
    }
}