using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Threading.Tasks;

namespace ProgrammingArticles.Models
{
    public class Article : IEvaluated
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        
        public int ContentId { get; set; }
        public ArticleContent Content { get; set; }

        public User Author { get; set; }

        public DateTime TimeOfCreation { get; set; }
        public DateTime LastEditTime { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        //public List<User> UsersWhoLiked { get; set; } = new List<User>();
    }
}
