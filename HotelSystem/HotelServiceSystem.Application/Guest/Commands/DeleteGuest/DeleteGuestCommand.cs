using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.Guest.Commands.DeleteGuest;

public record DeleteGuestCommand(Guid GuestId) : ICommand<Result>;