using DAL.Data;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;
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
        }

        public async Task AddToNotification(string username)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, username);
        }

        public Task SendMessageToGroup(Guid group, string message, string username, string image)
        {
            var filter = Builders<ChatRoom>.Filter.Eq(s => s.TopicsId, group.ToString());

            var dateTime = DateTime.Now;
            
            var chatMessage = new ChatMessage()
            {
                Message = message,
                Username = username,
                CreatedDate = dateTime,
                Image = image
            };

            var update = Builders<ChatRoom>.Update.Push(s => s.ChatMessages, chatMessage);

            _chatroom.UpdateOne(filter, update);

            return Clients.Group(group.ToString()).SendAsync("ReceiveMessage", message, username, image, dateTime.ToString("O"), chatMessage.Id.ToString());
        }


        public Task DeleteMessageToGroup(Guid group, string username, string message,
                                                DateTime dateTime, string id, string image, string highlisted)
        {
            var filter = Builders<ChatRoom>.Filter.Eq(s => s.TopicsId, group.ToString());

            var chatMessage = new ChatMessage()
            {
                Username = username,
                Message = message,
                Highlighted = highlisted,
                Image = image,
                CreatedDate = dateTime,
                Id = ObjectId.Parse(id)
            };

            var update = Builders<ChatRoom>.Update.Pull(s => s.ChatMessages, chatMessage);

            _chatroom.UpdateOne(filter, update);

            return Clients.Group(group.ToString()).SendAsync("DeleteMessage", username, dateTime.ToString("O"));
        }


        //public Task MessageNotification(Guid group, string name,Guid chapterId)
        //{
        //    return Clients.Group(group.ToString()).SendAsync("Notification", name, chapterId.ToString());
        //}
    }
}