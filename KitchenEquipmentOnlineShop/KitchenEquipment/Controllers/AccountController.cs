using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using KitchenEquipment.Models;
using KitchenEquipmentOnlineShop.BusinessLogic.Dtos;
using KitchenEquipmentOnlineShop.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KitchenEquipment.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return PartialView("_Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var regUser = _userService.GetUser(Mapper.Map<UserDto>(user).Email);
                if (regUser != null)
                {
                    ModelState.AddModelError("", "Такой пользователь уже существует.");
                }
                else
                {
                    await _userService.RegisterUser(Mapper.Map<UserDto>(user));
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home", user);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return PartialView("_Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel user)
        {
            var userAuth = _userService.AutheticateUser(user.Email, user.Password);

            if (userAuth != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userAuth.FullName),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не зарегистрирован.");
            }

            return RedirectToAction("Index", "Home", user);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}