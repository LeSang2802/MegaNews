using MegaNews.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaNews.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AccountModel> tblAccount { get; set; }
        public DbSet<ArticleModel> tblArticle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>().ToTable("tblAccount");
            modelBuilder.Entity<ArticleModel>().ToTable("tblArticle");
        }
    }
}
