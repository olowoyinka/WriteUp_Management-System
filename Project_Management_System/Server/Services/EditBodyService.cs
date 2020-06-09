using DAL.Data;
using EndPoint.Request.ViewModelRequest;
using Microsoft.EntityFrameworkCore;
using Project_Management_System.Server.Interfaces;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Project_Management_System.Server.Services
{
    public class EditBodyService : IEditBody
    {
        private readonly ApplicationDbContext _context;

        public EditBodyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EditBodyAsync(ChapterEditRequest chapterRequest, string GetUserId, Guid TopicsId, Guid chapterId)
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

            var chapter = await GetChapterBodyIdAsync(GetUserId, chapterId, TopicsId);

            if (chapter == null)
                return false;

            chapter.Body = chapterRequest.Body;

            chapter.CreatedDate = DateTime.Now;

            _context.Chapters.Update(chapter);

            var created = await _context.SaveChangesAsync();

            return created > 0;
        }


        public async Task<Chapter> GetChapterBodyIdAsync(string GetUserId, Guid ChapterId, Guid TopicsId)
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

    }
}
