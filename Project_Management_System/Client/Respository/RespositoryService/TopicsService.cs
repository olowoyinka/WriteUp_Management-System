using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using EndPoint.v1;
using Project_Management_System.Client.Helpers.HelperInterface;
using Project_Management_System.Client.Respository.RespositoryInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Project_Management_System.Client.Respository.RespositoryService
{
    public class TopicsService : ITopics
    {
        private readonly IHttpService _httpService;

        private string url = "v1/topics";

        public TopicsService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<AuthResponse> CreateAsync(TopicsRequest topicsRequest)
        {
            var response = await _httpService.Post<TopicsRequest, AuthResponse>(APIRoute.Topics.Create, topicsRequest);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task DeleteAsync(Guid? Id)
        {
            var response = await _httpService.Delete($"{url}/{Id}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<PaginationResponse<List<TopicsResponse>>> GetAllAsync(PaginationRequest request, string name)
        {
            return await _httpService.GetHelper<List<TopicsResponse>>(APIRoute.Topics.GetAll, request, name);
        }

        public async Task<TopicsResponse> GetByIdAsync(Guid? Id)
        {
            return await _httpService.GetHelper<TopicsResponse>($"{url}/{Id}");
        }

        public async Task<AuthResponse> UpdateAsync(Guid Id, TopicsRequest topicsRequest)
        {
            var response = await _httpService.Put<TopicsRequest, AuthResponse>($"{url}/{Id}", topicsRequest);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }
    }
}