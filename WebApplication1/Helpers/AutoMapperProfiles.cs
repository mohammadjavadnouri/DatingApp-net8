using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.Entities;
using WebApplication1.Extensions;

namespace WebApplication1.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.Age, option => option.MapFrom(source => source.DateOfBirth.CalculateAge()))
                .ForMember(dest => dest.PhotoUrl,
                option => option.MapFrom(source => source.Photos.FirstOrDefault(x => x.IsMain)!.Url));
            CreateMap<Photo, PhotoDto>();
        }
    }
}
