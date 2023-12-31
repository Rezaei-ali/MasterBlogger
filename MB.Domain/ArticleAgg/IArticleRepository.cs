using Framework.Infrastructure;
using MB.Application.Contracts.Article;

namespace MB.Domain.Article;

public interface IArticleRepository : IRepository<long, Article>
{
    List<ArticleViewModel> GetList();
}