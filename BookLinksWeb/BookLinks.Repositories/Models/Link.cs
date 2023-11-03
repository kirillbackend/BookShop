
namespace BookLinks.Repositories.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int BookId { get; set; } 
        public Book? Book { get; set; }
    }
}
