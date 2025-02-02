using BillingSystem.DAL.EFCore.Database;
using BillingSystem.DAL.EFCore.Repositories.Base;
using BillingSystem.Domain.Entities.BillingItem;
using BillingSystem.Domain.Entities.Invoice;
using BillingSystem.Domain.Repositories.Base;
using BillingSystem.Domain.UnitOfWork.Interfaces;

namespace BillingSystem.Infrastructure.UnitOfWork.Base;

public class BillingSystemUnitOfWork : IUnitOfWork
{
    protected readonly ApplicationDbContext _dbContext;

    public BillingSystemUnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

        BillingItemRepository = new EntityRepository<BillingItem>(_dbContext);
        InvoiceRepository = new EntityRepository<Invoice>(_dbContext);
    }

    public IEntityRepository<BillingItem> BillingItemRepository { get; }

    public IEntityRepository<Invoice> InvoiceRepository { get; }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}