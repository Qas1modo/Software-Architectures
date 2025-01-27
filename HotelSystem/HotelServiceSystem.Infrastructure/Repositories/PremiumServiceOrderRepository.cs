using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Infrastructure.Repositories;

internal class PremiumServiceOrderRepository(IDbContext dbContext)
    : GenericRepository<PremiumServiceOrderEntity>(dbContext), IPremiumServiceOrderRepository
{
    public async Task<Result> FulfillPremiumOrder(Guid premiumOrderId)
    {
        var premiumOrder = await GetByIdAsync(premiumOrderId);
        if (premiumOrder.HasNoValue) 
        {
            return Result.Failure(DomainErrors.PremiumServiceOrderErrors.InvalidPremiumServiceId);
        }
        return premiumOrder.Value.ChangeStatusToFulfilled();
    }

    public async Task<Result> DeclinePremiumOrder(Guid premiumOrderId)
    {
        var premiumOrder = await GetByIdAsync(premiumOrderId);
        if (premiumOrder.HasNoValue)
        {
            return Result.Failure(DomainErrors.PremiumServiceOrderErrors.InvalidPremiumServiceId);
        }
        return premiumOrder.Value.ChangeStatusToDeclined();
    }
}