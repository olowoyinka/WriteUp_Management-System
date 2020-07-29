using AutoMapper;
using EndPoint.Response.ViewModelResponse;
using Project_Management_System.Shared.Models.ViewModels;

namespace Project_Management_System.Server.Mapping.CountGetAllMapping
{
    public class CountGetAllMappingResponse : Profile
    {
        public CountGetAllMappingResponse() 
        {
            CreateMap<CountAllGet, CountAllGetResponse>();
        }
    }
}