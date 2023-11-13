using BookLinks.Repositories.Models;

namespace BookLinks.WebMVC.Models
{
    public class LinkModel : BaseModel
    {
        public string Path { get; set; }

        public int BookId { get; set; }

        public Book? Book { get; set; }
    }
}
