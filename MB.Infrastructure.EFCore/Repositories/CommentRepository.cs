using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly MasterBloggerContext _context;
    
    public CommentRepository(MasterBloggerContext context)
    {
        _context = context;
    }

    public void Create(Comment comment)
    {
        _context.Comments.Add(comment);
        _context.SaveChanges();
    }

    public List<CommentViewModel> GetList()
    {
        return _context.Comments.Include(x => x.Article)
            .Select(x => new CommentViewModel
            {
               Id = x.Id,
               Name = x.Name,
               Email = x.Email,
               Message = x.Message,
               CreationDate = x.CreationDate,
               Status = x.Status,
               Article = x.Article.Title
            }).ToList();
    }

    public Comment Get(long id)
    {
        return _context.Comments.FirstOrDefault(x => x.Id == id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}