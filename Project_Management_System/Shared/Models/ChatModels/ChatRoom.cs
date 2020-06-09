using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Project_Management_System.Shared.Models.ChatModels
{
    public class ChatRoom
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string TopicsId { get; set; }

        public IEnumerable<ChatMessage> ChatMessages { get; set; }
    }
}