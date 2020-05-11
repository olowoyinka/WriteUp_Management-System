using Project_Management_System.Shared.Models.UserModel;
using System;

namespace Project_Management_System.Shared.Models.ViewModels
{
    public class Invitee
    {
        public Guid Id { get; set; }

        public bool RoleStatus { get; set; }

        public bool RequestStatus { get; set; }

        public DateTime AcceptedDate { get; set; }

        public string AppUserId { get; set; }

        public Guid TopicsId { get; set; }

        public AppUser AppUser { get; set; }

        public Topics Topics { get; set; }
    }
}
