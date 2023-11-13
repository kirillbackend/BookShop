using AutoMapper;
using BookLinks.Service.Models;
using BookLinks.WebMVC.Models;

namespace BookLinks.WebMVC.Mappers
{
    public class LinkMapper : Profile
    {
        public LinkMapper()
        {
            CreateMap<LinkModel, LinkDto>();
            CreateMap<LinkDto, LinkModel>();
        }
    }
}
