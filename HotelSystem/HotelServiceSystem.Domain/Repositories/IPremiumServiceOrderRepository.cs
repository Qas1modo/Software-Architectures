using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.PremiumOrderModels;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Repositories;

public interface IPremiumServiceOrderRepository
{
    Task<Maybe<PremiumServiceOrderEntity>> GetByIdAsync(Guid id);
    Task<Maybe<PagedList<PremiumOrderResponseModel>>> GetOrdersForUserAsync(GetPremiumOrdersModel getPremiumOrdersModel,
        CancellationToken cancellationToken);
    void Insert(PremiumServiceOrderEntity premiumServiceOrderEntity);
    Task<Result> FulfillPremiumOrder(Guid premiumOrderId);
    Task<Result> DeclinePremiumOrder(Guid premiumOrderId);
}

