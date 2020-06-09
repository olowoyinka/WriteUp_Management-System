using EndPoint.Request.ViewModelRequest;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Threading.Tasks;


namespace Project_Management_System.Server.Interfaces
{
    public interface IEditBody
    {
        Task<Chapter> GetChapterBodyIdAsync(string GetUserId, Guid ChapterId, Guid TopicsId);

        Task<bool> EditBodyAsync(ChapterEditRequest chapterRequest, string GetUserId, Guid TopicsId, Guid chapterId);
    }
}
