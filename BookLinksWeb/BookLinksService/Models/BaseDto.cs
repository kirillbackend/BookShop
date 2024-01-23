namespace BookLinks.Service.Models
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
    }
}
