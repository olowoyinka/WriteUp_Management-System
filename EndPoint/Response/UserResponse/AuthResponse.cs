using System;

namespace EndPoint.Response.UserResponse
{
    public class AuthResponse
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        public string Error { get; set; }
    }
}