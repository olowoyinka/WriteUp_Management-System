using EndPoint.Response.UserResponse;
using System;

namespace EndPoint.Response.ViewModelResponse
{
    public class InviteeResponse
    {
        public bool RoleStatus { get; set; }

        public bool RequestStatus { get; set; }

        public DateTime AcceptedDate { get; set; }

        public UsernameResponse AppUser { get; set; }

        public TopicsInviteeResponse Topics { get; set; }
    }

    public class InviteeTopicResponse
    {
        public bool RoleStatus { get; set; }

        public bool RequestStatus { get; set; }

        public DateTime AcceptedDate { get; set; }

        public UsernameResponse AppUser { get; set; }
    }
}