using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProgrammingArticles.Data;
using ProgrammingArticles.Models;
using ProgrammingArticles.Services;
using ProgrammingArticles.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingArticles.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IWebHostEnvironment _appEnvironment;
        public ArticleController(IArticleService articleService, IWebHostEnvironment appEnvironment)
        {
            _articleService = articleService;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Show(int id)
        {
            return View(_articleService.Get(id));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ArticleViewModel articleModel)
        {
            if (ModelState.IsValid)
            {
                int articleId = await _articleService.CreateAsync(articleModel);
                return RedirectToAction("Show", new { id = articleId });
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int articleId)
        {
            await _articleService.DeleteAsync(articleId);
            return RedirectToAction();
        }

        [HttpGet]
        public IActionResult Edit() => View();

        [HttpPatch]
        public IActionResult Edit(Article editingArticle) //придумать систему обновления
        {
            return Ok();
        }
    }
}
