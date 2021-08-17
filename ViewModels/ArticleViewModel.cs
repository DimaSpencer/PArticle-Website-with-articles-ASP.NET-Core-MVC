using Microsoft.AspNetCore.Http;
using ProgrammingArticles.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingArticles.ViewModels
{
    public class ArticleViewModel
    {
        [Required(ErrorMessage ="Invalid name")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Invalid content")]
        [StringLength(20000, MinimumLength = 2)]
        public string Text { get; set; }

        public IFormFile LogoImage { get; set; }

        public List<int> TagIds { get; set; }
    }
}
