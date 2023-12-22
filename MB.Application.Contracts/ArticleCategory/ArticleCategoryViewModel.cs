namespace MB.Application.Contracts;

public class ArticleCategoryViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public bool IsDeleted { get; set; }
    public string CreationDate { get; set; }
}