using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingArticles.Models
{
    public class ArticleContent
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public string Text { get; set; }

        public ContentPicture LogoPicture { get; set; }
        public List<ContentPicture> Pictures { get; set; } = new List<ContentPicture>();

        public ArticleContent()
        {

        }
        public ArticleContent(string text)
        {
            Text = text;
        }

        public async Task SetLogoImageAsync(IFormFile file, string webRootPath, string picturePath)
        {
            var picture = await FileSaver.CreateAndSavePictureAsync<ContentPicture>(file, webRootPath, picturePath);
            picture.Content = this;
            LogoPicture = picture;
        }

        public async Task AddPicture(IFormFile file, string webRootPath, string picturePath)
        {
            var picture = await FileSaver.CreateAndSavePictureAsync<ContentPicture>(file, webRootPath, picturePath);
            picture.Content = this;
            Pictures.Add(picture);
        }
    }
}
