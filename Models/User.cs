using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
namespace ProgrammingArticles.Models
{
    public class User : IdentityUser, IEvaluated
    {
        public Roles Role { get; set; }
        public List<Article> CreatedArticles { get; set; }
        public int Likes { get; set; }
    }
}
