using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Threading.Tasks;

namespace ProgrammingArticles.Models
{
    public class Article : IEvaluated
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

        public int LogoImageId { get; set; }
        public Picture LogoImage { get; set; }
        public int BackgroundImageId { get; set; }
        public Picture BackgroundImage { get; set; }

        public int ContentId { get; set; }
        public ArticleContent Content { get; set; }

        public User Creator { get; set; }

        public DateTime TimeOfCreation { get; set; }
        public DateTime LastEditTime { get; set; }

        public int Likes { get; set; }

        public async Task SetLogoImageAsync(IFormFile file, string webRootPath, string picturePath)
        {
            using (var fileStream = new FileStream(webRootPath + picturePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            Picture picture = new Picture { Name = file.FileName, Path = picturePath, Owner = Creator };
            LogoImage = picture;
        }
    }
}
