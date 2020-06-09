using EndPoint.Response.ViewModelResponse;
using Project_Management_System.Client.Helpers.HelperInterface;
using Project_Management_System.Client.Respository.RespositoryInterface;
using System;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Respository.RespositoryService
{
    public class ChatroomService : IChatroom
    {
        private readonly IHttpService _httpService;

        private string chatroom = "v1/chatroom";

        public ChatroomService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ChatRoomResponse> GetByIdAsync(Guid topicId)
        {
            return await _httpService.GetHelper<ChatRoomResponse>($"{chatroom}/{topicId}");
        }
    }
}