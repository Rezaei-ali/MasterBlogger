
using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {

        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;
        public ArticleQueryView Article { get; set; }

        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
      
        }

        public void OnGet(long id)
        {
            Article = _articleQuery.GetArticles(id);
        }

        public RedirectToPageResult OnPost(AddComment command)
        {
            _commentApplication.Add(command);
            return RedirectToPage("./ArticleDetails", new {id = command.ArticleId});
        }
            


    }
}