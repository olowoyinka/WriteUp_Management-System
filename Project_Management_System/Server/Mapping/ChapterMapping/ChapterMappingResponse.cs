using AutoMapper;
using EndPoint.Response.ViewModelResponse;
using Project_Management_System.Shared.Models.ViewModels;

namespace Project_Management_System.Server.Mapping.ChapterMapping
{
    public class ChapterMappingResponse : Profile
    {
        public ChapterMappingResponse()
        {
            CreateMap<Chapter, ChapterResponse>();

            CreateMap<Chapter, ChapterByIdResponse>();
        }

    }
}
