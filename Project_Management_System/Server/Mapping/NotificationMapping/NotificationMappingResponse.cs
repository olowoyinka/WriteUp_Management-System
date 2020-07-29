using AutoMapper;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using Project_Management_System.Shared.Models.ViewModels;

namespace Project_Management_System.Server.Mapping.NotificationMapping
{
    public class NotificationMappingResponse : Profile
    {
        public NotificationMappingResponse()
        {
            CreateMap<Notification, NotificationResponse>()
                    .ForMember(dest => dest.SingleUsernameResponse, opt =>
                        opt.MapFrom(x => new SingleUsernameResponse
                        {
                            UserName = x.AppUser.UserName
                        }));
        }
    }
}