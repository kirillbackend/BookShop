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
    }
}
