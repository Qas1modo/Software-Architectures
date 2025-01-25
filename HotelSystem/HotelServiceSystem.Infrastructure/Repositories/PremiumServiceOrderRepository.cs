using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class PremiumServiceOrderRepository(IDbContext dbContext)
    : GenericRepository<PremiumServiceOrderEntity>(dbContext), IPremiumServiceOrderRepository
{
    public void CreatePremiumOrder(GuestEntity guest, PremiumServiceEntity premiumServiceEntity)
    {
        var premiumServiceOrder = PremiumServiceOrderEntity.Create(guest, premiumServiceEntity);
        Insert(premiumServiceOrder);
    }
}