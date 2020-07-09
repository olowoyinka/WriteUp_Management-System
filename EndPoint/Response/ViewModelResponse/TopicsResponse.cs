using EndPoint.Response.UserResponse;
using System;

namespace EndPoint.Response.ViewModelResponse
{
    public class TopicsResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public SingleUsernameResponse SingleUsernameResponse { get; set; }

        //public List<InviteeTopicResponse> Invitees { get; set; }

        //public List<ChapterResponse> Chapters { get; set; }
    }


    public class TopicsInviteeResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}