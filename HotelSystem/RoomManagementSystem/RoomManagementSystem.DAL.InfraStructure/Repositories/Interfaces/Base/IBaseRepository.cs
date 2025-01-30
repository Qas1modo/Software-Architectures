using System.Linq.Expressions;

namespace RoomManagementSystem.DAL.InfraStructure.Repositories.Interfaces.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        void Insert(TEntity entity);
        Task<bool> RemoveAsync(int id);
        void Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync(
            int pageIndex = 0,
            int pageSize = 20,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
    }
}
