using System.ComponentModel.DataAnnotations;

namespace BookLinks.Repositories.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Дата выхода")]
        [DataType(DataType.Date)]
        public DateTime Released { get; set; }

        [Display(Name = "Дата создания записи")]
        public DateTime Created { get; set; }

        [Display(Name = "Дата редоктирования записи")]
        public DateTime Update { get; set; }

    }
}
