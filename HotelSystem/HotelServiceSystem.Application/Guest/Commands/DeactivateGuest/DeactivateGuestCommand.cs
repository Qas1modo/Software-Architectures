using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;

namespace HotelServiceSystem.Application.Guest.Commands.DeactivateGuest;

public record DeactivateGuestCommand(Guid ExternalGuestId) : ICommand<GenericResponseModel>;

