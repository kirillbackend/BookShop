using System.ComponentModel;

namespace BookLinks.Common.Enums
{
    public enum UserRoleEnum : int
    {
        [Description("Посетитель")]
        Guest = 0,
        [Description("Пользователь")]
        User = 1,
        [Description("Администратор")]
        Admin = 2,
    }
}
