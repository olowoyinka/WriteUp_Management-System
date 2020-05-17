using DAL.Data;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver;
using Project_Management_System.Shared.Models.ChatModels;
using System;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Hubs
{
    public class ChatRoomHub : Hub
    {
        private readonly IMongoCollection<ChatRoom> _chatroom;

        public ChatRoomHub(IChatRoomDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.DatabaseName);

            _chatroom = database.GetCollection<ChatRoom>(settings.ChatRoomsCollectionName);
        }

        public Task SendMessageToGroup(Guid group, ChatRoom message)
        {
            var filter = Builders<ChatRoom>.Filter.Eq(s => s.TopicsId, group.ToString());

            var update = Builders<ChatRoom>.Update
                            .AddToSetEach(s => s.ChatMessages, message.ChatMessages);

            _chatroom.UpdateOneAsync(filter, update);

            return Clients.Group(group.ToString()).SendAsync("ReceiveMessage", message.ChatMessages);
        }
    }
}