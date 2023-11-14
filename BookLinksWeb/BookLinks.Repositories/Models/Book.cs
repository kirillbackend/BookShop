
namespace BookLinks.Repositories.Models
{
    public class Book : ModelBasic
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string Author { get; set; }

        public DateTime Released { get; set; }

        public int Rating { get; set; }

        public string ImageContent { get; set; }

        public string OriginalFileName { get; set; }

        public List<BookOrder> BookOrders { get; set; }

        public List<Link> Links { get; set; }
    }
}
