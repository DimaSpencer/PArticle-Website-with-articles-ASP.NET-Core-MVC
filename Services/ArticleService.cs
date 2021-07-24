﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProgrammingArticles.Controllers;
using ProgrammingArticles.Data;
using ProgrammingArticles.Models;
using ProgrammingArticles.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingArticles.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _database;
        private readonly UserManager<User> _userManager;
        public ArticleService(IHttpContextAccessor contextAccessor, AppDbContext database, UserManager<User> userManager)
        {
            _contextAccessor = contextAccessor;
            _database = database;
            _userManager = userManager;
        }

        public async Task<int> CreateAsync(ArticleModel articleModel)
        {
            User creator = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            if (creator is null)
                throw new ArgumentNullException("User cannot be null");

            IEnumerable<Tag> tags = new List<Tag>();
            if (articleModel.TagIds != null && articleModel.TagIds.Count > 0)
                tags = await _database.GetTagsByIdsAsync(articleModel.TagIds);

            DateTime now = DateTime.Now;
            Article article = new Article
            {
                Name = articleModel.Name,
                Content = new ArticleContent(articleModel.Text),
                LogoImage = articleModel.LogoImage,
                BackgroundImage = articleModel.BackgroundImage,
                Creator = creator,
                Tags = tags,
                TimeOfCreation = now,
                LastEditTime = now
            };

            await _database.Articles.AddAsync(article);
            _database.SaveChanges();

            return article.Id;
        }

        public async Task DeleteAsync(int id)
        {
            User user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            if (user is null)
                throw new ArgumentNullException("User cannot be null");

            Article article = user.CreatedArticles.FirstOrDefault(a => a.Id == id);
            _database.Articles.Remove(article);
            _database.SaveChanges();
        }

        public Article Get(int id)
        {
            return _database.Articles
                .Include(a=>a.Creator)
                .FirstOrDefault(a => a.Id == id) ?? throw new Exception("An article with this ID does not exist");
        }

        public IEnumerable<Article> Get(int[] ids)
        {
            List<Article> articles = new List<Article>();

            foreach (var id in ids)
                articles.Add(_database.Articles.FirstOrDefault(a => a.Id == id) ?? throw new Exception("An article with this ID does not exist"));
            return articles;
        }
    }
}
