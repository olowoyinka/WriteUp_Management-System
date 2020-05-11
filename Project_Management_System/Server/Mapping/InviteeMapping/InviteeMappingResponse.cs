using AutoMapper;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using Project_Management_System.Shared.Models.ViewModels;

namespace Project_Management_System.Server.Mapping.InviteeMapping
{
    public class InviteeMappingResponse : Profile
    {
        public InviteeMappingResponse()
        {
            CreateMap<Invitee, InviteeResponse>()
                    .ForMember(dest => dest.Topics, opt =>
                        opt.MapFrom(x => new TopicsInviteeResponse { Name = x.Topics.Name,
                                                                      CreatedDate = x.Topics.CreatedDate}))
                    .ForMember(dest => dest.AppUser, opt =>
                        opt.MapFrom(x => new UsernameResponse { FirstName = x.Topics.AppUser.FirstName,
                                                                LastName = x.Topics.AppUser.LastName,
                                                                UserName = x.Topics.AppUser.UserName,
                                                                Images = x.Topics.AppUser.Images,
                                                                JoinedDate = x.Topics.AppUser.JoinedDate}));
        }
    }
}