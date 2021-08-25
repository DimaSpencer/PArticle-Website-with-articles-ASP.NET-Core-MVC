using Microsoft.EntityFrameworkCore;

namespace ProgrammingArticles.Models
{
    [Owned]
    public class UserAvatar : Picture
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
