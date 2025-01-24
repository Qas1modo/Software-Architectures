using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;

namespace HotelServiceSystem.Application.Guest.Commands.RemoveGuest;

public record RemoveGuestCommand(Guid GuestId) : ICommand<GenericResponseModel>;