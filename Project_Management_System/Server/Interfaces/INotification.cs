using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Interfaces
{
    public interface INotification
    {
        Task<bool> CreateAsync(Notification notification);

        IQueryable<Notification> GetAllAsync(string UserId);

        Task<bool> UpdateAsync(Guid notificationId, string GetuserId);

        Task<CountAllGet> GetAllCount(string UserId);
    }
}