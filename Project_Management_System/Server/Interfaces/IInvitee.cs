using EndPoint.Request.ViewModelRequest;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Interfaces
{
    public interface IInvitee
    {
        Task<bool> SentInvitation(Guid topicsId, InviteeSentRequest inviteeRequest, string GetUserId);

        Task<bool> AcceptInvitation(Guid topicsId, InviteeAcceptRequest inviteeAccept, string GetUserId);

        Task<List<Invitee>> ReadPendingInvitation(string GetUserId);

        Task<List<Invitee>> ReadAcceptedInvitation(string GetUserId);
    }
}