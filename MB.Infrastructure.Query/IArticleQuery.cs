namespace MB.Infrastructure.Query;

public interface IArticleQuery
{
    List<ArticleQueryView> GetArticles();
}