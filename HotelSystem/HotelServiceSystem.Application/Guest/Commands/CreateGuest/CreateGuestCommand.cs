using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.Guest;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.Guest.Commands.CreateGuest;

public record CreateGuestCommand(CreateGuestModel CreateGuestModel) : ICommand<Result>;

