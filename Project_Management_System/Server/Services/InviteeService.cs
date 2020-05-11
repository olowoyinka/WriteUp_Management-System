using DAL.Data;
using EndPoint.Request.ViewModelRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_Management_System.Server.Interfaces;
using Project_Management_System.Shared.Models.UserModel;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Services
{
    public class InviteeService : IInvitee
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly ApplicationDbContext _context;

        public InviteeService(UserManager<AppUser> userManager,
                        ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        public async Task<bool> SentInvitation(Guid topicsId, InviteeSentRequest inviteeRequest, string GetUserId)
        {
            var topicOwn = await _context.Topics
                                    .AnyAsync(s => s.AppUserId.Equals(GetUserId) && s.Id.Equals(topicsId));

            if(!topicOwn)
                return false;

            var findUser = await _userManager.Users
                                .SingleOrDefaultAsync(s => s.UserName == inviteeRequest.UserName);

            if(findUser == null)
                return false;

            var inviteeExist = await _context.Invitees
                        .AnyAsync(x => x.AppUserId.Equals(findUser.Id) && x.TopicsId.Equals(topicsId));

            if(inviteeExist)
                return false;

            var inviteeSent = new Invitee
            {
                Id = Guid.NewGuid(),
                RequestStatus = false,
                RoleStatus = inviteeRequest.RoleStatus,
                AcceptedDate = DateTime.Now,
                AppUserId = findUser.Id,
                TopicsId = topicsId
            };

            _context.Invitees.Add(inviteeSent);

            var created = await _context.SaveChangesAsync();

            return created > 0;
        }


        public async Task<bool> AcceptInvitation(Guid topicsId, InviteeAcceptRequest inviteeAccept, string GetUserId)
        {
            var findInvitee = await _context.Invitees
                                        .Where(s => s.TopicsId == topicsId)
                                        .Where(s => s.AppUserId == GetUserId)
                                    .SingleOrDefaultAsync();

            if(findInvitee == null)
            {
                return false;
            }

            if(!inviteeAccept.acceptance)
            {
                _context.Invitees.Remove(findInvitee);

                var deleted = await _context.SaveChangesAsync();

                return deleted > 0;
            }

            findInvitee.RequestStatus = inviteeAccept.acceptance;
            findInvitee.AcceptedDate = DateTime.Now;

            _context.Invitees.Update(findInvitee);

            var updated = await _context.SaveChangesAsync();

            return updated > 0;
        }


        public async Task<List<Invitee>> ReadPendingInvitation(string GetUserId)
        {
            return await _context.Invitees
                            .Where(x => x.AppUserId.Equals(GetUserId))
                            .Where(s => s.RequestStatus.Equals(false))
                            .Include(s => s.AppUser)
                            .Include(s => s.Topics)
                                .ThenInclude(s => s.AppUser)
                            .ToListAsync();
        }


        public async Task<List<Invitee>> ReadAcceptedInvitation(string GetUserId) 
        {
            return await _context.Invitees
                            .Where(x => x.AppUserId.Equals(GetUserId))
                            .Where(s => s.RequestStatus.Equals(true))
                             .Include(s => s.AppUser)
                             .Include(s => s.Topics)
                                .ThenInclude(s => s.AppUser)
                            .ToListAsync();
        }
    }
}