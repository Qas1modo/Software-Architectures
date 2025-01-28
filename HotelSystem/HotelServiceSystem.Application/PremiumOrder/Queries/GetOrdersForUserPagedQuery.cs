using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.PremiumOrderModels;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;

namespace HotelServiceSystem.Application.PremiumOrder.Queries;

public sealed record GetOrdersForUserPagedQuery(GetPremiumOrdersModel GetPremiumServiceModel) : IQuery<Maybe<PagedList<PremiumOrderResponseModel>>>;
