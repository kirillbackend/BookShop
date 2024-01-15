using AutoMapper;
using BookLinks.Common.Enums;
using BookLinks.Service.Models;
using BookLinks.Service.Services.Interface;
using BookLinks.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLinks.WebMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public UserController(IUserService userService, IMapper mapper, IAccountService accountService)
        {
            _userService = userService;
            _mapper = mapper;
            _accountService = accountService;
        } 

        public async Task<IActionResult> Index(string? searchString, UserOptionsEnum option)
        {
            var usersDto = await _userService.GetUresAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var filterUsers = await _userService.GetFilterUsers(searchString, usersDto, option);
                var usersModel = _mapper.Map<List<UserModel>>(filterUsers);
                return View(usersModel);
            }
            else
            {
                var usersModel = _mapper.Map<List<UserModel>>(usersDto);
                return View(usersModel);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(UserModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                user.Created = DateTime.Now;
                user.Update = DateTime.Now;
                user.PwdHash = _accountService.GetMD5Hash(user.PwdHash);
                var userDto = _mapper.Map<UserDto>(user);
                await _userService.AddUserAsync(userDto);
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else
            {
                var userDto = await _userService.GetUserByIdAsync(id);
                var user = _mapper.Map<UserModel>(userDto);
                return View(user);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                user.Update = DateTime.Now;
                var userDto = _mapper.Map<UserDto>(user);
                await _userService.UpdateUserAsync(userDto);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var userDto = await _userService.GetUserByIdAsync(id);
                var user = _mapper.Map<UserModel>(userDto);
                return View(user);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            var user = _mapper.Map<UserModel>(userDto);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                await _userService.DeleteUserAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
