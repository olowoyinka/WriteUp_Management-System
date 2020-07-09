namespace EndPoint.v1
{
    public static class APIRoute
    {
        public const string version = "v1";

        public static class Account
        {
            public const string Register = version + "/register";

            public const string Login = version + "/login";

            public const string ForgetPassword = version + "/forgetpassword";

            public const string ChangePassword = version + "/changepassword";

            public const string UpdateFullname = version + "/updatename";

            public const string GetAllUser = version + "/getalluser/{username}";

            public const string GetUserId = version + "/getuserid/{username}";

            public const string GetUser = version + "/getuser";

            public const string ProfilePicture = version + "/profile";

            public const string DeletePicture = version + "/profiledelete";
        }

        public static class Topics
        {
            public const string GetAll = version + "/topics";

            public const string Create = version + "/topics";

            public const string Get = version + "/topics/{topicsId}";

            public const string Update = version + "/topics/{topicsId}";

            public const string DeleteById = version + "/topics/{topicsId}";
        }

        public static class Invitee
        {
            public const string SentInvitee = version + "/topics/{topicsId}/sentinvitee";

            public const string AcceptInvitee = version + "/topics/{topicsId}/acceptinvitee";

            public const string ReadPending = version + "/topics/readpendinvitee/{topicsId}";

            public const string ReadAccepted = version + "/topics/readacceptinvitee/{topicsId}";

            public const string ReadUserPending = version + "/topics/readpendinvitee";

            public const string ReadUserAccepted = version + "/topics/readacceptinvitee";

        }

        public static class Chapter
        {
            public const string GetAll = version + "/topics/{topicsId}/chapter";

            public const string Create = version + "/topics/{topicsId}/chapter";
            
            public const string Update = version + "/topics/{topicsId}/chapter/{chatperId}";
            
            public const string UpdateBody = version + "/topics/{topicsId}/chapter/{chatperId}";

            public const string GetById = version + "/topics/{topicsId}/chapter/{chatperId}";

            public const string DeletedById = version + "/topics/{topicsId}/chapter/{chapterId}";

        }

        public static class EditBody
        {
            public const string UpdateBody = version + "/project/{topicsId}/chapter/{chatperId}";

            public const string GetById = version + "/project/{topicsId}/chapter/{chatperId}";
        }

        public static class Chatroom
        {
            public const string AddToGroup = version + "/chatroom/{chatroomId}";
        }
    }
}