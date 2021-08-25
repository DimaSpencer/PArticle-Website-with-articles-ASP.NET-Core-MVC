using Microsoft.EntityFrameworkCore;

namespace ProgrammingArticles.Models
{
    public class ContentPicture : Picture
    {
        public int ContentId { get; set; }
        public ArticleContent Content { get; set; }
    }
}
