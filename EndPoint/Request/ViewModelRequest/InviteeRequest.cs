using System;
using System.ComponentModel.DataAnnotations;

namespace EndPoint.Request.ViewModelRequest
{
    public class InviteeSentRequest
    {
        [Required]
        public string UserName { get; set; }

        public bool RoleStatus { get; set; }
    }

    public class InviteeAcceptRequest
    {        
        public bool acceptance { get; set; }
    }
}
