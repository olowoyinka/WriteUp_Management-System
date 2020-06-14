using DAL.Data;
using EndPoint.Request.ViewModelRequest;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Project_Management_System.Server.Hubs;
using Project_Management_System.Server.Interfaces;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Services
{
    public class ChapterService : IChapter
    {
        private readonly ApplicationDbContext _context;

        private readonly IHubContext<ChatRoomHub> _hubContext;

        public ChapterService(ApplicationDbContext context,
                                IHubContext<ChatRoomHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }


        public async Task<bool> CreateAsync(ChapterRequest chapterRequest, string GetUserId, Guid TopicsId)
        {
            var topicOwn = await _context.Topics
                                .Include(s => s.Invitees)
                                .AnyAsync(x => x.Id.Equals(TopicsId) && (
                                                    x.AppUserId.Equals(GetUserId) || 
                                                    x.Invitees.Any(r => r.AppUserId.Equals(GetUserId) && r.RequestStatus.Equals(true))                                
                                ));

            if(!topicOwn)
            {
                return false;
            }

            var chapterExist = await _context.Chapters
                                    .AnyAsync(s => s.Name.Equals(chapterRequest.Name) && s.TopicsId.Equals(TopicsId));

            if(chapterExist)
                return false;

            var chapter = new Chapter
            {
                Id = Guid.NewGuid(),
                Name = chapterRequest.Name,
                CreatedDate = DateTime.Now,
                TopicsId = TopicsId
            };

            var nameId = chapter.Id;

            _context.Chapters.Add(chapter);

            var created = await _context.SaveChangesAsync();

            await _hubContext.Clients.Group(TopicsId.ToString()).SendAsync("Notification", chapterRequest.Name, nameId);

            return created > 0;
        }


        public async Task<bool> EditAsync(ChapterRequest chapterRequest, string GetUserId, Guid TopicsId, Guid chapterId)
        {

            var topicOwn = await _context.Chapters
                                           .Include(b => b.Topics)
                                                .ThenInclude(x => x.Invitees)
                                    .AnyAsync(s => (
                                                    s.Topics.Invitees.Any(r => r.AppUserId.Equals(GetUserId) && r.RequestStatus.Equals(true)) || 
                                                    s.Topics.AppUserId.Equals(GetUserId)
                                                )
                                    && s.Topics.Id.Equals(TopicsId));

            if (!topicOwn)
                return false;

            var chapterExist = await _context.Chapters
                                    .AnyAsync(s => s.Name.Equals(chapterRequest.Name) && s.TopicsId.Equals(TopicsId));

            var chapter = await GetChapterIdAsync(GetUserId, chapterId,TopicsId);

            if (chapter == null)
                return false;

            if (chapterExist)
            {
                return false;
            }

            var chapterName = chapter.Name;

            chapter.Name = chapterRequest.Name;

            chapter.TopicsId = TopicsId;

            _context.Chapters.Update(chapter);

            var created = await _context.SaveChangesAsync();

            var nameId = chapter.Id;

            await _hubContext.Clients.Group(TopicsId.ToString()).SendAsync("Change", chapterName, nameId, chapterRequest.Name);

            return created > 0;
        }


        public async Task<Chapter> GetChapterIdAsync(string GetUserId, Guid ChapterId, Guid TopicsId)
        {
            return await _context.Chapters
                                .Include(s => s.Topics)
                                    .ThenInclude(s => s.Invitees)
                            .Where(x => x.Id.Equals(ChapterId))
                            .Where(x => (x.Topics.Invitees.Any(r => r.AppUserId.Equals(GetUserId) && r.RequestStatus.Equals(true)) || 
                                    x.Topics.AppUserId.Equals(GetUserId)))
                            .Where(s => s.TopicsId.Equals(TopicsId))
                            .SingleOrDefaultAsync();
        }

        public IQueryable<Chapter> GetChapterAllAsync(string GetUserId, Guid TopicsId, string name)
        {
            var queryable =  _context.Chapters
                                  .Include(s => s.Topics)
                                        .ThenInclude(s => s.Invitees)
                            .Where(x => (x.Topics.Invitees.Any(r => r.AppUserId.Equals(GetUserId) && r.RequestStatus.Equals(true)) ||
                                    x.Topics.AppUserId.Equals(GetUserId)))
                            .Where(x => x.TopicsId.Equals(TopicsId))
                            .OrderByDescending(x => x.CreatedDate)
                            .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                queryable = queryable.Where(x => x.Name.Contains(name));
            }

            return queryable;
        }

        public async Task<bool> DeleteChapterAsync(string GetUserId, Guid TopicsId, Guid chapterId)
        {
            var chapter = await GetChapterIdAsync(GetUserId, chapterId, TopicsId);

            var name = chapter.Name;

            var Id = chapter.Id;

            if (chapter == null)
                return false;

            _context.Chapters.Remove(chapter);

            var deleted = await _context.SaveChangesAsync();

            await _hubContext.Clients.Group(TopicsId.ToString()).SendAsync("Edit", name, Id);

            return deleted > 0;
        }
    }
}