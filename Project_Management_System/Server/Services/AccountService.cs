using EndPoint.Request.UserRequest;
using EndPoint.Response.UserResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project_Management_System.Server.Helpers;
using Project_Management_System.Server.Interfaces;
using Project_Management_System.Shared.Models.UserModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Services
{
    public class AccountService : IAccount
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly AppSettings _appSettings;

        private readonly IHostEnvironment _environment;

        public AccountService(UserManager<AppUser> userManager,
            IOptions<AppSettings> appSettings,
            IHostEnvironment environment)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _environment = environment;
        }

        public async Task<AppUser> getUserId(string UserName)
        {
            return await _userManager.Users.SingleOrDefaultAsync(s => s.UserName == UserName);
        }

        public async Task<IEnumerable<AppUser>> ListAllUsers(string UserName)
        {
            return await _userManager.Users.Where(x => x.UserName.ToLower().Equals(UserName.ToLower())).ToListAsync();
        }

        public async Task<AppUser> getUser(string UserId)
        {
            return await _userManager.Users.SingleOrDefaultAsync(s => s.Id == UserId);
        }

        public async Task<AuthResult> LoginAsync(LoginUserRequest userRequest)
        {
            var existUser = await _userManager.FindByNameAsync(userRequest.UserName);

            if (existUser == null)
            {
                return new AuthResult()
                {
                    Error = "UserName doesn't Exist"
                };
            }

            var checkPassword = await _userManager.CheckPasswordAsync(existUser, userRequest.Password);

            if (!checkPassword)
            {
                return new AuthResult()
                {
                    Error = "InCorrect Password"
                };
            }

            var emailConfirmed = await _userManager.IsEmailConfirmedAsync(existUser);

            if (!emailConfirmed)
            {
                return new AuthResult()
                {
                    Error = "Your Email Address has not been confirm. Kindly Check Your Email Address"
                };
            }

            return await GenerateUserToken(existUser);

        }


        public async Task<AuthResult> ProfilePicture(IFormFile Image, string GetUserId)
        {
            var user = await _userManager.FindByIdAsync(GetUserId);

            if (Image == null || Image.Length == 0)
            {
                return new AuthResult()
                {
                    Error = "Upload a File"
                };
            }

            string fileName = Image.FileName;

            string extension = Path.GetExtension(fileName);

            string[] allowedExtensions = { ".jpg", ".png", ".bmp" };

            if (!allowedExtensions.Contains(extension))
            {
                return new AuthResult()
                {
                    Error = $"File is not extension {extension} is not allowed"
                };
            }

            string newFileName = $"{user.UserName}{extension}";

            string filePath = Path.Combine(_environment.ContentRootPath, "wwwroot", "Images", newFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await Image.CopyToAsync(fileStream);
            }

            user.Images = newFileName;

            await _userManager.UpdateAsync(user);

            return new AuthResult()
            {
                Token = "Image Upload Sucessfully",
                Success = true
            };
        }


        public async Task<ConfirmResponse> RegisterAsync(RegisterUserRequest userRequest)
        {
            var existingEmail = await _userManager.FindByEmailAsync(userRequest.Email);

            if (existingEmail != null)
            {
                return new ConfirmResponse()
                {
                    Error = "This Email Address is Already Used"
                };
            }

            var existingUsername = await _userManager.FindByNameAsync(userRequest.UserName);

            if (existingUsername != null)
            {
                return new ConfirmResponse()
                {
                    Error = "This Username is Already Used"
                };
            }

            var newUser = new AppUser
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Email = userRequest.Email,
                UserName = userRequest.UserName,
                JoinedDate = DateTime.Now
            };

            var result = await _userManager.CreateAsync(newUser, userRequest.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, userRequest.Roles);

                string code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

                return new ConfirmResponse()
                {
                    Success = true,
                    Result = "Account Created Successfully. Please Check Your Email to Confirm Account",
                    UserId = newUser.Id,
                    Email = newUser.Email,
                    Code = code
                };
            }

            return new ConfirmResponse()
            {
                Error = result.Errors.LastOrDefault().Description
            };
        }


        public async Task<ConfirmResponse> ForgetPasswordAsync(ForgetPasswordRequest passwordRequest)
        {
            var user = await _userManager.FindByEmailAsync(passwordRequest.Email);

            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                return new ConfirmResponse()
                {
                    Error = "It is Already Sent to your Email"
                };
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            return new ConfirmResponse()
            {
                Success = true,
                Result = "Please Check Your Email",
                UserId = user.Id,
                Code = code,
                Email = passwordRequest.Email
            };
        }


        private async Task<AuthResult> GenerateUserToken(AppUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));

            double tokenExpiryTime = Convert.ToDouble(_appSettings.ExpireTime);

            var Expires = DateTime.UtcNow.AddHours(tokenExpiryTime);

            var tokenHandler = new JwtSecurityTokenHandler();

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("olowoyinka", "My Web Application"),
                new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _appSettings.Site,
                audience: _appSettings.Audience,
                claims: claims,
                expires: Expires,
                signingCredentials: creds);

            return new AuthResult()
            {
                Token = tokenHandler.WriteToken(token),
                Success = true
            };
        }
    }
}