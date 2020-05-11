using Project_Management_System.Shared.Models.ChatModels;
using Project_Management_System.Shared.Models.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_Management_System.Shared.Models.ViewModels
{
    public class Topics
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; } =  DateTime.Now;

        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public List<Chapter> Chapters { get; set; }

        public List<Invitee> Invitees { get; set; }
    }
}