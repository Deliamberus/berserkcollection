using BerserkCollection.Domain.Entities;
using BerserkCollection.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BerserkCollection.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManager;

        public AccountController(UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Collection", "Collection");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Collection", "Collection");
                }
                else
                {
                    ModelState.AddModelError("UserName", "Неправильный логин и (или) пароль");
                    return View(model);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // удаляем аутентификационные куки
            _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserAccount { UserName = model.UserName, Email = model.Email, City = model.City };

                // Проверка на дубликат логина
                var userWithSameUserName = await _userManager.FindByNameAsync(model.UserName);
                if (userWithSameUserName != null)
                {
                    ModelState.AddModelError("UserName", "Пользователь с таким логином существует");
                    return View(model);
                }

                // Проверка на дубликат почты
                var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);
                if (userWithSameEmail != null)
                {
                    ModelState.AddModelError("Email", "Пользователь с такой почтой существует");
                    return View(model);
                }

                var result = _userManager.CreateAsync(user, model.Password).Result;

                if (result.Succeeded)
                {
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
                    return RedirectToAction("Collection", "Collection");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
