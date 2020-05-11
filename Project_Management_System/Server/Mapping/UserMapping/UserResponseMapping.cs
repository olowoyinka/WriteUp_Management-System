using AutoMapper;
using EndPoint.Response.UserResponse;
using Project_Management_System.Shared.Models.UserModel;

namespace Project_Management_System.Server.Mapping.UserMapping
{
    public class UserResponseMapping : Profile
    {
        public UserResponseMapping()
        {
            CreateMap<AppUser, UsernameResponse>();
        }
    }
}