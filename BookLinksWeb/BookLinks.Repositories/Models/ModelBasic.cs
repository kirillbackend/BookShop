
namespace BookLinks.Repositories.Models
{
    public abstract class ModelBasic
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime Update { get; set; }
    }
}
