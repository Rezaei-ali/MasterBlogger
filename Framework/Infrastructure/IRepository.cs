using System.Linq.Expressions;
using Framework.Domain;

namespace Framework.Infrastructure;

public interface IRepository<in TKey,T> where T : DomainBase<TKey>
{
    void Create(T entity);
    List<T> GetAll();
    T Get(TKey id);
    void Save();
    bool Exists(Expression<Func<T, bool>> expression);
}