namespace MB.Domain.Article.Services;

public interface IArticleValidatorService
{
    void CheckRecordExist(string title);
}