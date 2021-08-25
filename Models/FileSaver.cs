using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingArticles.Models
{
    public class FileSaver
    {
        public static async Task<T> CreateAndSavePictureAsync<T>(IFormFile file, string webRootPath, string picturePath)
            where T : Picture, new()
        {
            picturePath = picturePath.Replace(' ', '_');
            using (var fileStream = new FileStream(webRootPath + picturePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return new T { Name = file.FileName, Path = picturePath };
        }
    }
}
