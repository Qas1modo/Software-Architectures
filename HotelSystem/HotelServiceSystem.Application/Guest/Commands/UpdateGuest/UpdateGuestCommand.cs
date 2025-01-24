using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Contracts.Models.Guest;

namespace HotelServiceSystem.Application.Guest.Commands.UpdateGuest;

public record UpdateGuestCommand(UpdateGuestModel UpdateGuestModel) : ICommand<GenericResponseModel>;

