using AutoMapper;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using Project_Management_System.Shared.Models.ViewModels;

namespace Project_Management_System.Server.Mapping.TopicsMapping
{
    public class TopicsMappingResponse : Profile
    {
        public TopicsMappingResponse()
        {
            CreateMap<Topics, TopicsResponse>()
                .ForMember(dest => dest.SingleUsernameResponse, opt =>
                        opt.MapFrom(x => new SingleUsernameResponse { UserName = x.AppUser.UserName}));
                    //.ForMember(dest => dest.Invitees, opt =>
                    //    opt.MapFrom(src => src.Invitees
                    //        .Select(x => new InviteeTopicResponse { RoleStatus = x.RoleStatus,
                    //                                                RequestStatus = x.RequestStatus,
                    //                                                AcceptedDate = x.AcceptedDate,
                    //                                                AppUser = new UsernameResponse { FirstName = x.AppUser.FirstName,
                    //                                                                                 LastName = x.AppUser.LastName,
                    //                                                                                 UserName = x.AppUser.UserName,
                    //                                                                                 Images = x.AppUser.Images,
                    //                                                                                 JoinedDate = x.AppUser.JoinedDate}
                        
                    //    })))

                    //.ForMember(dest => dest.Chapters, opt =>
                    //    opt.MapFrom(src => src.Chapters.Select(x => new ChapterResponse { Id = x.Id,
                    //                                                                      Name = x.Name,
                    //                                                                      CreatedDate = x.CreatedDate })));
        }
    }
}