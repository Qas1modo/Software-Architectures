using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.PremiumServiceModels;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Repositories;

public interface IPremiumServiceRepository
{
    Task<Maybe<PagedList<PremiumServiceResponseModel>>> GetAllRoomServicesAsync(GetPremiumServicesModel premiumServiceModel,
    CancellationToken cancellationToken);

    Task<Maybe<PremiumServiceEntity>> GetByIdAsync(Guid id);

    void Remove(PremiumServiceEntity premiumService);

    void Insert(PremiumServiceEntity premiumService);

    void Update(PremiumServiceEntity premiumService);
}


