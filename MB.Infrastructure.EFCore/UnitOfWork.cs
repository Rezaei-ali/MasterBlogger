using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore;

public class UnitOfWork : IUnitOfWork
{
    private readonly MasterBloggerContext _context;

    public UnitOfWork(MasterBloggerContext context)
    {
        _context = context;
    }

    public void BeginTran()
    {
        _context.Database.BeginTransaction();
    }

    public void CommitTran()
    {
        _context.SaveChanges();
        _context.Database.CommitTransaction();
    }

    public void RoleBack()
    {
        _context.Database.RollbackTransaction();
    }
}