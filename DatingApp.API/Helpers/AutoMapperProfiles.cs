using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(destination => destination.PhotoUrl, option => {
                    option.MapFrom(source => source.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(destination => destination.Age, option => {
                    option.ResolveUsing(source => source.DateOfBirth.CalculateAge());
                });
            CreateMap<User, UserForDetailedDto>()
                .ForMember(destination => destination.PhotoUrl, option => {
                    option.MapFrom(source => source.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(destination => destination.Age, option => {
                    option.ResolveUsing(source => source.DateOfBirth.CalculateAge());
                });
            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}