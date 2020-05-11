using DAL.Data;
using EndPoint.Request.ViewModelRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Project_Management_System.Server.Interfaces;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Services
{
    public class ChapterService : IChapter
    {
        private readonly ApplicationDbContext _context;

        public ChapterService(ApplicationDbContext context)
        {
            _context = context;
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

            _context.Chapters.Add(chapter);

            var created = await _context.SaveChangesAsync();

            return created > 0;
        }


        public async Task<bool> EditAsync(ChapterEditRequest chapterRequest, string GetUserId, Guid TopicsId, Guid chapterId)
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
                chapter.Name = chapter.Name;
            }
            else
            {
                chapter.Name = chapterRequest.Name;
            }

            chapter.Body = chapterRequest.Body;
            chapter.TopicsId = TopicsId;

            _context.Chapters.Update(chapter);

            var created = await _context.SaveChangesAsync();

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

        public async Task<List<Chapter>> GetChapterAllAsync(string GetUserId, Guid TopicsId)
        {
            return await _context.Chapters
                                  .Include(s => s.Topics)
                                        .ThenInclude(s => s.Invitees)
                            .Where(x => (x.Topics.Invitees.Any(r => r.AppUserId.Equals(GetUserId) && r.RequestStatus.Equals(true)) ||
                                    x.Topics.AppUserId.Equals(GetUserId)))
                            .Where(x => x.TopicsId.Equals(TopicsId))
                            .ToListAsync();
        }

        public async Task<bool> DeleteChapterAsync(string GetUserId, Guid TopicsId, Guid chapterId)
        {
            var chapter = await GetChapterIdAsync(GetUserId, chapterId, TopicsId);

            if (chapter == null)
                return false;

            _context.Chapters.Remove(chapter);

            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }
    }
}