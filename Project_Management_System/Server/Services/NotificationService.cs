using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Project_Management_System.Server.Interfaces;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Services
{
    public class NotificationService : INotification
    {
        private readonly ApplicationDbContext _context;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Notification notification)
        {
            _context.Notifications.Add(notification);

            var created = await _context.SaveChangesAsync();

            return created > 0;
        }

        public IQueryable<Notification> GetAllAsync(string UserId)
        {
            var queryable = _context.Notifications
                                .Include(x => x.AppUser)
                                .Where(x => x.AppUserId.Equals(UserId))
                                .OrderByDescending(d => d.CreatedTime)
                                .AsQueryable();

            return queryable;
        }
        
        public async Task<bool> UpdateAsync(Guid notificationId, string GetuserId)
        {
            var findNotification = await _context.Notifications
                                            .Where(s => s.Id == notificationId && s.AppUserId == GetuserId)
                                            .SingleOrDefaultAsync();

            findNotification.ReadStatus = true;

            _context.Notifications.Update(findNotification);

            var created = await _context.SaveChangesAsync();

            return created > 0;
        }

        public async Task<CountAllGet> GetAllCount(string UserId)
        {
            var queryable = await _context.Notifications
                                .Where(x => x.AppUserId.Equals(UserId))
                                .Where(x => x.ReadStatus.Equals(false))
                                .CountAsync();

            return new CountAllGet()
            {
                Number = queryable
            };
        }
    }
}