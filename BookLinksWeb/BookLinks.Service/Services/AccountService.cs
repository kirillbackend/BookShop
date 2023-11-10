using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Service.Services.Interface;

namespace BookLinks.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetLoginnedUser(string loginName, string password)
        {
            try
            {
                var pwdHash = this.GetMD5Hash(password);
                var userDbModel = await _userRepository.GetUserByLoginPwdHash(loginName, pwdHash);
                return userDbModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UserLogin(long id, string ip, bool isSendNotificationIfLoginnedAdmin)
        {
            try
            {
                var userDbModel = await _userRepository.GetById(id);
                if (userDbModel != null)
                {
                    userDbModel.LastLoginDate = DateTime.Now;
                    userDbModel.LastLoginIP = ip;
                    await _userRepository.Update(userDbModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetMD5Hash(string password)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            var sb = new System.Text.StringBuilder();
            for (Int32 i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}
