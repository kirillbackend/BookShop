using AutoMapper;
using BookLinks.Repositories.Models;
using BookLinks.Service.Models;

namespace BookLinks.Service.Mappers
{
    public class LinkMapper : Profile
    {
        public LinkMapper()
        {
            CreateMap<Link, LinkDto>();
            CreateMap<LinkDto, Link>();
        }
    }
}
