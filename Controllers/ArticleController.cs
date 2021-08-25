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
        private readonly EvaluateService _evaluateService;

        public ArticleController(IArticleService articleService, EvaluateService evaluateService)
        {
            _articleService = articleService;
            _evaluateService = evaluateService;
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

        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            var article = _articleService.Get(id);
            await _evaluateService.LikeAsync(article);

            return RedirectToAction("Show", new { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Dislike(int id)
        {
            var article = _articleService.Get(id);
            await _evaluateService.DislikeAsync(article);

            return RedirectToAction("Show", new { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> SendComment(int id, string text)
        {
            var article = _articleService.Get(id);
            await _evaluateService.SendComment(article, text);
            return RedirectToAction("Show", new { Id = id });
        }
    }
}
