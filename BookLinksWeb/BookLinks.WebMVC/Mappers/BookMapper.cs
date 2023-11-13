using AutoMapper;
using BookLinks.Service.Models;
using BookLinks.WebMVC.Models;

namespace BookLinks.WebMVC.Mappers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<BookDto, BookModel>();
            CreateMap<BookModel, BookDto>();
        }
    }
}
