using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgrammingArticles.Models;
using ProgrammingArticles.Services;
using ProgrammingArticles.ViewModels;
using System.Threading.Tasks;

namespace ProgrammingArticles.Controllers
{

    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null) => 
            View(new LoginViewModel { ReturnUrl = returnUrl });

        [HttpGet]
        public IActionResult Register(string returnUrl = null) =>
            View(new RegisterViewModel { ReturnUrl = returnUrl });

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(loginModel.Email);
                if(user is not null)
                {
                    var result = await _signInManager.PasswordSignInAsync(
                    user, loginModel.Password, loginModel.RememberMe, false);

                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(loginModel.ReturnUrl) && Url.IsLocalUrl(loginModel.ReturnUrl))
                            return Redirect(loginModel.ReturnUrl);
                        else
                            return RedirectToAction("Info", "User");
                    }
                }
                ModelState.AddModelError("", "Incorrect login or password");
            }
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(registerModel.Email);
                if (user == null)
                {
                    user = new User { UserName = registerModel.Name, Email = registerModel.Email };
                    var result = await _userManager.CreateAsync(user, registerModel.Password);

                    if (result.Succeeded)
                        return RedirectToAction("Login", "Account");

                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User with this email already exists");
                }
            }
            return View(registerModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> EmailIsBusy(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return Json(true);
            else
                return Json(false);
        }
    }
}
