using MB.Application.Contracts.Article;

namespace MB.Domain.Article;

public interface IArticleRepository
{
    List<ArticleViewModel> GetList();
    void Add(Article entity);
    void Save();
}