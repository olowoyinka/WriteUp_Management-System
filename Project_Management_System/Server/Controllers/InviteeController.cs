using AutoMapper;
using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using EndPoint.v1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    public class InviteeController : ControllerBase
    {
        private readonly IInvitee _inviteeService;

        private readonly IMapper _mapper;

        public InviteeController(IInvitee inviteeService,
                        IMapper mapper)
        {
            _inviteeService = inviteeService;
            _mapper = mapper;
        }


        [HttpGet(APIRoute.Invitee.ReadPending)]
        public async Task<IActionResult> ReadPending([FromQuery] PaginationRequest pagination, [FromQuery] string name, [FromRoute]Guid topicsId)
        {
            var invitee =  _inviteeService.ReadPendingInvitation(GetUserId(), topicsId,name);

            if (invitee == null)
            {
                return Ok(new
                {
                    Error = $"No Record of Invitee Pending for User"
                });
            }

            await HttpContext.InsertPaginationParameterInResponse(invitee, pagination.QuantityPerPage);

            var returnResult = await invitee.Paginate(pagination).ToListAsync();

            return Ok(_mapper.Map<List<InviteeResponse>>(returnResult));
        }


        [HttpGet(APIRoute.Invitee.ReadAccepted)]
        public async Task<IActionResult> ReadAccepted([FromQuery] PaginationRequest pagination, [FromQuery] string name, [FromRoute]Guid topicsId)
        {
            var invitee =  _inviteeService.ReadAcceptedInvitation(GetUserId(), topicsId,name);

            if (invitee == null)
            {
                return Ok(new
                {
                    Error = $"No Record of Invitee Accepteed for the User"
                });
            }

            await HttpContext.InsertPaginationParameterInResponse(invitee, pagination.QuantityPerPage);

            var returnResult = await invitee.Paginate(pagination).ToListAsync();

            return Ok(_mapper.Map<List<InviteeResponse>>(returnResult));
        }


        [HttpPut(APIRoute.Invitee.SentInvitee)]
        public async Task<IActionResult> SentInvitee([FromRoute]Guid topicsId, [FromBody]InviteeSentRequest inviteeSent)
        {
            var invitee = await _inviteeService.SentInvitation(topicsId,inviteeSent,GetUserId());

            if (!invitee)
            {
                return Ok(new
                {
                    Error = "Not Found"
                });
            }

            return Ok(new
            {
                Status = "Invitation sent"
            });
        }


        [HttpPut(APIRoute.Invitee.AcceptInvitee)]
        public async Task<IActionResult> AcceptInvitee([FromRoute]Guid topicsId, [FromBody]InviteeAcceptRequest acceptRequest)
        {
            var invitee = await _inviteeService.AcceptInvitation(topicsId, acceptRequest, GetUserId());

            if (!invitee)
            {
                return Ok(new AuthResponse
                {
                    Error = "Error Occur"
                });
            }

            return Ok(new AuthResponse
            {
                Token = "Invitation Accepted/Deleted"
            });
        }


        private string GetUserId()
        {
            return HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
        }
    }
}