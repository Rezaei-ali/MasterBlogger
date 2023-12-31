﻿using Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.Article;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories;

public class ArticleRepository : BaseRepository<long,Article>,IArticleRepository
{
    private readonly MasterBloggerContext _context;
    public ArticleRepository(MasterBloggerContext context) : base(context)
    {
        _context = context;
    }

    public List<ArticleViewModel> GetList()
    {
        return _context.Articles.Include(a => a.ArticleCategory)
            .Select(x => new ArticleViewModel
        {
            Id = x.Id,
            Title = x.Title,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate,
            IsDeleted = x.IsDeleted
        }).ToList();
    }
    
}