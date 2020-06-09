using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using Project_Management_System.Client.Helpers.HelperInterface;
using Project_Management_System.Client.Respository.RespositoryInterface;
using System;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Respository.RespositoryService
{
    public class EditBodyService : IEditBody
    {
        private readonly IHttpService _httpService;
         
        private string topics = "v1/project";

        private string chapter = "chapter";


        public EditBodyService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ChapterByIdResponse> GetByIdAsync(Guid topicId, Guid chapterId)
        {
            return await _httpService.GetHelper<ChapterByIdResponse>($"{topics}/{topicId}/{chapter}/{chapterId}");
        }

        public async Task<AuthResponse> UpdateBodyAsync(Guid topicId, Guid chapterId, ChapterEditRequest chapterRequest)
        {
            var response = await _httpService.Post<ChapterEditRequest, AuthResponse>($"{topics}/{topicId}/{chapter}/{chapterId}", chapterRequest);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }
    }
}