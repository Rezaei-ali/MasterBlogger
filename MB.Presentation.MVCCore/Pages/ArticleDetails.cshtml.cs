﻿
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {

        private readonly IArticleQuery _articleQuery;
        public ArticleQueryView Article { get; set; }

        public ArticleDetailsModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet(long id)
        {
            Article = _articleQuery.GetArticles(id);
        }


    }
}