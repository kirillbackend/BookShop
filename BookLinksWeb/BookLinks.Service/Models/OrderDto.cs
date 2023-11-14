namespace BookLinks.Service.Models
{
    public class OrderDto : BaseDto
    {
        public decimal Price { get; set; }
        public int NumberGoods { get; set; }

        public int UserId { get; set; }
        public UserDto? User { get; set; }

        public bool IsActive { get; set; }

        public List<BookOrderDto> BookOrdersDto { get; set; }
    }
}
