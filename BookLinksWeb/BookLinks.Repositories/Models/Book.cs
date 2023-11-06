using System.ComponentModel.DataAnnotations;

namespace BookLinks.Repositories.Models
{
    public class Book : ModelBasic
    {
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Название")]
        [Required]
        public string Name { get; set; }

        [StringLength(1000, MinimumLength = 3)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [DataType(DataType.Date)]

        [Display(Name = "Дата выхода")]
        public DateTime Released { get; set; }

        [Display(Name = "Рэйтинг")]
        [Range(0,5)]
        public int Rating { get; set; }

        public string ImageContent { get; set; }

        public string OriginalFileName { get; set; }

        public List<Link> Links { get; set; }
    }
}
