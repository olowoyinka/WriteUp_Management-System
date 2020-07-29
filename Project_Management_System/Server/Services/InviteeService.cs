using DAL.Data;
using EndPoint.Request.ViewModelRequest;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Project_Management_System.Server.Hubs;
using Project_Management_System.Server.Interfaces;
using Project_Management_System.Shared.Models.UserModel;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Services
{
    public class InviteeService : IInvitee
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly ApplicationDbContext _context;

        private readonly IHubContext<ChatRoomHub> _hubContext;

        private readonly INotification _notificationService;
        
        List<Notification> _notificationsList = new List<Notification>();

        public InviteeService(UserManager<AppUser> userManager,
                        ApplicationDbContext context,
                        INotification notificationService,
                        IHubContext<ChatRoomHub> hubContext)
        {
            _userManager = userManager;
            _context = context;
            _notificationService = notificationService;
            _hubContext = hubContext;
        }


        public async Task<bool> SentInvitation(Guid topicsId, InviteeSentRequest inviteeRequest, string GetUserId)
        {
            var topicOwn =  await _context.Topics
                                    .Where(s => s.AppUserId.Equals(GetUserId) && s.Id.Equals(topicsId)).SingleOrDefaultAsync();

            if(topicOwn == null)
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

            var User = await _userManager.Users
                               .SingleOrDefaultAsync(s => s.Id == GetUserId );

            var newNottification = new Notification()
            {
                Id = Guid.NewGuid(),
                AppUserId = findUser.Id,
                CreatedTime = DateTime.Now,
                NotificationMessage = $"#{User.UserName} Sent Collaboration on {topicOwn.Name} ",
                Url = topicsId,
                ReadStatus = false
            };

            _context.Notifications.Add(newNottification);

            await _notificationService.CreateAsync(newNottification);

            return created > 0;
        }


        public async Task<bool> AcceptInvitation(Guid topicsId, InviteeAcceptRequest inviteeAccept, string GetUserId)
        {
            var findUsername = await _userManager.FindByNameAsync(inviteeAccept.username);

            var findInvitee = await _context.Invitees
                                        .Include(s => s.Topics)
                                            .ThenInclude(s => s.AppUser)
                                       .Where(x => x.Topics.AppUserId.Equals(GetUserId) || x.AppUserId.Equals(GetUserId))
                                        .Where(s => s.TopicsId == topicsId)
                                        .Where(s => s.AppUserId == findUsername.Id)
                                    .SingleOrDefaultAsync();

            if(findInvitee == null)
            {
                return false;
            }

            if(!inviteeAccept.acceptance)
            {
                _context.Invitees.Remove(findInvitee);

                var deleted = await _context.SaveChangesAsync();

                var rejectNottification = new Notification()
                {
                    Id = Guid.NewGuid(),
                    AppUserId = findInvitee.Topics.AppUserId,
                    CreatedTime = DateTime.Now,
                    NotificationMessage = $"#{ findUsername.UserName } Reject Collaboration on { findInvitee.Topics.Name }",
                    Url = topicsId,
                    ReadStatus = false
                };

                _context.Notifications.Add(rejectNottification);

                await _notificationService.CreateAsync(rejectNottification);

                return deleted > 0;
            }

            findInvitee.RequestStatus = inviteeAccept.acceptance;
            findInvitee.AcceptedDate = DateTime.Now;

            _context.Invitees.Update(findInvitee);

            var updated = await _context.SaveChangesAsync();

            var dateTime = DateTime.Now;

            var message = $"#{ findUsername.UserName } Accept Collaboration on { findInvitee.Topics.Name }";

            foreach (var item in await _context.Invitees.Include(s => s.AppUser).Where(s => s.TopicsId == topicsId).ToListAsync())
            {
                if(GetUserId == item.AppUserId)
                {
                    var newNottification = new Notification()
                    {
                        Id = Guid.NewGuid(),
                        AppUserId = findInvitee.Topics.AppUserId,
                        CreatedTime = dateTime,
                        NotificationMessage = message,
                        Url = topicsId,
                        ReadStatus = false
                    };

                    _notificationsList.Add(newNottification);

                    await _hubContext.Clients.Group(findInvitee.AppUser.UserName).SendAsync("notification", message, dateTime.ToString("O"));
                }
                else
                {
                    var newNottification = new Notification()
                    {
                        Id = Guid.NewGuid(),
                        AppUserId = item.AppUserId,
                        CreatedTime = dateTime,
                        NotificationMessage = message,
                        Url = topicsId,
                        ReadStatus = false
                    };

                    _notificationsList.Add(newNottification);

                    await _hubContext.Clients.Group(item.AppUser.UserName).SendAsync("notification", message, dateTime.ToString("O"));
                }
            }

            _context.Notifications.AddRange(_notificationsList);

            await _context.SaveChangesAsync();

            await _hubContext.Clients.Group(topicsId.ToString()).SendAsync("RecieveAccept", findUsername.UserName, findUsername.Images, findUsername.FirstName, findUsername.LastName);

            return updated > 0;
        }


        public IQueryable<Invitee> ReadPendingInvitation(string GetUserId, Guid topicsId, string name)
        {
            var queryable =  _context.Invitees
                            .Where(x => x.Topics.AppUserId.Equals(GetUserId) || x.AppUserId.Equals(GetUserId))
                            //.Where(x => x.AppUserId.Equals(GetUserId))
                            .Where(x => x.TopicsId.Equals(topicsId))
                            .Where(s => s.RequestStatus.Equals(false))
                            .Include(s => s.AppUser)
                            .Include(s => s.Topics)
                                .ThenInclude(s => s.AppUser)
                            .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                queryable = queryable.Where(x => x.AppUser.UserName.Contains(name));
            }

            return queryable;
        }


        public IQueryable <Invitee> ReadAcceptedInvitation(string GetUserId, Guid topicsId, string name) 
        {
            var queryable = _context.Invitees
                            //.Where(x => x.AppUserId.Equals(GetUserId))
                            //.Where(x => x.Topics.AppUserId.Equals(GetUserId) || x.AppUserId.Equals(GetUserId))
                            .Where(x => x.TopicsId.Equals(topicsId))
                            .Where(s => s.RequestStatus.Equals(true))
                             .Include(s => s.AppUser)
                             .Include(s => s.Topics)
                                .ThenInclude(s => s.AppUser)
                            .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                queryable = queryable.Where(x => x.AppUser.UserName.Contains(name));
            }

            return queryable;
        }


        public IQueryable<Invitee> ReadUserPendingInvitation(string GetUserId, string name)
        {
            var queryable = _context.Invitees
                            .Where(x => x.AppUserId.Equals(GetUserId))
                            .Where(s => s.RequestStatus.Equals(false))
                            .Include(s => s.AppUser)
                            .Include(s => s.Topics)
                                .ThenInclude(s => s.AppUser)
                            .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                queryable = queryable.Where(x => x.AppUser.UserName.Contains(name));
            }

            return queryable;
        }


        public IQueryable<Invitee> ReadUserAcceptedInvitation(string GetUserId, string name)
        {
            var queryable = _context.Invitees
                            .Where(x => x.AppUserId.Equals(GetUserId))
                            .Where(s => s.RequestStatus.Equals(true))
                             .Include(s => s.AppUser)
                             .Include(s => s.Topics)
                                .ThenInclude(s => s.AppUser)
                            .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                queryable = queryable.Where(x => x.AppUser.UserName.Contains(name));
            }

            return queryable;
        }
    }
}