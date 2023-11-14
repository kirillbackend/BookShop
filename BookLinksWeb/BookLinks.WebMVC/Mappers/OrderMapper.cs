using AutoMapper;
using BookLinks.Service.Models;
using BookLinks.WebMVC.Models;

namespace BookLinks.WebMVC.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper() 
        {
            CreateMap<OrderDto, OrderModel>();
            CreateMap<OrderModel, OrderDto>();

            CreateMap<OrderDto, OrderModel>()
                .ForMember(x => x.BookOrdersModel, o => o.MapFrom(s => s.BookOrdersDto.ToList()))
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ReverseMap();

            CreateMap<BookOrderDto, BookOrderModel>();
            CreateMap<BookOrderModel, BookOrderDto>();
        }
    }
}
