using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query;

public class ArticleQuery : IArticleQuery
{
    private readonly MasterBloggerContext _context;

    public ArticleQuery(MasterBloggerContext context)
    {
        _context = context;
    }

    public List<ArticleQueryView> GetArticles()
    {
        return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
        {
            Id = x.Id,
            Title = x.Title,
            ShortDescription = x.ShortDescription,
            CreationDate = x.CreationDate,
            ArticleCategory = x.ArticleCategory.Title,
            Image = x.Image
        }).ToList();
    }
}