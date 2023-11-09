using BookLinks.Common.Enums;

namespace BookLinks.Repositories.Models
{
    public class User : ModelBasic
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string LoginName { get; set; }

        public string PwdHash { get; set; }

        public string BrowserId { get; set; }

        public bool IsBanned { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public string LastLoginIP { get; set; }

        public UserRoleEnum Role { get; set; }
    }
}
