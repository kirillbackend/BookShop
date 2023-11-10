using AutoMapper;
using BookLinks.Common.Enums;
using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Service.Models;
using BookLinks.Service.Services.Interface;

namespace BookLinks.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetUresAsync()
        {
            var users = await _userRepository.GerUsersAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users);
            return usersDto;
        }

        public async Task AddUserAsync(UserDto userDto)
        {
            if (userDto != null)
            {
                var user = _mapper.Map<User>(userDto);
                await _userRepository.AddUserAsync(user);
            }
            else
            {
                throw new ArgumentException(nameof(userDto));
            }
        }

        public async Task<List<UserDto>> GetFilterUsers(string? SearchString, List<UserDto> allUsers, UserOptionsEnum Option)
        {
            int parsedId = -1;
            if ((Option == UserOptionsEnum.id && !int.TryParse(SearchString, out parsedId))
                || (Option == UserOptionsEnum.Role && !int.TryParse(SearchString, out parsedId)))
            {
                throw new ArgumentException(nameof(Option));
            }
            else
            {
                var books = new List<UserDto>();
                var filters = new Dictionary<UserOptionsEnum, Func<IList<UserDto>, IList<UserDto>>>()
                {
                    {UserOptionsEnum.id, (list) => list = list.Where(l => l.Id == parsedId).ToList()},
                    {UserOptionsEnum.Name, (list) => list = list.Where(l => l.Name.ToLower().Contains(SearchString.ToLower())).ToList()},
                    {UserOptionsEnum.Email, (list) => list = list.Where(l => l.Email.ToLower().Contains(SearchString.ToLower())).ToList()},
                    {UserOptionsEnum.Role, (list) => list = list.Where(l => (int)l.Role == parsedId).ToList()}
                };

                if (filters.ContainsKey(Option))
                {
                    books = filters[Option](allUsers).ToList();
                }

                return books;
            }
        }

        public async Task<UserDto> GetUserByIdAsync(int? id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int? id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
