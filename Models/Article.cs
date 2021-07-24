using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingArticles.Models
{
    public class Article : IEvaluated
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

        public string LogoImage { get; set; }
        public string BackgroundImage { get; set; }

        public int ContentId { get; set; }
        public ArticleContent Content { get; set; }

        public User Creator { get; set; }

        public DateTime TimeOfCreation { get; set; }
        public DateTime LastEditTime { get; set; }

        public int Likes { get; set; }
    }
}
