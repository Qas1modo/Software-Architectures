using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.PremiumServiceModels;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;

namespace HotelServiceSystem.Application.PremiumService.Queries;

public sealed record PremiumServiceGetAllPagedQuery(GetPremiumServicesModel GetPremiumServiceModel) : IQuery<Maybe<PagedList<PremiumServiceResponseModel>>>;
