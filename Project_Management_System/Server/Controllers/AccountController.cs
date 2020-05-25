using AutoMapper;
using EndPoint.Request.UserRequest;
using EndPoint.Response.UserResponse;
using EndPoint.v1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Management_System.Server.Helpers;
using Project_Management_System.Server.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;

        private readonly IEmailSender _emailSender;

        private readonly IMapper _mapper;

        public AccountController(IAccount account,
            IEmailSender emailSender,
            IMapper mapper)
        {
            _account = account;
            this._emailSender = emailSender;
            this._mapper = mapper;
        }

        [HttpPost(APIRoute.Account.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest userRequest)
        {
            var authResponse = await _account.RegisterAsync(userRequest);

            if (!authResponse.Success)
            {
                return Ok(_mapper.Map<ConfirmMapResponse>(authResponse));
            }

            var callbackUrl = Url.Action("ConfirmEmail", "Manage", new { UserId = authResponse.UserId, Code = authResponse.Code }, HttpContext.Request.Scheme);
             
            await _emailSender.SendEmailAsync(authResponse.Email, "ProjMAN - Confirm Your Email", "Please Confirm Your E-Mail by clicking this link: <a href=\"" + callbackUrl + "\">Click here </a>");

            return Ok( _mapper.Map<ConfirmMapResponse>(authResponse));
        }

        [HttpPost(APIRoute.Account.Login)]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest userRequest)
        {
            var authUserResponse = await _account.LoginAsync(userRequest);

            if (!authUserResponse.Success)
            {
                return Ok(_mapper.Map<AuthResponse>(authUserResponse));

            }

            return Ok(_mapper.Map<AuthResponse>(authUserResponse));
        }

        [HttpPost(APIRoute.Account.ProfilePicture)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ProfilePicture([FromForm] IFormFile Image)
        {
            var authUserResponse = await _account.ProfilePicture(Image, GetUserId());

            if (!authUserResponse.Success)
            {
                return BadRequest(new AuthResponse
                {
                    Error = authUserResponse.Error
                });

            }

            return Ok(new AuthResponse
            {
                Token = authUserResponse.Token
            });
        }

        [HttpPost(APIRoute.Account.ForgetPassword)]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest passwordRequest)
        {
            var authResponse = await _account.ForgetPasswordAsync(passwordRequest);

            if (!authResponse.Success)
            {
                return Ok(_mapper.Map<ConfirmMapResponse>(authResponse));
            }

            var callbackUrl = Url.Action("ResetPassword", "Manage", new { UserId = authResponse.UserId, Code = authResponse.Code }, HttpContext.Request.Scheme);

            await _emailSender.SendEmailAsync(authResponse.Email, "ProjMAN - Confirm Your Email", "Please Confirm Your E-Mail by clicking this link: <a href=\"" + callbackUrl + "\">Click here </a>");

            return Ok(_mapper.Map<ConfirmMapResponse>(authResponse));
        }

        [HttpGet(APIRoute.Account.GetUser)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUsers()
        {
            var allUserResponse = await _account.getUser(GetUserId());

            return Ok(_mapper.Map<UsernameResponse>(allUserResponse));
        }

        [HttpGet(APIRoute.Account.GetAllUser)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAllUsers([FromRoute] string username)
        {
            var allUserResponse = await _account.ListAllUsers(username);

            return Ok(_mapper.Map<List<UsernameResponse>>(allUserResponse));
        }

        [HttpGet(APIRoute.Account.GetUserId)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUserId([FromRoute] string username)
        {
            if(username == null)
            {
                return BadRequest( new {
                    Error = "Not Found"
                });
            }

            var allUserResponse = await _account.getUserId(username);

            if (allUserResponse == null)
            {
                return BadRequest(new
                {
                    Error = "UserName Doesn't Exist"
                });
            }

            return Ok(_mapper.Map<UsernameResponse>(allUserResponse));
        }

        private string GetUserId()
        {
            return HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
        }
    }
}