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
    public class NotificationService : INotification
    {
        private readonly IHttpService _httpService;

        private string url = "v1/readstatus";

        public NotificationService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<PaginationResponse<List<NotificationResponse>>> GetAllAsync(PaginationRequest request)
        {
            return await _httpService.GetHelper<List<NotificationResponse>>(APIRoute.Notification.GetAll, request, null);
        }

        public async Task<CountAllGetResponse> CountUnRead()
        {
            return await _httpService.GetHelper<CountAllGetResponse>(APIRoute.Notification.GetUnRead);
        }

        public async Task<AuthResponse> ReadStatus(Guid Topicsid)
        {
            return await _httpService.GetHelper<AuthResponse>($"{url}/{Topicsid}");
        }
    }
}