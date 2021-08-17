using Microsoft.EntityFrameworkCore;

namespace ProgrammingArticles.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }

    [Owned]
    public class UserAvatar : Picture
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }

    [Owned]
    public class ArticlePicture : Picture
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
