using System.ComponentModel.DataAnnotations;

namespace BookLinks.Repositories.Models
{
    public abstract class ModelBasic
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
    }
}
