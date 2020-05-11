using System;
using System.ComponentModel.DataAnnotations;

namespace Project_Management_System.Shared.Models.ViewModels
{
    public class Chapter
    {
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Name { get; set; }

        public string Body { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Guid TopicsId { get; set; }

        public Topics Topics { get; set; }
    }
}