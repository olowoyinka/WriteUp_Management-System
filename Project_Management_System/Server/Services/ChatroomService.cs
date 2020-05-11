using DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Project_Management_System.Server.Hubs;
using Project_Management_System.Server.Interfaces;
using Project_Management_System.Shared.Models.ChatModels;
using Project_Management_System.Shared.Models.UserModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Services
{
    public class ChatroomService : IChatroom
    {
        private readonly ApplicationDbContext _context;

        private readonly IHubContext<ChatRoomHub> _hubContext;

        private readonly IMongoCollection<ChatRoom> _chatroom;

        private readonly UserManager<AppUser> _userManager;

        public ChatroomService(ApplicationDbContext context,
                            IHubContext<ChatRoomHub> hubContext,
                            IChatRoomDatabaseSettings settings,
                            UserManager<AppUser> userManager)
        {
            _context = context;

            _hubContext = hubContext;

            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.DatabaseName);

            _chatroom = database.GetCollection<ChatRoom>(settings.ChatRoomsCollectionName);

            _userManager = userManager;
        }

        public async Task<ChatRoom> GetChatroomIdAsync(string GetUserId, Guid TopicsId)
        {
            var topicOwn = await _context.Topics
                    .Include(s => s.Invitees)
                    .AnyAsync(x => x.Id.Equals(TopicsId) && (
                                        x.AppUserId.Equals(GetUserId) ||
                                        x.Invitees.Any(r => r.AppUserId.Equals(GetUserId) && r.RequestStatus.Equals(true))
                    ));
             
            if (!topicOwn)
            {
                return null;
            }

            var user = await _userManager.Users.SingleOrDefaultAsync(s => s.Id == GetUserId);

            await _hubContext.Groups.AddToGroupAsync(user.UserName, TopicsId.ToString());

            await _hubContext.Clients.Group(TopicsId.ToString()).SendAsync("Send", $"{user.UserName} was online at { DateTime.Now }");

            return await _chatroom.Find<ChatRoom>(book => book.TopicsId == TopicsId.ToString()).FirstOrDefaultAsync();
        }
    }
}