using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.Guest;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Repositories;

public interface IGuestRepository
{
    Task<Result> DeactivateGuest(Guid externalGuestId);

    Task<Maybe<GuestEntity>> GetByIdAsync(Guid id);

    Task<Maybe<PagedList<GuestResponseModel>>> GetGuestsAsync(GetAllGuestsPaged request,
        CancellationToken cancellationToken);

    void Remove(GuestEntity premiumService);

    void Insert(GuestEntity premiumService);

    void Update(GuestEntity premiumService);
}