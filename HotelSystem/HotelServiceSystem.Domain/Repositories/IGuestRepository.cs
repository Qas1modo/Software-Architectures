using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Repositories;

public interface IGuestRepository
{
    Task<Result> DeactivateGuest(Guid externalGuestId);

    Task<Maybe<GuestEntity>> GetByIdAsync(Guid id);

    void Remove(GuestEntity premiumService);

    void Insert(GuestEntity premiumService);

    void Update(GuestEntity premiumService);
}