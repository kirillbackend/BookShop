using System.ComponentModel;

namespace BookLinks.Common.Enums
{
    public enum UserRoleEnum : int
    {
        [Description("Посетитель")]
        Buyer = 0,
        [Description("Пользователь")]
        Salesman = 1,
        [Description("Администратор")]
        Admin = 2,
    }
}
