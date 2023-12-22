namespace MB.Domain.ArticleCategoryAgg;

public interface IArticleCategoryRepository
{
    void Add(ArticleCategory entity);
    List<ArticleCategory> GetAll();
    ArticleCategory Get(long id);
    void Save();
    bool Exists(string title);

}