using HotelServiceSystem.Contracts.Models.RoomService;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.RoomService.Commands.CreateRoomService;

public record CreateRoomServiceCommand(CreateRoomServiceModel CreateRoomOrderModel) : ICommand<GenericResponseModel>;
