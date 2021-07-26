using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<SnippetPost> SnippetPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
