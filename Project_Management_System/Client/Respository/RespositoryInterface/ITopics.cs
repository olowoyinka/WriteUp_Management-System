using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Respository.RespositoryInterface
{
    public interface ITopics
    {
        Task<AuthResponse> CreateAsync(TopicsRequest topicsRequest);

        Task DeleteAsync(Guid? Id);

        Task<PaginationResponse<List<TopicsResponse>>> GetAllAsync(PaginationRequest request, string name);

        Task<TopicsResponse> GetByIdAsync(Guid Id);

        Task<AuthResponse> UpdateAsync(Guid Id, TopicsRequest topicsRequest);
    }
}