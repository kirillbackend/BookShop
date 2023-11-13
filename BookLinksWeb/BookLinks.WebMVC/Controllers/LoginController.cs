using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.Extensions.Primitives;
using BookLinks.Repositories.Models;
using BookLinks.Common.Enums;
using BookLinks.Service.Services.Interface;

namespace BookLinks.WebMVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;

        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index(string returnURL)
        {
            if (returnURL == null)
            {
                returnURL = "/";
            }
            ViewBag.returnURL = returnURL;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginModel model)
        {
            var ip = GetIP();
            var browserId = GetBrowserId();

            // TODO is ip browserId banned ?
            if (ModelState.IsValid)
            {
                var user = await _accountService.GetLoginnedUser(model.Name, model.Password);

                if (user != null && !user.IsBanned)
                {
                    await Authenticate(user);

                    await _accountService.UserLogin(user.Id, ip, isSendNotificationIfLoginnedAdmin: true);

                    if (!string.IsNullOrWhiteSpace(model.ReturnURL)) return Redirect(model.ReturnURL);
                    return RedirectToAction("Index", "Book");
                }

                // TODO remember ip browserId and ban? after 3 attempts
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
                new Claim("id", user.Id.ToString())
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        private string GetBrowserId()
        {
            StringValues ret;
            if (Request.Headers.TryGetValue("browser-id", out ret))
            {
                return ret.ToString();
            }
            return null;
        }

        private string GetIP()
        {
            return Request.HttpContext.Connection.RemoteIpAddress.ToString().Replace("::1", "127.0.0.1");
        }
    }
}
