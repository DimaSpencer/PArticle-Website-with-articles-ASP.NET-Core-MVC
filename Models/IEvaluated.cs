using System.Collections.Generic;

namespace ProgrammingArticles.Models
{
    public interface IEvaluated
    {
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}