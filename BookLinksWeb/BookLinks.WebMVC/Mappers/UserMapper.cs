using AutoMapper;
using BookLinks.Service.Models;
using BookLinks.WebMVC.Models;

namespace BookLinks.WebMVC.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDto, UserModel>();
            CreateMap<UserModel, UserDto>();
        }
    }
}
