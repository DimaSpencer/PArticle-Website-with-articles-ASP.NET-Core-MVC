using Microsoft.EntityFrameworkCore;

namespace ProgrammingArticles.Models
{
    [Owned]
    public class ArticleContent
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public ArticleContent()
        {

        }
        public ArticleContent(string text)
        {
            Text = text;
        }
    }
}
