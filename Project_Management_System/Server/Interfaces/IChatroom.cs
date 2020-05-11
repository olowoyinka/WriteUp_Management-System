using Project_Management_System.Shared.Models.ChatModels;
using System;
using System.Threading.Tasks;

namespace Project_Management_System.Server.Interfaces
{
    public interface IChatroom
    {
        Task<ChatRoom> GetChatroomIdAsync(string GetUserId, Guid TopicsId);
    }
}