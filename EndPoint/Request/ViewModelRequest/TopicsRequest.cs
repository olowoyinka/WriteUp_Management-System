using System.ComponentModel.DataAnnotations;

namespace EndPoint.Request.ViewModelRequest
{
    public class TopicsRequest
    {
        [Required]
        [StringLength(24, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Name { get; set; }

    }
}
