using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Project_Management_System.Shared.Models.ChatModels
{
    public class ChatMessage
    {
        [BsonId]
        [JsonConverter(typeof(StringToObjectId))]
        public ObjectId Id { get; set; }

        public string Username { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string Image { get; set; }

        public string Highlighted { get; set; }

        public ChatMessage()
        {
            Id = ObjectId.GenerateNewId();
        }
    }

    public class StringToObjectId : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(ObjectId);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            return ObjectId.Parse(token.ToObject<string>());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }

}