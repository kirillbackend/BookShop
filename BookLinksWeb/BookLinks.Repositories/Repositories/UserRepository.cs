using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookLinks.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> GetById(long id)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<User> GetUserByLoginPwdHash(string loginName, string pwdHash)
        {
            var user = await _dataContext.Users.Where(u => u.LoginName.Equals(loginName) && u.PwdHash.Equals(pwdHash) && !u.IsBanned).FirstOrDefaultAsync();
            return user;
        }

        public async Task Update(User user)
        {
            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<User>> GerUsersAsync()
        {
            var users = await _dataContext.Users.ToListAsync();
            return users;
        }

        public async Task AddUserAsync(User user)
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int? id)
        {
            var user = _dataContext.Users.Include(o => o.Orders).FirstOrDefault(x => x.Id == id);
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int? id)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(i => i.Id == id);
            if (user != null)
            {
                _dataContext.Users.Remove(user);
                await _dataContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(user));
            }
        }
    }
}
