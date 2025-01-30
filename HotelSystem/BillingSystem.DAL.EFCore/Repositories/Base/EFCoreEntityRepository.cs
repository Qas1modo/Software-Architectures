using BillingSystem.DAL.EFCore.Database;
using BillingSystem.DAL.Infrastructure.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.DAL.EFCore.Repositories.Base;

public class EFCoreEntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    public EFCoreEntityRepository(ApplicationDbContext context)
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
}
