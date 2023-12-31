using Framework.Domain;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg;

public class ArticleCategory : DomainBase<long>
{

    public string Title { get; private set; }
    public bool IsDeleted { get; private set; }
    public ICollection<Article.Article> Articles { get;  set; }


    protected ArticleCategory()
    {
        
    }
    public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
    {
        GuardAgainstEmptyTitle(title);
        validatorService.CheckRecordExist(title);
        
        Title = title;
        IsDeleted = false;
        Articles = new List<Article.Article>();
    }

    private void GuardAgainstEmptyTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException();
    }


    public void Rename(string title)
    {
        GuardAgainstEmptyTitle(title);
        Title = title;
    }

    public void Remove()
    {
        IsDeleted = true;
    }

    public void Activate()
    {
        IsDeleted = false;
    }
    
}