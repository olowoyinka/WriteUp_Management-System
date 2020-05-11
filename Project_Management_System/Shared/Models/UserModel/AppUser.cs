using Microsoft.AspNetCore.Identity;
using Project_Management_System.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace Project_Management_System.Shared.Models.UserModel
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime JoinedDate { get; set; }

        public string Images { get; set; }

        public List<Topics> Topics { get; set; }
    }
}