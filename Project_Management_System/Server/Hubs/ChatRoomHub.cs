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

        public async Task AddToGroup(Guid groupName, string username)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName.ToString());

            //await Clients.Group(groupName.ToString()).SendAsync("ReceiveMessage", $"{username} is online", "", "", "");
        }

        public Task SendMessageToGroup(Guid group, string message, string username, string image)
        {
            var filter = Builders<ChatRoom>.Filter.Eq(s => s.TopicsId, group.ToString());

            DateTime dateTime = DateTime.Now;
            
            var chatMessage = new ChatMessage()
            {
                Message = message,
                Username = username,
                CreatedDate = dateTime,
                Image = image
            };

            var update = Builders<ChatRoom>.Update.Push(s => s.ChatMessages, chatMessage);

            _chatroom.UpdateOne(filter, update);

            return Clients.Group(group.ToString()).SendAsync("ReceiveMessage", message, username, image, dateTime.ToString("O"));
        }
    }
}