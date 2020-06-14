using System;

namespace Project_Management_System.Shared.Models.ChatModels
{
    public class ListMessage
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Image { get; set; }

        public string Highlighted { get; set; }
    }
}
