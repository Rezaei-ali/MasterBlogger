using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg;

public class ArticleCategory
{
    public long Id { get; private set; }
    public string Title { get; private set; }
    public bool IsDeleted { get; private set; }
    public string CreationDate { get; private set; }

    public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
    {
        GuardAgainstEmptyTitle(title);
        validatorService.CheckRecordExist(title);
        
        Title = title;
        CreationDate = DateTime.Now.ToString();
        IsDeleted = false;
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