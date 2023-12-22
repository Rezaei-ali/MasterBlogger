using MB.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories;

public class ArticleCategoryRepository : IArticleCategoryRepository
{
    private readonly MasterBloggerContext _context;

    public ArticleCategoryRepository(MasterBloggerContext context)
    {
        _context = context;
    }
    public void Add(ArticleCategory entity)
    {
        _context.ArticleCategories.Add(entity);
        _context.SaveChanges();
    }

    public List<ArticleCategory> GetAll()
    {
        return _context.ArticleCategories.OrderByDescending(x => x.Id).ToList();
    }

    public ArticleCategory Get(long id)
    {
        return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public bool Exists(string title)
    {
        return _context.ArticleCategories.Any(x => x.Title == title);
    }
}