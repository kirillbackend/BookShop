
using BookLinks.Repositories.Models;

namespace BookLinks.Service.Models
{
    public class LinkDto : BaseDto
    {
        public string Path { get; set; }

        public int BookId { get; set; }

        public Book? Book { get; set; }
    }
}
