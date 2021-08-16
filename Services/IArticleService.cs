using ProgrammingArticles.Controllers;
using ProgrammingArticles.Models;
using ProgrammingArticles.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammingArticles.Services
{
    public interface IArticleService
    {
        Article Get(int id);
        IEnumerable<Article> Get(int[] ids);
        Task<int> CreateAsync(ArticleViewModel articleModel);
        Task DeleteAsync(int id);
    }
}
