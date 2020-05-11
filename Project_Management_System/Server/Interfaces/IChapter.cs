using EndPoint.Request.ViewModelRequest;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Interfaces
{
    public interface IChapter
    {
        Task<bool> CreateAsync(ChapterRequest chapterRequest, string GetUserId, Guid TopicsId);

        Task<bool> EditAsync(ChapterEditRequest chapterRequest, string GetUserId, Guid TopicsId, Guid chapterId);

        Task<Chapter> GetChapterIdAsync(string GetUserId, Guid ChapterId, Guid TopicsId);

        Task<List<Chapter>> GetChapterAllAsync(string GetUserId, Guid TopicsId);

        Task<bool> DeleteChapterAsync(string GetUserId, Guid TopicsId, Guid chapterId);
    }
}