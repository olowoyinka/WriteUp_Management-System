using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using System;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Respository.RespositoryInterface
{
    public interface IEditBody
    {
        Task<ChapterByIdResponse> GetByIdAsync(Guid topicId, Guid chapterId);

        Task<AuthResponse> UpdateBodyAsync(Guid topicId, Guid chapterId, ChapterEditRequest chapterRequest);
    }
}