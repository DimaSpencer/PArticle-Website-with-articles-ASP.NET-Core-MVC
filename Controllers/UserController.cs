using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProgrammingArticles.Data;
using ProgrammingArticles.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ProgrammingArticles.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _appEnvironment;
        public UserController(
            UserManager<User> userManager,
            AppDbContext context,
            IWebHostEnvironment appEnvironment)
        {
            _userManager = userManager;
            _dbContext = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Info()
        {
            return View(await GetUserAsync());
        }

        [HttpGet]
        public IActionResult GetUserData(string id)
        {
            return View(_userManager.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UploadAvatar(IFormFile avatar)
        {
            if (avatar != null)
            {
                User user = await GetUserAsync();

                string picturePath = AppPaths.Pictures + avatar.FileName;
                await user.UpdateAvatarAsync(avatar, _appEnvironment.WebRootPath, picturePath);

                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Info");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateName(string newName)
        {
            if (newName is null)
                throw new ArgumentNullException("name is null");

            User user = await GetUserAsync();
            user.UserName = newName;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Info");
        }

        private async Task<User> GetUserAsync()
        {
            return await _userManager.Users
                .Include(u => u.CreatedArticles)
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
        }
    }
}
