using System.ComponentModel.DataAnnotations;

namespace BookLinks.Common.Enums
{
    public enum LinkOptionsEnum
    {
        [Display(Name = "Id")]
        id = 0,
        [Display(Name = "BookId")]
        BookId = 1,
        [Display(Name = "Название книги")]
        Name = 2,
        [Display(Name = "Автор")]
        Author = 3
    }
}
