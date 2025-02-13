using AutoMapper;
using Polotno.API.DTO;
using Polotno.API.Models;

namespace Polotno.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PaintingDto, Painting>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<AddRequestUserDto, User>()
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(x => x.Password))
                .ReverseMap();
            CreateMap<UpdateRequestUserDto, User>()
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(x => x.Password))
                .ReverseMap();
            CreateMap<LoginRequestDto, User>()
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(x => x.Password))
                .ReverseMap();
        }
    }
}