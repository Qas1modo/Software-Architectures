using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Repositories;

public interface IPremiumServiceOrderRepository
{
    Task<Maybe<PremiumServiceOrderEntity>> GetByIdAsync(Guid id);
    void CreatePremiumOrder(GuestEntity guest, PremiumServiceEntity premiumServiceEntity);
}

