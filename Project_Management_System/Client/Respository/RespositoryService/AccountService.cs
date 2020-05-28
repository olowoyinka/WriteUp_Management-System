using EndPoint.Request.UserRequest;
using EndPoint.Response.UserResponse;
using EndPoint.v1;
using Project_Management_System.Client.Helpers.HelperInterface;
using Project_Management_System.Client.Respository.RespositoryInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Respository.RespositoryService
{
    public class AccountService : IAccount
    {
        private readonly IHttpService _httpService;

        private string url = "v1/getalluser";

        public AccountService(IHttpService httpService)
        {
            this._httpService = httpService;
        }

        public async Task<AuthResponse> Login(LoginUserRequest userRequest)
        {
            var httpResponse = await _httpService.Post<LoginUserRequest, AuthResponse>(APIRoute.Account.Login, userRequest);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Response;
        }

        public async Task<ConfirmMapResponse> Register(RegisterUserRequest userRequest)
        {
            var httpResponse = await _httpService.Post<RegisterUserRequest, ConfirmMapResponse>(APIRoute.Account.Register, userRequest);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Response;
        }

        public async Task<ConfirmMapResponse> ForgetPassword(ForgetPasswordRequest passwordRequest)
        {
            var httpResponse = await _httpService.Post<ForgetPasswordRequest, ConfirmMapResponse>(APIRoute.Account.ForgetPassword, passwordRequest);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Response;
        }

        public async Task<UsernameResponse> GetUser()
        {
            return await _httpService.GetHelper<UsernameResponse>(APIRoute.Account.GetUser);
        }

        public async Task<IEnumerable<UsernameResponse>> GetAllAsync(string username)
        {
            return await _httpService.GetHelper<IEnumerable<UsernameResponse>>($"{url}/{username}");
        }
    }
}