using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RoomManagementSystem.DAL.InfraStructure.Repositories.Interfaces.Base;

namespace RoomManagementSystem.DAL.EFCore.Repositories.Base
{
    public class EFCoreBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<TEntity> dbSet;

        public EFCoreBaseRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
            int pageIndex = 0,
            int pageSize = 20,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            query = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            dbSet.Remove(entity);
            return true;
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
    }
}
