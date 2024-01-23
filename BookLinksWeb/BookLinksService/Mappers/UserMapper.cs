using AutoMapper;
using BookLinks.Repositories.Models;
using BookLinks.Service.Models;

namespace BookLinks.Service.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
