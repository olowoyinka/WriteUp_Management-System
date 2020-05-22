using System;
using System.Collections.Generic;

namespace EndPoint.Response.ViewModelResponse
{
    public class TopicsResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        //public List<InviteeTopicResponse> Invitees { get; set; }

        //public List<ChapterResponse> Chapters { get; set; }
    }


    public class TopicsInviteeResponse
    {
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}