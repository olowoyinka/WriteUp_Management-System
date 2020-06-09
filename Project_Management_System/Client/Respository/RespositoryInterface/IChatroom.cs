using EndPoint.Response.ViewModelResponse;
using System;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Respository.RespositoryInterface
{
    public interface IChatroom
    {
        Task<ChatRoomResponse> GetByIdAsync(Guid topicId);
    }
}