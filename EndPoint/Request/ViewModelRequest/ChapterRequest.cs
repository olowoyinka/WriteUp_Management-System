using System.ComponentModel.DataAnnotations;

namespace EndPoint.Request.ViewModelRequest
{
    public class ChapterRequest
    {
        [Required]
        [StringLength(14, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Name { get; set; }
    }

    public class ChapterEditRequest
    {
        public string Body { get; set; }
    }
}