using BookLinks.Repositories.Models;

namespace BookLinks.Repositories.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByLoginPwdHash(string loginName, string pwdHash);
        Task Update(User user);
        Task<User> GetById(long id);
    }
}