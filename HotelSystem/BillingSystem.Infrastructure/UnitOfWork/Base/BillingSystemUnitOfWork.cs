using BillingSystem.Infrastructure.Database;
using BillingSystem.Domain.Entities.BillingItem;
using BillingSystem.Domain.Entities.Invoice;
using BillingSystem.Domain.Repositories.Base;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using BillingSystem.Infrastructure.Repositories.Base;

namespace BillingSystem.Infrastructure.UnitOfWork.Base;

public class BillingSystemUnitOfWork : IUnitOfWork
{
    protected readonly ApplicationDbContext _dbContext;

    public BillingSystemUnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

        BillingItemRepository = new EntityRepository<BillingItemEntity>(_dbContext);
        InvoiceRepository = new EntityRepository<InvoiceEntity>(_dbContext);
    }

    public IEntityRepository<BillingItemEntity> BillingItemRepository { get; }

    public IEntityRepository<InvoiceEntity> InvoiceRepository { get; }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}