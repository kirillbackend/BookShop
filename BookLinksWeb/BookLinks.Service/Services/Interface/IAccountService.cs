using BookLinks.Repositories.Models;

namespace BookLinks.Service.Services.Interface
{
    public interface IAccountService
    {
        Task<User> GetLoginnedUser(string loginName, string password);
        Task UserLogin(long id, string ip, bool isSendNotificationIfLoginnedAdmin);
    }
}
