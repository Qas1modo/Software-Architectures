using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.Guest.Commands.DeactivateGuest;

public record DeactivateGuestCommand(Guid GlobalGuestId) : ICommand<Result>;

