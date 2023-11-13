
namespace BookLinks.Repositories.Models
{
    public class Link : ModelBasic
    {
        public string Path { get; set; }

        public int BookId { get; set; } 

        public Book? Book { get; set; }
    }
}
