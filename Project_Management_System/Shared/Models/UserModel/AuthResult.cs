using System;

namespace Project_Management_System.Shared.Models.UserModel
{
    public class AuthResult
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        public string Error { get; set; }

        public bool Success { get; set; }
    }
}