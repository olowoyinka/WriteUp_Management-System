using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project_Management_System.Shared.Models.ChatModels
{
    public class ChatMessage
    {
        [BsonId]
        [JsonConverter(typeof(StringToObjectId))]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("Username")]
        [JsonProperty("Username")]
        [Required]
        public string Username { get; set; }

        [BsonElement("Message")]
        [JsonProperty("Message")]
        [Required]
        public string Message { get; set; }

        [BsonElement("CreatedDate")]
        [JsonProperty("CreatedName")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("URL")]
        [JsonProperty("URL")]
        public string URL { get; set; }

        [BsonElement("Highlighted")]
        [JsonProperty("Highlighted")]
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