﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ProgrammingArticles.Models
{
    public class User : IdentityUser, IEvaluated
    {
        public int AvatarId { get; set; }
        public UserAvatar Avatar { get; set; }

        public Roles Role { get; set; }
        public List<Article> CreatedArticles { get; set; }
        public int Likes { get; set; }

        public async Task UpdateAvatarAsync(IFormFile avatar, string webRootPath, string picturePath)
        {
            picturePath = picturePath.Replace(' ', '_');
            using (var fileStream = new FileStream(webRootPath + picturePath, FileMode.Create))
            {
                await avatar.CopyToAsync(fileStream);
            }

            Avatar = new UserAvatar { Name = avatar.FileName, Path = picturePath, User = this }; ;
        }
    }
}
