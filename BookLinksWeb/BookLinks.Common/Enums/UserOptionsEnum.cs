using System.ComponentModel.DataAnnotations;

namespace BookLinks.Common.Enums
{
    public enum UserOptionsEnum
    {
        [Display(Name = "Идентификатор")]
        id = 0,
        [Display(Name = "Имя")]
        Name = 1,
        [Display(Name = "Почта")]
        Email = 3,
        [Display(Name = "Роль")]
        Role = 4
    }
}
