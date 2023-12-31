using MB.Domain.CommentAgg;
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
        return _context.Articles
            .Include(x => x.ArticleCategory)
            .Include(x => x.Comments)
            .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate,
                ArticleCategory = x.ArticleCategory.Title,
                Image = x.Image,
                CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirmed)
            }).ToList();
    }

    public ArticleQueryView? GetArticles(long id)
    {
        return _context.Articles
            .Include(x => x.ArticleCategory)
            .Include(x => x.Comments)
            .Select(x => new ArticleQueryView
        {
            Id = x.Id,
            Title = x.Title,
            ShortDescription = x.ShortDescription,
            CreationDate = x.CreationDate,
            ArticleCategory = x.ArticleCategory.Title,
            Image = x.Image,
            Content = x.Content,
            CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirmed),
            Comments = MapComments(x.Comments.Where(z => z.Status == Statuses.Confirmed))
        }).FirstOrDefault(x => x.Id == id);
    }


    private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
    {
        return comments
            .Select(x => new CommentQueryView()
            {
                Name = x.Name, 
                CreationDate = x.CreationDate, 
                Message = x.Message
            })
            .ToList();
    }
}