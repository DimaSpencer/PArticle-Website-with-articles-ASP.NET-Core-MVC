using Microsoft.AspNetCore.Authorization;
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
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult Show(int id)
        {
            return View(_articleService.Get(id));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ArticleModel articleModel)
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
            return RedirectToAction(); //добавить стрничку оповещени об успешном удалении обьекта
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
