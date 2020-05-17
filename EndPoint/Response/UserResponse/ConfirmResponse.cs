namespace EndPoint.Response.UserResponse
{
    public class ConfirmResponse
    {
        public string Result { get; set; }
         
        public string Error { get; set; }

        public bool Success { get; set; }

        public string UserId { get; set; }

        public string Email { get; set; }

        public string Code { get; set; }
    }

    public class ConfirmMapResponse
    {
        public string Result { get; set; }

        public string Error { get; set; }
    }
}