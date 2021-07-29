using Microsoft.EntityFrameworkCore;
using Snippet.Data.Entities;

namespace Snippet.Data.DbContext
{
    public class SnippetDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public SnippetDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<SnippetEntity> SnippetPosts { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<LanguageEntity> Languages { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
