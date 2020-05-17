using System.ComponentModel.DataAnnotations;

namespace EndPoint.Request.UserRequest
{
    public class ForgetPasswordRequest
    {
        [Required]
	    [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
