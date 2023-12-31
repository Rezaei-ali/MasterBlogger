using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg;

public interface ICommentRepository
{
    void Create(Comment comment);
    List<CommentViewModel> GetList();
    Comment Get(long id);
    void Save();
}