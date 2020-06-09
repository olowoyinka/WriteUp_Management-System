using AutoMapper;
using EndPoint.Response.ViewModelResponse;
using Project_Management_System.Shared.Models.ChatModels;
using System.Linq;

namespace Project_Management_System.Server.Mapping.ChatroomMapping
{
    public class ChatroomMappingResponse : Profile
    {
        public ChatroomMappingResponse()
        {
            CreateMap<ChatRoom, ChatRoomResponse>()
                     .ForMember(dest => dest.ChatMessages, opt =>
                        opt.MapFrom(src => src.ChatMessages.Select(x => new ChatMessageResponse
                        {
                            //Id = x.Id,
                            Message = x.Message,
                            CreatedDate = x.CreatedDate,
                            Username = x.Username,
                            Highlighted = x.Highlighted,
                            Image = x.Image
                        })));
        }
    }
}