using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace EndPoint.Response.ViewModelResponse
{
    public class ChatRoomResponse
    {
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public IEnumerable<ChatMessageResponse> ChatMessages { get; set; }
    }


    public class ChatMessageResponse
    {
        public ObjectId Id { get; set; }

        public string Username { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public string URL { get; set; }

        public string Highlighted { get; set; }
    }
}