using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProgrammingArticles.Data;
using ProgrammingArticles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingArticles.Services
{
    public class EvaluateService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _database;
        private readonly UserManager<User> _userManager;
        public EvaluateService(
            IHttpContextAccessor contextAccessor,
            AppDbContext database,
            UserManager<User> userManager)
        {
            _contextAccessor = contextAccessor;
            _database = database;
            _userManager = userManager;
        }

        public async Task LikeAsync(IEvaluated evaluated)
        {
            evaluated.Likes++;
            await _database.SaveChangesAsync();
        }
        
        public async Task DislikeAsync(IEvaluated evaluated)
        {
            evaluated.Dislikes++;
            await _database.SaveChangesAsync();
        }

        public async Task SendComment(IEvaluated evaluated, string text)
        {
            var writer = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);

            evaluated.Comments.Add(new Comment() { 
                Text = text,
                Writer = writer,
                TimeOfWriting = DateTime.Now
            });

            await _database.SaveChangesAsync();
        }
    }
}
