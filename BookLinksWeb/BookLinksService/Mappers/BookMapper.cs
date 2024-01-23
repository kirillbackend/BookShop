using AutoMapper;
using BookLinks.Repositories.Models;
using BookLinks.Service.Models;

namespace BookLinks.Service.Mappers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book,BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}
