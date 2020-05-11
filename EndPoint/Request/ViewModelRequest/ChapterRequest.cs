using System.ComponentModel.DataAnnotations;

namespace EndPoint.Request.ViewModelRequest
{
    public class ChapterRequest
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Name { get; set; }
    }

    public class ChapterEditRequest
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Name { get; set; }

        public string Body { get; set; }
    }
}