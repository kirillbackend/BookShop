using BookLinks.Repositories.Models;
using System.Threading.Tasks;

namespace BookLinks.Repositories.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByLoginPwdHash(string loginName, string pwdHash);
        Task Update(User user);
        Task<User> GetById(long id);
        Task<List<User>> GerUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<User> GetUserByIdAsync(int? id);
        Task DeleteUserAsync(int? id);
    }
}