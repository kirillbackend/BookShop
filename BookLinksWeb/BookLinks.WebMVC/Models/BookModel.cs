using BookLinks.Repositories.Models;
using System.ComponentModel.DataAnnotations;

namespace BookLinks.WebMVC.Models
{
    public class BookModel : BaseModel
    {
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Название")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        [Required]
        public decimal Price { get; set; }

        [StringLength(10000, MinimumLength = 3)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [DataType(DataType.Date)]

        [Display(Name = "Релиз")]
        public DateTime Released { get; set; }

        [Display(Name = "Рэйтинг")]
        [Range(0, 5)]
        public int Rating { get; set; }

        public string ImageContent { get; set; }

        [Display(Name = "Обложка")]
        public string OriginalFileName { get; set; }

        public List<OrderModel> Orders { get; set; }

        public List<Link> Links { get; set; }
    }
}
