using BookLinks.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookLinks.WebMVC.Models
{
    public class UserModel : BaseModel
    {
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Логин")]
        public string LoginName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Пароль")]
        public string PwdHash { get; set; }

        public string? BrowserId { get; set; }

        public bool IsBanned { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public string? LastLoginIP { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Роль")]
        public UserRoleEnum Role { get; set; }
    }
}
