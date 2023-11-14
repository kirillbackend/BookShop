namespace BookLinks.WebMVC.Models
{
    public class BookOrderModel
    {
        public int BookId { get; set; }
        public virtual BookModel Book { get; set; }

        public int OrderId { get; set; }
        public virtual OrderModel Order { get; set; }
    }
}
