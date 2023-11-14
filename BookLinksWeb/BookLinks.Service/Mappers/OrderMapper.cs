using AutoMapper;
using BookLinks.Repositories.Models;
using BookLinks.Service.Models;

namespace BookLinks.Service.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>()
                .ForMember(x => x.BookOrdersDto, o => o.MapFrom(s => s.BookOrders.ToList()))
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<BookOrder, BookOrderDto>();
            CreateMap<BookOrderDto, BookOrder>();
        }
    }
}
