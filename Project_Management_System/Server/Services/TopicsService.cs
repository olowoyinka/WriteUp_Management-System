using DAL.Data;
using EndPoint.Request.ViewModelRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MongoDB.Driver;
using Project_Management_System.Server.Interfaces;
using Project_Management_System.Shared.Models.ChatModels;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Services
{
    public class TopicsService : ITopics
    {
        private readonly ApplicationDbContext _context;

        private readonly IMongoCollection<ChatRoom> _chatroom;

        public TopicsService(ApplicationDbContext context,
            IChatRoomDatabaseSettings settings)
        {
            _context = context;

            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.DatabaseName);

            _chatroom = database.GetCollection<ChatRoom>(settings.ChatRoomsCollectionName);
        }

        public async Task<bool> CreateAsync(TopicsRequest topicsRequest, string GetUserId)
        {
            var topicsexist = await _context.Topics
                .AnyAsync(s => s.Name.Equals(topicsRequest.Name) && s.AppUserId.Equals(GetUserId));

            if(topicsexist)
            {
                return false;
            }

            var newTopics = new Topics
            {
                Id = Guid.NewGuid(),
                Name = topicsRequest.Name,
                AppUserId = GetUserId,
                CreatedDate = DateTime.Now
            };

            _context.Topics.Add(newTopics);

            var newChapter = new Chapter
            {
                Id = Guid.NewGuid(),
                Name = "Welcome",
                TopicsId = newTopics.Id,
                CreatedDate = DateTime.Now
            };

            _context.Chapters.Add(newChapter);

            var newChatRoom = new ChatRoom
            {
                Name = newTopics.Name,
                CreatedDate = DateTime.Now,
                TopicsId = newTopics.Id.ToString(),
                ChatMessages = new ChatMessage [] {}
            };

            await _chatroom.InsertOneAsync(newChatRoom);

            var created = await _context.SaveChangesAsync();

            return created > 0;
        }

        public async Task<Topics> GetByIdAsync(Guid Id, string GetUserId)
        {
            return await _context.Topics
                            .Where(x => x.Id.Equals(Id))
                            .Where(x => x.AppUserId.Equals(GetUserId))
                            //.Where(x => x.AppUserId.Equals(GetUserId) || x.Invitees.Any(s => s.AppUserId == GetUserId))
                            .Include(s => s.Invitees)
                                .ThenInclude(s => s.AppUser)
                            .Include(m => m.Chapters)
                            .SingleOrDefaultAsync();
        }

        public async Task<bool> DeleteAsync(Guid Id, string GetUserId)
        {
            var topics = await GetByIdAsync(Id, GetUserId);

            if (topics == null)
                return false;

            await _chatroom.DeleteOneAsync(book => book.TopicsId == topics.Id.ToString());

            _context.Topics.Remove(topics);

            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }

        public IQueryable<Topics> GetAllAsync(string GetUserId, string name)
        {
            var queryable = _context.Topics
                            .Where(x => x.AppUserId.Equals(GetUserId))
                            .Include(s => s.Invitees)
                                .ThenInclude(s => s.AppUser)
                            .Include(x => x.Chapters)
                            .OrderByDescending(d => d.CreatedDate)
                            .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                queryable = queryable.Where(x => x.Name.Contains(name));
            }

            return queryable;
        }

        public async Task<bool> UpdateAsync(Guid Id, TopicsRequest topicsRequest, string GetUserId)
        {
            var topicsexist = await _context.Topics
                .AnyAsync(s => s.Name.Equals(topicsRequest.Name) && s.AppUserId.Equals(GetUserId));

            if (topicsexist)
            {
                return false;
            }

            var topics = await GetByIdAsync(Id, GetUserId);

            if (topics == null)
            {
                return false;
            }

            topics.Name = topicsRequest.Name;

            _context.Topics.Update(topics);

            var filter = Builders<ChatRoom>.Filter.Eq(s => s.TopicsId, topics.Id.ToString());

            var update = Builders<ChatRoom>.Update.Set(s => s.Name, topics.Name);

            await _chatroom.UpdateOneAsync(filter, update);

            var created = await _context.SaveChangesAsync();

            return created > 0;
        }
    }
}