using HotelServiceSystem.DAL.EFCore.Database;
using HotelServiceSystem.DAL.Infrastructure.QueryObjects.Base;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.DAL.EFCore.QueryObjects.Base;

public class EFCoreQueryObject<TEntity> : QueryObject<TEntity> where TEntity : class, new()
{
    private readonly ApplicationDbContext _dbContext;

    public EFCoreQueryObject(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _query = _dbContext.Set<TEntity>().AsQueryable();
    }

    public override async Task<IEnumerable<TEntity>> ExecuteAsync()
    {
        return await _query.ToListAsync();
    }
}
