namespace BookLinks.WebMVC.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
    }
}
