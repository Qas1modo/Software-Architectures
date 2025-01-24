using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Contracts.Models.Guest;

namespace HotelServiceSystem.Application.Guest.Commands.CreateGuest;

public record CreateGuestCommand(CreateGuestModel RegisterModel) : ICommand<GenericResponseModel>;

