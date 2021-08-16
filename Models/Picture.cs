using Microsoft.EntityFrameworkCore;

namespace ProgrammingArticles.Models
{
    [Owned]
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }
    }
}
