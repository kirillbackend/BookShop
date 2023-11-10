using BookLinks.Common.Enums;
using BookLinks.Repositories.Models;
using BookLinks.Service.Models;

namespace BookLinks.Service.Services.Interface
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUresAsync();
        Task AddUserAsync(UserDto userDto);
        Task<List<UserDto>> GetFilterUsers(string? SearchString, List<UserDto> allBooks, UserOptionsEnum Option);
    }
}
