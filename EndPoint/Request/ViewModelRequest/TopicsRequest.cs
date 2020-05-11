using System.ComponentModel.DataAnnotations;

namespace EndPoint.Request.ViewModelRequest
{
    public class TopicsRequest
    {
        [Required]
        public string Name { get; set; }

    }
}
