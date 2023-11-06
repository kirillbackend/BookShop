using System.ComponentModel.DataAnnotations;

namespace BookLinks.Common.Enums
{
    public enum BookOptiosEnum
    {
        [Display(Name = "Идентификатор")]
        id = 0,
        [Display(Name = "Название")]
        Name = 1,
        [Display(Name = "Автор")]
        Author = 3,
        [Display(Name = "Рэйтинг")]
        Rating = 4
    }
}
