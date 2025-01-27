using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.Core;
using HotelServiceSystem.Contracts.Models.Guest;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;

namespace HotelServiceSystem.Application.Guest.Queries;

public sealed record GetAllGuestsQuery(GetAllGuestsPaged GetPremiumServiceModel) : IQuery<Maybe<PagedList<GuestResponseModel>>>;
