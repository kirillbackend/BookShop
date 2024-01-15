namespace BookLinks.Repositories.Models
{
    public class BookOrder
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
