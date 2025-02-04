using BillingSystem.Domain.Entities.BillingItem;
using BillingSystem.Domain.Entities.Invoice;
using BillingSystem.Domain.Repositories.Base;
using BillingSystem.Domain.UnitOfWork.Interfaces.Base;

namespace BillingSystem.Domain.UnitOfWork.Interfaces;

public interface IUnitOfWork : IBaseUnitOfWork
{
    public IEntityRepository<BillingItemEntity> BillingItemRepository { get; }
    public IEntityRepository<InvoiceEntity> InvoiceRepository { get; }
}
