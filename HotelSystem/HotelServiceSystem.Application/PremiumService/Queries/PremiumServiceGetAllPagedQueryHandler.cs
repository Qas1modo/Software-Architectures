using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.PremiumServiceModels;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.PremiumService.Queries;

internal sealed class PremiumServiceGetAllPagedQueryHandler(IPremiumServiceRepository premiumServiceRepository)
    : IQueryHandler<PremiumServiceGetAllPagedQuery, Maybe<PagedList<PremiumServiceResponseModel>>>
{
    private readonly IPremiumServiceRepository PremiumServiceRepository = premiumServiceRepository;

    public async Task<Maybe<PagedList<PremiumServiceResponseModel>>> Handle(PremiumServiceGetAllPagedQuery request,
        CancellationToken cancellationToken)
    {
        return await PremiumServiceRepository.GetAllRoomServicesAsync(request.GetPremiumServiceModel, cancellationToken);
    }
}