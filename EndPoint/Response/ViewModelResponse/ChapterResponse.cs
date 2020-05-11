using System;

namespace EndPoint.Response.ViewModelResponse
{
    public class ChapterResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    public class ChapterByIdResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Body { get; set; }
    }
}
