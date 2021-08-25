using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingArticles.Models
{
    public class Comment : IEvaluated
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(300)]
        public string Text { get; set; }

        public User Writer { get; set; }

        public DateTime TimeOfWriting { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
