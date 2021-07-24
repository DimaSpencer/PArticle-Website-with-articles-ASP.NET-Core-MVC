using ProgrammingArticles.Models;

namespace ProgrammingArticles.Managers
{
    public interface IArticleManager
    {
        void Create(Article article);
        void Delete(string articleId);
        void Edit();
    }
}