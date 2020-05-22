using EndPoint.Request.ViewModelRequest;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Interfaces
{
    public interface ITopics
    {
        Task<bool> CreateAsync(TopicsRequest topicsRequest, string GetUserId);

        Task<Topics> GetByIdAsync(Guid Id, string GetUserId);

        IQueryable<Topics> GetAllAsync(string GetUserId, string name);

        Task<bool> DeleteAsync(Guid Id, string GetUserId);

        Task<bool> UpdateAsync(Guid Id, TopicsRequest topicsRequest, string GetUserId);
    }
}