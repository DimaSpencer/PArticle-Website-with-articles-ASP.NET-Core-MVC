using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingArticles.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingArticles.Data
{
    //public interface IAppDbContext
    //{
    //    DbSet<Tag> Tags { get; }
    //    DbSet<Article> Articles { get; }
    //    Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds);

    //}
    public class AppDbContext : IdentityDbContext<User>
    {
        public override DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleContent> Contents { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public async Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds)
        {
            List<Tag> tags = new List<Tag>();
            foreach (var tadId in tagIds)
            {
                Tag tag = await Tags.FirstOrDefaultAsync(tag => tag.Id == tadId);
                if (tag != null)
                    tags.Add(tag);
            }
            return tags;
        }
    }
}
