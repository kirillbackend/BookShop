

namespace BookLinks.Service.Models
{
    public class BookOrderDto
    {
        public int BookId { get; set; }
        public virtual BookDto Book { get; set; }

        public int OrderId { get; set; }
        public virtual OrderDto Order { get; set; }
    }
}
