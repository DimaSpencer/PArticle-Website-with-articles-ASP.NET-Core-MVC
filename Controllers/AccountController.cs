using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProgrammingArticles.Models;
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
            View(new LoginModel { ReturnUrl = returnUrl });

        [HttpGet]
        public IActionResult Register(string returnUrl = null) =>
            View(new RegisterModel { ReturnUrl = returnUrl });

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Info()
        {
            User user = await _userManager.Users
                .Include(u => u.CreatedArticles)
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(loginModel.Email);
                var result = await _signInManager.PasswordSignInAsync(
                    user, loginModel.Password, loginModel.Remember, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(loginModel.ReturnUrl) && Url.IsLocalUrl(loginModel.ReturnUrl))
                        return Redirect(loginModel.ReturnUrl);
                    else
                        return RedirectToAction("Info");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
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
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetUserData(string id)
        {
            return View(_userManager.FindByIdAsync(id));
        }
    }
}
