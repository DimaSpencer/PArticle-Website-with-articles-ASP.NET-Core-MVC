using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingArticles.Data;
using ProgrammingArticles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingArticles.Managers
{
    public class ArticleManager : IArticleManager
    {
        private readonly AppDbContext _database;
        public ArticleManager(AppDbContext database)
        {
            _database = database;
        }

        public void Create(Article article)
        {
            throw new NotImplementedException();
        }

        public void Delete(string articleId)
        {
            throw new NotImplementedException();
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }
    }
}
