using AutoMapper;
using crud_aspdotnet_core.Dtos;
using crud_aspdotnet_core.Entities;

namespace crud_aspdotnet_core.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VideoGame, VideoGameDto>();
            CreateMap<VideoGameDto, VideoGame>();
        }
    }
}
