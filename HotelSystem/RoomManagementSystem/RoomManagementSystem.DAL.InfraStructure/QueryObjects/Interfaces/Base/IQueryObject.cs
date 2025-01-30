using System.Linq.Expressions;

namespace RoomManagementSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;

public interface IQueryObject<TEntity> where TEntity : class, new()
{
    IQueryObject<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

    IQueryObject<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> selector, bool ascending = true);

    IQueryObject<TEntity> Page(int page, int pageSize);

    Task<IEnumerable<TEntity>> ExecuteAsync();
}
