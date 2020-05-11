using EndPoint.Request.ViewModelRequest;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Interfaces
{
    public interface ITopics
    {
        Task<bool> CreateAsync(TopicsRequest topicsRequest, string GetUserId);

        Task<Topics> GetByIdAsync(Guid Id, string GetUserId);

        Task<List<Topics>> GetAllAsync(string GetUserId);

        Task<bool> DeleteAsync(Guid Id, string GetUserId);

        Task<bool> UpdateAsync(Guid Id, TopicsRequest topicsRequest, string GetUserId);
    }
}