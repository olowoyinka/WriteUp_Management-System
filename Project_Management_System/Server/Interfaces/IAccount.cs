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

        Task<AuthResult> DeletePicture(string GetUserId, string imageName);

        Task<IEnumerable<AppUser>> ListAllUsers(string UserName);
        
        Task<AppUser> getUserId(string UserName);
        
        Task<AppUser> getUser(string UserId);

        Task<ConfirmResponse> ForgetPasswordAsync(ForgetPasswordRequest passwordRequest);

        Task<bool> ChangePasswordAsync(string GetUserId, ChangePasswordRequest changePasswordRequest);

        Task<ConfirmResponse> UpdateNameAsync(string GetUserId, FullNameRequest fullNameRequest);
    }
}