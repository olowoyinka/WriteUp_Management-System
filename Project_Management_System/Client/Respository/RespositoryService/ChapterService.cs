using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using Project_Management_System.Client.Helpers.HelperInterface;
using Project_Management_System.Client.Respository.RespositoryInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Respository.RespositoryService
{
    public class ChapterService : IChapter
    {
        private readonly IHttpService _httpService;

        private string topics = "v1/topics";

        private string chapter = "chapter";


        public ChapterService(IHttpService httpService)
        {
            _httpService = httpService;
        }


        public async Task<AuthResponse> CreateAsync(Guid Id, ChapterRequest chapterRequest)
        {
            var response = await _httpService.Post<ChapterRequest, AuthResponse>($"{topics}/{Id}/{chapter}", chapterRequest);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }


        public async Task<PaginationResponse<List<ChapterResponse>>> GetAllAsync(Guid Id, PaginationRequest request, string name)
        {
            return await _httpService.GetHelper<List<ChapterResponse>>($"{topics}/{Id}/{chapter}", request, name);
        }


        public async Task<ChapterResponse> GetByIdAsync(Guid? topicId, Guid? chapterId)
        {
            return await _httpService.GetHelper<ChapterResponse>($"{topics}/{topicId}/{chapter}/{chapterId}");
        }


        public async Task<AuthResponse> UpdateAsync(Guid? topicId, Guid? chapterId, ChapterRequest chapterRequest)
        {
            var response = await _httpService.Put<ChapterRequest, AuthResponse>($"{topics}/{topicId}/{chapter}/{chapterId}", chapterRequest);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task DeleteAsync(Guid? topicId, Guid? chapterId)
        {
            var response = await _httpService.Delete($"{topics}/{topicId}/{chapter}/{chapterId}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}