using AutoMapper;
using EndPoint.Response.ViewModelResponse;
using EndPoint.v1;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Project_Management_System.Server.Interfaces;
using Project_Management_System.Shared.Models.ChatModels;
using System;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ChatroomController : ControllerBase
    {
        private readonly IChatroom _chatroomService;

        private readonly IMapper _mapper;
        
        public ChatroomController(IChatroom chatroomService,
            IMapper mapper)
        {
            _chatroomService = chatroomService;
            _mapper = mapper;
        }

        [HttpPost(APIRoute.Chatroom.AddToGroup)]
        public async Task<IActionResult> AddToGroup([FromRoute] Guid chatroomId)
        {
            var chatroomExist = await _chatroomService.GetChatroomIdAsync(GetUserId(), chatroomId);

            if(chatroomExist == null)
            {
                return BadRequest(new
                {
                    Error = "No Record of Chatroom"
                });
            }

            return Ok(_mapper.Map<ChatRoomResponse>(chatroomExist));
        }

        private string GetUserId()
        {
            return HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
        }
    }
}