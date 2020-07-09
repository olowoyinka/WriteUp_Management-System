using System.ComponentModel.DataAnnotations;

namespace EndPoint.Request.UserRequest
{
    public class FullNameRequest
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}