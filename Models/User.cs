using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Threading.Tasks;

namespace ProgrammingArticles.Models
{
    public class User : IdentityUser
    {
        public int AvatarId { get; set; }
        public UserAvatar Avatar { get; set; }
        public Roles Role { get; set; }

        public List<Article> CreatedArticles { get; set; } = new List<Article>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

        //public List<Article> LikedArticles { get; set; } = new List<Article>();
        //public List<Comment> LikedComments { get; set; } = new List<Comment>();

        public async Task UpdateAvatarAsync(IFormFile avatar, string webRootPath, string picturePath)
        {
            var picture = await FileSaver.CreateAndSavePictureAsync<UserAvatar>(avatar, webRootPath, picturePath);
            picture.User = this;

            Avatar = picture;
        }
    }
}
