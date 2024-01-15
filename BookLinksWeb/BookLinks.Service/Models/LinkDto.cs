namespace BookLinks.Service.Models
{
    public class LinkDto : BaseDto
    {
        public string Path { get; set; }

        public int BookId { get; set; }

        public BookDto? Book { get; set; }
    }
}
