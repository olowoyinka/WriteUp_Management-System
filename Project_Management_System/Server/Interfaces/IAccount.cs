using EndPoint.Request.UserRequest;
using EndPoint.Response.UserResponse;
using Microsoft.AspNetCore.Http;
using Project_Management_System.Shared.Models.UserModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Interfaces
{
    public interface IAccount
    {
        Task<ConfirmResponse> RegisterAsync(RegisterUserRequest userRequest);

        Task<AuthResult> LoginAsync(LoginUserRequest userRequest);

        Task<AuthResult> ProfilePicture(IFormFile Image, string GetUserId);

        Task<List<AppUser>> ListAllUsers(string UserName);
         
        Task<AppUser> getUserId(string UserName);

        Task<ConfirmResponse> ForgetPasswordAsync(ForgetPasswordRequest passwordRequest);
    }
}