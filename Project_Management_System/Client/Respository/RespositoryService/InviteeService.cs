using EndPoint.Request.ViewModelRequest;
using EndPoint.Response.UserResponse;
using EndPoint.Response.ViewModelResponse;
using Project_Management_System.Client.Helpers.HelperInterface;
using Project_Management_System.Client.Respository.RespositoryInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Client.Respository.RespositoryService
{
    public class InviteeService : IInvitee
    {
        private readonly IHttpService _httpService;

        private string topics = "v1/topics";

        private string pending = "readpendinvitee";
        
        private string accepted = "readacceptinvitee";

        public InviteeService(IHttpService httpService)
        {
            _httpService = httpService;
        } 


        public async Task<PaginationResponse<List<InviteeResponse>>> GetAcceptedUser(Guid Id, PaginationRequest request, string name)
        {
            return await _httpService.GetHelper<List<InviteeResponse>>($"{topics}/{accepted}/{Id}", request, name);
        }


        public async Task<PaginationResponse<List<InviteeResponse>>> GetPendingUser(Guid? Id, PaginationRequest request, string name)
        {
            return await _httpService.GetHelper<List<InviteeResponse>>($"{topics}/{pending}/{Id}", request, name);
        }

        public async Task<PaginationResponse<List<InviteeResponse>>> GetAccepted(PaginationRequest request, string name)
        {
            return await _httpService.GetHelper<List<InviteeResponse>>($"{topics}/{accepted}", request, name);
        }


        public async Task<PaginationResponse<List<InviteeResponse>>> GetPending(PaginationRequest request, string name)
        {
            return await _httpService.GetHelper<List<InviteeResponse>>($"{topics}/{pending}", request, name);
        }


        public async Task<AuthResponse> RemoveInvitation(Guid? topicId, InviteeAcceptRequest inviteeAccept)
        {
            var response = await _httpService.Put<InviteeAcceptRequest, AuthResponse>($"{topics}/{topicId}/acceptinvitee", inviteeAccept);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            } 

            return response.Response;
        }

        public async Task<AuthResponse> SentInvitation(Guid? topicId, InviteeSentRequest inviteeSent)
        {
            var response = await _httpService.Put<InviteeSentRequest, AuthResponse>($"{topics}/{topicId}/sentinvitee", inviteeSent);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }
    }
} 