using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Respository.RespositoryInterface
{
    public interface IChapter
    {
        Task<AuthResponse> CreateAsync(Guid Id, ChapterRequest chapterRequest);

        Task<PaginationResponse<List<ChapterResponse>>> GetAllAsync(Guid Id, PaginationRequest request, string name);

        Task<ChapterResponse> GetByIdAsync(Guid? topicId, Guid? chapterId);

        Task<AuthResponse> UpdateAsync(Guid? topicId, Guid? chapterId, ChapterRequest chapterRequest);

        Task DeleteAsync(Guid? topicId, Guid? chapterId);
    }
}