namespace BookLinks.Repositories.Models
{
    public class Order : ModelBasic
    {
        public decimal Price { get; set; }
        public int NumberGoods { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public bool IsActive { get; set; }
        public List<BookOrder>  BookOrders { get; set; }
    }
}
