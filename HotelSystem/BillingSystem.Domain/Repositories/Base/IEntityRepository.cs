namespace BillingSystem.Domain.Repositories.Base;

public interface IEntityRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(object id);

    void Insert(TEntity entity);

    Task<bool> RemoveAsync(object id);

    void Update(TEntity entity);

    IQueryable<TEntity> GetQuery();
}
