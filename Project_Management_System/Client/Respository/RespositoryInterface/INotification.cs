using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Respository.RespositoryInterface
{
    public interface INotification
    {
        Task<AuthResponse> ReadStatus(Guid Topicsid);
        
        Task<PaginationResponse<List<NotificationResponse>>> GetAllAsync(PaginationRequest request);

        Task<CountAllGetResponse> CountUnRead();
    }
}