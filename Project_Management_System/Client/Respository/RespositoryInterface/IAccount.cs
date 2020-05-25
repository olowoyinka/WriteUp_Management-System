using EndPoint.Request.UserRequest;
using EndPoint.Response.UserResponse;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Respository.RespositoryInterface
{
    public interface IAccount
    {
        Task<ConfirmMapResponse> Register(RegisterUserRequest userRequest);

        Task<AuthResponse> Login(LoginUserRequest userRequest);

        Task<ConfirmMapResponse> ForgetPassword(ForgetPasswordRequest passwordRequest);

        Task<UsernameResponse> GetUser();
    }
}