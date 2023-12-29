using MB.Domain.Article;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore;

public class MasterBloggerContext : DbContext
{
    public DbSet<ArticleCategory> ArticleCategories { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleMapping).Assembly);
        
        
        // modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
        // modelBuilder.ApplyConfiguration(new ArticleMapping());
        // modelBuilder.ApplyConfiguration(new CommentMapping());
        base.OnModelCreating(modelBuilder);
    }
}