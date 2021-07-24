using System.Collections.Generic;
namespace ProgrammingArticles.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Article> Article { get; set; } = new List<Article>();
    }
}
