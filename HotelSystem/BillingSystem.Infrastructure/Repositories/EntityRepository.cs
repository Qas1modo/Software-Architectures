using BillingSystem.Infrastructure.Database;
using BillingSystem.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Infrastructure.Repositories.Base;

public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    public EntityRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Insert(TEntity entity)
    {
        _dbSet.Add(entity);
    }
    public void Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<bool> RemoveAsync(object id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            return false;
        }
        _dbSet.Remove(entity);
        return true;
    }

    public IQueryable<TEntity> GetQuery()
    {
        return _dbSet.AsQueryable();
    }
}
