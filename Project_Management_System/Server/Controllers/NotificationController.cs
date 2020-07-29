using AutoMapper;
using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using EndPoint.v1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Management_System.Server.Helpers;
using Project_Management_System.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NotificationController : ControllerBase
    {
        private readonly INotification _notificationService;

        private readonly IMapper _mapper;

        public NotificationController(INotification notificationService,
                                        IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet(APIRoute.Notification.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationRequest pagination,[FromQuery] string name)
        {
            var notification = _notificationService.GetAllAsync(GetUserId());

            if (notification == null)
            {
                return BadRequest(new
                {
                    Error = "No Notification"
                });
            }

            await HttpContext.InsertPaginationParameterInResponse(notification, pagination.QuantityPerPage);

            var returnResult = await notification.Paginate(pagination).ToListAsync();

            return Ok(_mapper.Map<List<NotificationResponse>>(returnResult));
        }
        
        [HttpGet(APIRoute.Notification.ReadStatus)]
        public async Task<IActionResult> GetReadStatus([FromRoute] Guid Topicsid)
        {
            var notification = await _notificationService.UpdateAsync(Topicsid, GetUserId());

            if (!notification)
            {
                return Ok(new AuthResponse
                {
                    Error = "Error Occur"
                });
            }

            return Ok(new AuthResponse
            {
                Token = "Status Updated"
            });

        }

        [HttpGet(APIRoute.Notification.GetUnRead)]
        public async Task<IActionResult> GetCoutnAll()
        {
            var notification = await _notificationService.GetAllCount(GetUserId());

            return Ok(_mapper.Map<CountAllGetResponse>(notification));
        }

        private string GetUserId()
        {
            return HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
        }
    }
}